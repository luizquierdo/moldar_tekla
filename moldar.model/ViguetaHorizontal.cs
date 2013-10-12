using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace moldar
{
    class ViguetaHorizontal : Vigueta, ComponentePanel
    {
        public ViguetaHorizontal(ParametrosPanel p, double offsetY) : base(p, offsetY)
        {
        }

        public override void fabricar()
        {
            fabricarBarras();
            fabricarDiagonales();
        }

        private void fabricarDiagonales()
        {
            double i = -(p.min.X + p.dx + DISTANCIA_A_TUBO);

            while (-i + NORMAL_DIAGONAL < p.max.X)
            {
                T3D.Point p1 = new T3D.Point(-i,                     YDiagonal(offset), z2());
                T3D.Point p2 = new T3D.Point(p1.X + NORMAL_DIAGONAL, YDiagonal(offset), z1());
                T3D.Point p3 = new T3D.Point(p2.X + 50.0,            YDiagonal(offset), z1());
                T3D.Point p4 = new T3D.Point(p3.X + NORMAL_DIAGONAL, YDiagonal(offset), z2());

                SingleRebar d1 = FabricaElementosPanel.createDiagonal(p1, p2, p.diametroDiagonal); 
                SingleRebar d2 = FabricaElementosPanel.createDiagonal(p3, p4, p.diametroDiagonal);

                d1.Father = p.muro;
                d2.Father = p.muro;

                d1.Insert();
                d2.Insert();

                i -= 400.0;
            }
        }

        private void fabricarBarras()
        {
            T3D.Point p1 = new T3D.Point(x1(), YBarras(offset), z2());
            T3D.Point p2 = new T3D.Point(x2(), YBarras(offset), z2());
            T3D.Point p3 = new T3D.Point(x1(), YBarras(offset), z1());
            T3D.Point p4 = new T3D.Point(x2(), YBarras(offset), z1());

            SingleRebar barra1 = FabricaElementosPanel.createBarraLongitudinal(p1, p2, p.diametroBarras);
            SingleRebar barra2 = FabricaElementosPanel.createBarraLongitudinal(p3, p4, p.diametroBarras);

            barra1.Father = p.muro;
            barra2.Father = p.muro;

            barra1.Insert();
            barra2.Insert();
        }        

        private double x1()
        {
            return p.min.X - p.adicionalIzquierda;
        }

        private double x2()
        {
            return p.max.X + p.adicionalDerecha;
        }

        private double z1()
        {
            return p.min.Z + recubrimientoHorizontal();
        }

        private double z2()
        {
            return p.min.Z + ANCHO_VIGUETA_HORIZONTAL + recubrimientoHorizontal() + 2 * p.diametroBarras;
        }

        private double recubrimientoHorizontal()
        {
            return (p.max.Z - p.min.Z - ANCHO_VIGUETA_HORIZONTAL - 2 * p.diametroBarras) / 2;
        }

        private double YBarras(double offsetY)
        {
            return p.max.Y + Vigueta.DIAMETRO_TUBO / 2 + p.diametroBarras / 2 - offsetY;
        }

        private double YDiagonal(double offsetY)
        {
            return p.max.Y + Vigueta.DIAMETRO_TUBO / 2 + p.diametroBarras + p.diametroDiagonal / 2 - offsetY;
        }
    }
}
