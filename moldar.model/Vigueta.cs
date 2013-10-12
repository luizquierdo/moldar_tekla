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
    public abstract class Vigueta : ComponentePanel
    {
        public const double ANCHO_VIGUETA_HORIZONTAL = 100;
        public const double NORMAL_DIAGONAL = 150;
        public const double DISTANCIA_A_TUBO = 18;
        public const double DIAMETRO_TUBO = 13;

        protected ParametrosPanel p;
        protected double offset;

        public Vigueta(ParametrosPanel p, double offset)  
        {
            this.p = p;
            this.offset = offset;
        }

        public abstract void fabricar();

    }    
}
