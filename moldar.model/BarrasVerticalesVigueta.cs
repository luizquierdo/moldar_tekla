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
    public class BarrasVerticalesVigueta : BarrasLongitudinalesVigueta
    {
        public BarrasVerticalesVigueta(Beam muro, double dx, double dy)
            : base(muro, dx, dy)
        {
        }

        protected override T3D.Point getPartidaBarra1()
        {
            double x = getXVertical();
            double y = min.Y;
            double z = min.Z + ANCHO_VIGUETA_HORIZONTAL + getSeparacionDiagonalVertical();
            return new T3D.Point(x, y, z);
        }

        protected override T3D.Point getFinalBarra1()
        {
            double x = getXVertical();
            double y = max.Y;
            double z = min.Z + ANCHO_VIGUETA_HORIZONTAL + getSeparacionDiagonalVertical();
            return new T3D.Point(x, y, z);
        }

        protected override T3D.Point getPartidaBarra2()
        {
            return new T3D.Point(getXVertical(), min.Y, min.Z + getSeparacionDiagonalVertical());
        }

        protected override T3D.Point getFinalBarra2()
        {
            return new T3D.Point(getXVertical(), max.Y, min.Z + getSeparacionDiagonalVertical());
        }
    }
}
