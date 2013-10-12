using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace moldar
{
    public class Placa : ComponentePanel
    {
        Beam beam = new Beam(Beam.BeamTypeEnum.COLUMN);
        Beam muro;

        private int _alto = 2440;

        public Placa(T3D.Point sp, T3D.Point ep, Beam muro, int alto)
        {
            this.muro = muro;

            this._alto = alto;
            beam.StartPoint = sp;
            beam.EndPoint = ep;

            beam.Name = "Placa Fenolica";
            beam.Profile.ProfileString = "PLT18*" + _alto;
            // Color naranja...
            beam.Class = "13";
            beam.Position.Rotation = Position.RotationEnum.BACK;
            beam.Position.RotationOffset = 0;

            beam.Material.MaterialString = "Wood";
            beam.Finish = "PAINT";
        }

        public void insert()
        {
            beam.Insert();
            Assembly a = muro.GetAssembly();
            a.GetSubAssemblies().Add(beam.GetAssembly());
            a.Modify();
        }

        public void fabricar()
        {
        }

        public int alto 
        {
            get { return _alto; }
            set { _alto = value; }
        }
    }
}
