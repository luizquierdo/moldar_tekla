using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tekla.Structures.Model;

namespace moldar
{
    abstract class GrupoDiagonales : GrupoEnfierraduras
    {

        protected double zmax, zmin;
        protected double paso = 0;
        protected double ancho;

        public GrupoDiagonales(Beam muro)
            : base(muro)
        {
        }

        public override void fabricar()
        {
            base.spacing = 800.0;

            for (paso = 0; paso < ancho; paso += 400)
            {
                base.fabricar();
            }

            double tmp = zmax;
            zmax = zmin;
            zmin = tmp;

            base.fromPlane = 400.0;

            for (paso = 0; paso < ancho; paso += 400)
            {
                base.fabricar();
            }
        }

        public override void crearPoligonos()
        {
            base.poligonos = new System.Collections.ArrayList();
            base.poligonos.Add(crearPoligono1());
            poligonos.Add(crearPoligono2());
        }

        public abstract Polygon crearPoligono1();

        public abstract Polygon crearPoligono2();
    }
}
