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
    public abstract class BarrasLongitudinalesVigueta : Vigueta, ComponentePanel
    {
        public BarrasLongitudinalesVigueta(Beam muro, double dx, double dy)
            : base(muro, dx, dy)
        {
        }

        protected double getYHorizontal()
        {
            return max.Y + TubosVigueta.DIAMETRO / 2 + diametroBarras / 2 - dy;
        }

        protected double getXVertical()
        {
            return min.X + TubosVigueta.DIAMETRO / 2 + diametroBarras / 2 + dx;
        }

        public override void fabricar()
        {
            T3D.Point p1 = getPartidaBarra1();
            T3D.Point p2 = getFinalBarra1();
            T3D.Point p3 = getPartidaBarra2();
            T3D.Point p4 = getFinalBarra2();

            SingleRebar barra1 = FabricaBarras.createBarraLongitudinal(p1, p2, diametroBarras);
            SingleRebar barra2 = FabricaBarras.createBarraLongitudinal(p3, p4, diametroBarras);

            barra1.Father = muro;
            barra2.Father = muro;

            barra1.Insert();
            barra2.Insert();
        }

        protected abstract T3D.Point getPartidaBarra1();

        protected abstract T3D.Point getFinalBarra1();

        protected abstract T3D.Point getPartidaBarra2();

        protected abstract T3D.Point getFinalBarra2();
    }
}
