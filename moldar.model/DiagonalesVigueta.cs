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
    public abstract class DiagonalesVigueta : Vigueta, ComponentePanel
    {
        public DiagonalesVigueta(Beam muro, double dx, double dy)
            : base(muro, dx, dy)
        {
        }

        protected double getYHorizontal()
        {
            return max.Y + TubosVigueta.DIAMETRO / 2 + diametroBarras + diametroDiagonal / 2 - dy;
        }

        protected double getXVertical()
        {
            return min.X + TubosVigueta.DIAMETRO / 2 + diametroBarras + diametroDiagonal / 2 + dx;
        }

        public override void fabricar()
        {
            double avance = getPartidaAvance();

            while (crearSiguienteElemento(avance))
            {
                T3D.Point p1 = getPuntoInicial(avance);
                T3D.Point p2 = getPuntoFinal(avance);

                SingleRebar diagonal = FabricaBarras.createDiagonal(p1, p2, diametroDiagonal);
                diagonal.Father = muro;
                diagonal.Insert();

                avance -= 400.0;
            }
        }

        public abstract bool crearSiguienteElemento(double avance);

        public abstract double getPartidaAvance();

        public abstract T3D.Point getPuntoInicial(double avance);

        public abstract T3D.Point getPuntoFinal(double avance);
    }
}
