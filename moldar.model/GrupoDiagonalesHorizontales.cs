using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace moldar
{
    class GrupoDiagonalesHorizontales : GrupoDiagonales, ComponentePanel
    {
        public GrupoDiagonalesHorizontales(Beam muro) : base(muro)
        {
            zmax = max.Z - 38;
            zmin = min.Z + 38;
            ancho = max.X - min.X;
        }

        public override Polygon crearPoligono1()
        {
            Polygon p1 = new Polygon();
            p1.Points.Add(new T3D.Point(max.X - 400 - paso, min.Y, zmax));
            p1.Points.Add(new T3D.Point(max.X - 400 + 30 - paso, min.Y, zmax));
            p1.Points.Add(new T3D.Point(max.X - 30 - paso, min.Y, zmin));
            p1.Points.Add(new T3D.Point(max.X - paso, min.Y, zmin));
            return p1;
        }

        public override Polygon crearPoligono2()
        {
            Polygon p2 = new Polygon();
            p2.Points.Add(new T3D.Point(max.X - 400 - paso, max.Y, zmax));
            p2.Points.Add(new T3D.Point(max.X - 400 + 30 - paso, max.Y, zmax));
            p2.Points.Add(new T3D.Point(max.X - 30 - paso, max.Y, zmin));
            p2.Points.Add(new T3D.Point(max.X - paso, max.Y, zmin));
            return p2;
        }
    }
}
