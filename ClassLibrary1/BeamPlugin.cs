using System;
using System.Collections.Generic;
using Tekla.Structures.Plugins;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Dialog;
using System.Windows.Forms;
using moldar;


namespace pluginmoldar
{

    [Plugin("BeamPlugin")] // Mandatory field which defines that this is the plug-in and stores the name of the plug-in to the system.
    [PluginUserInterface(UserInterfaceDefinitions.interfazPlugin1)] // Mandatory field which defines the user interface the plug-in uses. A Windows Forms class or a .inp file.
    public class BeamPlugin : PluginBase
    {
        private readonly StructuresData data;

        public BeamPlugin(StructuresData data)
        {
            TSM.Model M = new TSM.Model();
            this.data = data;
        }

        public override List<InputDefinition> DefineInput()
        {
            MessageBox.Show("antes de instanciar un picker");

            Picker picker = new Picker();
            List<InputDefinition> inputList = new List<InputDefinition>();            

            TSM.Beam muro = (TSM.Beam)picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);

            InputDefinition input1 = new InputDefinition(muro.Identifier);
            inputList.Add(input1);

            MessageBox.Show("despues de capturar un muro");

            return inputList;
        }

        public override bool Run(List<InputDefinition> input)
        {
            try
            {
                Tekla.Structures.Identifier id = (Tekla.Structures.Identifier)(input[0]).GetInput();
                Tekla.Structures.Model.Model model = new TSM.Model();
                TSM.Beam beam = (TSM.Beam)model.SelectModelObject(id);
                
                model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TSM.TransformationPlane());
                TSM.TransformationPlane currentTP = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
                CoordinateSystem coordenadasMuro = beam.GetCoordinateSystem();
                model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TSM.TransformationPlane(coordenadasMuro));

                ParametrosPanel p = new ParametrosPanel(beam);
                p.dx = data.dx;
                p.dy = data.dy;
                p.diametroBarras = data.diametroBarras;
                p.diametroDiagonal = data.diametroDiagonales;
                p.adicionalDerecha = data.largoDerecha;
                p.adicionalIzquierda = data.largoIzquierda;
                p.adicionalSuperior = data.largoSuperior;
                p.adicionalInferior = data.largoInferior;          

                PanelMoldar panel = new PanelMoldar(p);
                panel.fabricar();

                model.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentTP);
                
            }
            catch (Exception ex)
            {
                ErrorDialog.Show("Exception", ex.Message, ErrorDialog.Severity.ERROR);
            }

            return true;
        }
    }
}
