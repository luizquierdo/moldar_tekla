using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace moldar
{
    class GrupoDiagonalesVerticales : GrupoDiagonales, ComponentePanel
    {        

        public GrupoDiagonalesVerticales(Beam muro)
            : base(muro)
        {
            zmax = max.Z - 30;
            zmin = min.Z + 30;
            ancho = max.Y - min.Y;
        }

        public override Polygon crearPoligono1()
        {
            Polygon p1 = new Polygon();
            p1.Points.Add(new T3D.Point(min.X, max.Y - 400 - paso, zmax));
            p1.Points.Add(new T3D.Point(min.X, max.Y - 400 + 30 - paso, zmax));
            p1.Points.Add(new T3D.Point(min.X, max.Y - 30 - paso, zmin));
            p1.Points.Add(new T3D.Point(min.X, max.Y - paso, zmin));
            return p1;
        }

        public override Polygon crearPoligono2()
        {
            Polygon p2 = new Polygon();
            p2.Points.Add(new T3D.Point(max.X, max.Y - 400 - paso, zmax));
            p2.Points.Add(new T3D.Point(max.X, max.Y - 400 - paso + 30, zmax));
            p2.Points.Add(new T3D.Point(max.X, max.Y - 30 - paso, zmin));
            p2.Points.Add(new T3D.Point(max.X, max.Y - paso, zmin));
            return p2;
        }
    }
}
