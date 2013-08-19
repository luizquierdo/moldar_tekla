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
            Picker picker = new Picker();
            List<InputDefinition> inputList = new List<InputDefinition>();

            TSM.Beam muro = (TSM.Beam)picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);

            InputDefinition input1 = new InputDefinition(muro.Identifier);
            inputList.Add(input1);

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

                PanelMoldar panel = new PanelMoldar(beam);
                panel.dx = data.dx;
                panel.dy = data.dy;
                panel.diametroBarras = data.diametroBarras;
                panel.diametroDiagonal = data.diametroDiagonales;

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
