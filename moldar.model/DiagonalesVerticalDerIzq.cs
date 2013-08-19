using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;
using System.Collections;

namespace moldar
{
    public class DiagonalesVerticalDerIzq : DiagonalesVigueta, ComponentePanel
    {
        public DiagonalesVerticalDerIzq(Beam muro, double dx, double dy)
            : base(muro, dx, dy)
        {
        }

        public override bool crearSiguienteElemento(double avance)
        {
            return (avance - NORMAL_DIAGONAL > min.Y);
        }

        public override double getPartidaAvance()
        {
            return max.Y - dy - DISTANCIA_A_TUBO - NORMAL_DIAGONAL - 50.0;
        }

        public override T3D.Point getPuntoInicial(double avance)
        {
            double x = min.X - diametroDiagonal / 2 + TubosVigueta.DIAMETRO / 2 + dx;
            double y = avance;
            double z = min.Z + ANCHO_VIGUETA_HORIZONTAL + getSeparacionDiagonalVertical();
            return new T3D.Point(x, y, z);
        }

        public override T3D.Point getPuntoFinal(double avance)
        {
            double x = min.X - diametroDiagonal / 2 + TubosVigueta.DIAMETRO / 2 + dx;
            double y = avance - NORMAL_DIAGONAL;
            double z = min.Z + getSeparacionDiagonalVertical();
            return new T3D.Point(x, y, z);
        }
    }
}
