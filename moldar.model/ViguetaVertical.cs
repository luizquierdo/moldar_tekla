using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace moldar
{
    class ViguetaVertical : Vigueta, ComponentePanel 
    {
        public ViguetaVertical(ParametrosPanel p, double offsetX) : base(p, offsetX)
        {
        }

        public override void fabricar()
        {
            fabricarBarras();
            fabricarDiagonales();
            fabricarTubos();
        }

        private void fabricarBarras()
        {
            T3D.Point p1 = new T3D.Point(XBarras(offset), p.min.Y - p.adicionalInferior, z2());
            T3D.Point p2 = new T3D.Point(XBarras(offset), p.max.Y + p.adicionalSuperior, z2());
            T3D.Point p3 = new T3D.Point(XBarras(offset), p.min.Y - p.adicionalInferior, z1());
            T3D.Point p4 = new T3D.Point(XBarras(offset), p.max.Y + p.adicionalSuperior, z1());

            SingleRebar barra1 = FabricaElementosPanel.createBarraLongitudinal(p1, p2, p.diametroBarras);
            SingleRebar barra2 = FabricaElementosPanel.createBarraLongitudinal(p3, p4, p.diametroBarras);

            barra1.Father = p.muro;
            barra2.Father = p.muro;

            barra1.Insert();
            barra2.Insert();            
        }

        private void fabricarDiagonales()
        {
            double i = p.max.Y - p.dy - DISTANCIA_A_TUBO;

            while (i - NORMAL_DIAGONAL > p.min.Y)
            {
                T3D.Point p1 = new T3D.Point(XDiagonal(offset), i, z1());
                T3D.Point p2 = new T3D.Point(XDiagonal(offset), p1.Y - NORMAL_DIAGONAL, z2());  
                T3D.Point p3 = new T3D.Point(XDiagonal(offset), p2.Y - 50.0, z2());
                T3D.Point p4 = new T3D.Point(XDiagonal(offset), p3.Y - NORMAL_DIAGONAL, z1());

                SingleRebar d1 = FabricaElementosPanel.createDiagonal(p1, p2, p.diametroDiagonal);
                SingleRebar d2 = FabricaElementosPanel.createDiagonal(p3, p4, p.diametroDiagonal);

                d1.Father = p.muro;
                d2.Father = p.muro;
                
                d1.Insert();
                d2.Insert();

                i -= 400.0;
            }
        }

        private  void fabricarTubos()
        {
            double y = p.max.Y - p.dy;
            Assembly a = p.muro.GetAssembly();

            while (y > p.min.Y)
            {
                T3D.Point p1 = new T3D.Point(XTubo(offset), y, p.min.Z + 15);
                T3D.Point p2 = new T3D.Point(XTubo(offset), y, p.max.Z - 15);

                Beam tubo = FabricaElementosPanel.createTubo(p1, p2);
                tubo.Insert();
                
                a.GetSubAssemblies().Add(tubo.GetAssembly());                

                y -= 400.0;
            }

            a.Modify();
        }

        public double recubrimientoVertical()
        {
            return (p.max.Z - p.min.Z - ANCHO_VIGUETA_HORIZONTAL) / 2;
        }

        private double z1()
        {
            return p.min.Z + recubrimientoVertical();
        }

        private double z2()
        {
            return p.min.Z + ANCHO_VIGUETA_HORIZONTAL + recubrimientoVertical();
        }

        private double XDiagonal(double offset)
        {
            return p.min.X + Vigueta.DIAMETRO_TUBO / 2 - p.diametroDiagonal / 2  + offset;
        }

        private double XTubo(double offset)
        {
            return p.min.X - Vigueta.DIAMETRO_TUBO / 2 + offset;
        }

        private double XBarras(double offsetX)
        {
            return p.min.X + Vigueta.DIAMETRO_TUBO / 2 + p.diametroBarras / 2 + offsetX;
        }
    }
}
