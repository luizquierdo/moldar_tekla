using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Drawing;

namespace moldar
{
    public partial class FormPanel : Form
    {
        Model model;
        Tekla.Structures.Model.Connection con;
        Beam muro;
        double dx, dy;

        public FormPanel()
        {
            InitializeComponent();
            model = new Model();
            con = new Tekla.Structures.Model.Connection();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!validarMuroSeleccionado()) return;

            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane());
            TransformationPlane currentTP = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            T3D.CoordinateSystem coordenadasMuro = muro.GetCoordinateSystem();
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(coordenadasMuro));

            ParametrosPanel p = new ParametrosPanel(muro);
            p.dx = Double.Parse(this.txtDx.Text);
            p.dy = Double.Parse(this.txtDz.Text);
            p.adicionalDerecha = Double.Parse(this.txtAddDer.Text);
            p.adicionalIzquierda = Double.Parse(this.txtAdIzq.Text);
            p.adicionalSuperior = Double.Parse(this.txtAdicionalSup.Text);
            p.adicionalInferior = Double.Parse(this.txtAdicionalInf.Text);
            p.diametroBarras = 7.0;
            p.diametroDiagonal = 4.0;

            PanelMoldar panel = new PanelMoldar(p);            

            panel.fabricar();

            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentTP);
            model.CommitChanges();
        }     

        private void btnSeleccionarMuro_Click(object sender, EventArgs e)
        {
            Picker Picker = new Picker();
            try
            {
                Tekla.Structures.Model.ModelObject objeto = Picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT);
                if (!(objeto is Beam))
                {
                    MessageBox.Show("debe seleccionar un muro...");
                    return;
                }
                muro = (Beam)objeto;
                this.lblMuroSeleccionado.Text = muro.Name + " " + muro.Material.MaterialString;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }

        private void btnBorrarDiagonales_Click(object sender, EventArgs e)
        {
            if (!validarMuroSeleccionado()) return;                

            ModelObjectEnumerator r = this.muro.GetReinforcements();

            while (r.MoveNext())
            {
                RebarGroup rg = (RebarGroup)r.Current;
                
                if (rg.Name == "diagonales")
                    rg.Delete();
                
            }

            model.CommitChanges();
        }

        private bool validarMuroSeleccionado()
        {
            if (muro == null)
            {
                MessageBox.Show("debe seleccionar un muro");
                return false;
            }

            return true;
        }

        private void btnLimpiarFierro_Click(object sender, EventArgs e)
        {
            ModelObjectEnumerator r;
            r = model.GetModelObjectSelector().GetAllObjectsWithType(Tekla.Structures.Model.ModelObject.ModelObjectEnum.REBARGROUP);
            
            while (r.MoveNext())
            {
                RebarGroup rg = (RebarGroup)r.Current;
                rg.Grade = "Undefined";
                rg.Modify();
            }

            model.CommitChanges();

            MessageBox.Show("termine");
        }

        private void txtDx_Leave(object sender, EventArgs e)
        {
            try
            {
                this.dx = Double.Parse(txtDx.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("debe ingresar valores numericos para dx");
                txtDx.Text = "";
                return;
            }
        }

        private void txtDz_Leave(object sender, EventArgs e)
        {
            try
            {
                dy = Double.Parse(txtDz.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("debe ingresar valores numericos para dy");
                txtDz.Text = "";
                return;
            }
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            DrawingHandler drawingHandler = new DrawingHandler();
            GADrawing drawing = new GADrawing();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
