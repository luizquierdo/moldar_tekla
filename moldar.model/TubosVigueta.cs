using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace moldar
{
    public class TubosVigueta : Vigueta, ComponentePanel
    {

        public const double DIAMETRO = 13;

        public TubosVigueta(Beam muro, double dx, double dy)
            : base(muro, dx, dy)
        {
        }

        public override void fabricar()
        {
            double y = max.Y - dy;
            while (y > min.Y)
            {
                T3D.Point p1 = new T3D.Point(min.X - DIAMETRO / 2 + dx, y, min.Z + 15);
                T3D.Point p2 = new T3D.Point(min.X - DIAMETRO / 2 + dx, y, max.Z - 15);

                Beam tubo = createTubo(p1, p2);
                tubo.Insert();
                muro.GetAssembly().GetSubAssemblies().Add(tubo.GetAssembly());

                y -= 400.0;
            }
        }

        private Beam createTubo(T3D.Point p1, T3D.Point p2)
        {
            Beam tubo = new Beam(Beam.BeamTypeEnum.BEAM);
            tubo.Profile.ProfileString = "O13*1";
            tubo.Name = "TUBO";
            tubo.Material.MaterialString = "S235JR";
            tubo.Class = "2";
            tubo.StartPoint = p1;
            tubo.EndPoint = p2;
            return tubo;
        }
    }
}
