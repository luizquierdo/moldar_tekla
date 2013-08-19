using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace moldar
{
    public class Placa
    {
        public Beam create(T3D.Point sp, T3D.Point ep)
        {
            Beam beam = new Beam(Beam.BeamTypeEnum.COLUMN);

            beam.StartPoint = sp;
            beam.EndPoint = ep;

            beam.Name = "Placa Fenolica";
            beam.Profile.ProfileString = "PLT18*2400";
            // Color naranja...
            beam.Class = "13";
            beam.Position.Rotation = Position.RotationEnum.TOP;
            beam.Position.RotationOffset = 180;

            beam.Material.MaterialString = "Wood";
            beam.Finish = "PAINT";

            return beam;
        }  
    }
}
