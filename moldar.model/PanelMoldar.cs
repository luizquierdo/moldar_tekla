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
    public class PanelMoldar : ComponentePanel {

        private double avanceX, avanceY = 0;
        private ParametrosPanel p;
        private ConjuntoPlacas _placas;

        public PanelMoldar(ParametrosPanel p)
        {
            this.p = p;

            if (this._placas == null)
            {
                this._placas = new ConjuntoPlacas(p);
            }
        }

        public void fabricar()
        {
            placas.fabricar();

            p.dx = this.distanciaXPrimerConector();            

            avanceX = p.dx;
            avanceY = p.dy;

            // aquí creo la vigueta horizontal superior
            new ViguetaHorizontal(p, avanceY).fabricar();

            // bajo en saltos de 400mm todo lo que puedo sin salirme del panel
            while (avanceY + 400 < 2 * p.max.Y)
            {
                avanceY += 400.0;
            }

            // creo la vigueta horizontal inferior
            new ViguetaHorizontal(p, avanceY).fabricar();

            avanceY = p.dy;
            avanceX = p.dx;
            while (avanceX < p.max.X)
            {
                ComponentePanel vVertical = new ViguetaVertical(p, avanceX);
                vVertical.fabricar();
                avanceX += 400.0;
            }            
        }
       
        public ConjuntoPlacas placas
        {
            get { return this._placas; }
            set { this._placas = value; }
        }

        public double distanciaXPrimerConector()
        {
            double largoPlacas = _placas.largoPrimeraYUltimaPlaca();

            if (largoPlacas > 400)
            {
                return largoPlacas - 400;
            }
            else
            {
                return largoPlacas;
            }
        }
    }
}
