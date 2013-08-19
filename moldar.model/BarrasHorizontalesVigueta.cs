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
    public class BarrasHorizontalesVigueta : BarrasLongitudinalesVigueta
    {
        public BarrasHorizontalesVigueta(Beam muro, double dx, double dy)
            : base(muro, dx, dy)
        {
        }

        protected override T3D.Point getPartidaBarra1()
        {
            double x = min.X - adicionalIzquierda;
            double y = getYHorizontal();   
            double z = min.Z + ANCHO_VIGUETA_HORIZONTAL + getSeparacionDiagonalHorizontal();
            return new T3D.Point(x, y, z);
        }

        protected override T3D.Point getFinalBarra1()
        {
            double x = max.X + adicionalDerecha;
            double y = getYHorizontal();
            double z = min.Z + ANCHO_VIGUETA_HORIZONTAL + getSeparacionDiagonalHorizontal();
            return new T3D.Point(x, y, z);
        }

        protected override T3D.Point getPartidaBarra2()
        {
            double x = min.X - adicionalIzquierda;
            double y = getYHorizontal();
            return new T3D.Point(x, y, min.Z + getSeparacionDiagonalHorizontal());
        }

        protected override T3D.Point getFinalBarra2()
        {
            double x = max.X + adicionalDerecha;
            double y = getYHorizontal();
            return new T3D.Point(x, y, min.Z + getSeparacionDiagonalHorizontal());
        }
    }
}
