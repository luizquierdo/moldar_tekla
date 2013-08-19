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
    class GrupoBarrasHorizontales : GrupoEnfierraduras, ComponentePanel
    {
        private double z;

        public GrupoBarrasHorizontales(Beam muro)
            : base(muro)
        {
        }

        public override void fabricar()
        {
            z = muro.GetSolid().MaximumPoint.Z - 38;
            base.fabricar();

            z = muro.GetSolid().MinimumPoint.Z + 38;
            base.fabricar();
        }

        public override void crearPoligonos()
        {

            Polygon p1 = new Polygon();
            p1.Points.Add(new T3D.Point(max.X, min.Y, z));
            p1.Points.Add(new T3D.Point(min.X, min.Y, z));
            base.poligonos.Add(p1);

            Polygon p2 = new Polygon();
            p2.Points.Add(new T3D.Point(max.X, max.Y, z));
            p2.Points.Add(new T3D.Point(min.X, max.Y, z));
            base.poligonos.Add(p2);

        }
    }
}
