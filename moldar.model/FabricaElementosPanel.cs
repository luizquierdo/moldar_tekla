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
    public class FabricaElementosPanel
    {
        public static SingleRebar createDiagonal(T3D.Point p1, T3D.Point p2, double diametro)
        {
            SingleRebar rebar = crearBarra(p1, p2, diametro);
            rebar.Name = "DIAGONAL";
            return rebar;
        }

        public static SingleRebar createBarraLongitudinal(T3D.Point p1, T3D.Point p2, double diametro)
        {
            SingleRebar rebar = crearBarra(p1, p2, diametro);
            rebar.Name = "BARRA_VIGUETA";
            return rebar;
        }

        public static Beam createTubo(T3D.Point p1, T3D.Point p2)
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

        private static SingleRebar crearBarra(T3D.Point p1, T3D.Point p2, double diametro)
        {
            SingleRebar rebar = new SingleRebar();
            rebar.Polygon.Points.Add(p1);
            rebar.Polygon.Points.Add(p2);
            addRebarSettings(rebar, diametro);
            return rebar;
        }

        private static void addRebarSettings(SingleRebar rebar, double diametro)
        {
            rebar.RadiusValues.Add(40.0);
            rebar.Class = 3;
            rebar.Size = "" + diametro;
            rebar.NumberingSeries.StartNumber = 0;
            rebar.Grade = "Undefined";
        }        
    }
}
