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
    public class DiagonalesHorizontalIzqDer : DiagonalesVigueta, ComponentePanel
    {

        public DiagonalesHorizontalIzqDer(Beam muro, double dx, double dy)
            : base(muro, dx, dy)
        {
        }

        public override bool crearSiguienteElemento(double avance)
        {
            return (-avance + NORMAL_DIAGONAL < max.X);
        }

        public override double getPartidaAvance()
        {
            return -(min.X + dx + DISTANCIA_A_TUBO);
        }

        public override T3D.Point getPuntoInicial(double avance)
        {
            double x = -avance;
            double y = getYHorizontal(); 
            double z = min.Z + getSeparacionDiagonalHorizontal();

            return new T3D.Point(x, y, z);
        }

        public override T3D.Point getPuntoFinal(double avance)
        {
            double x = -avance + NORMAL_DIAGONAL;
            double y = getYHorizontal();
            double z = min.Z + ANCHO_VIGUETA_HORIZONTAL + getSeparacionDiagonalHorizontal();

            return new T3D.Point(x, y, z);
        }  
    }
}
