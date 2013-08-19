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
    public class Vigueta : ComponenteMoldarRaiz, ComponentePanel
    {
        public Vigueta(Beam muro, double dx, double dy) : base(muro, dx, dy)
        { 
        }

        protected double getSeparacionDiagonalVertical()
        {
            return (max.Z - min.Z - ANCHO_VIGUETA_HORIZONTAL) / 2;
        }

        protected double getSeparacionDiagonalHorizontal()
        {
            return (max.Z - min.Z - ANCHO_VIGUETA_HORIZONTAL + 2 * diametroBarras) / 2;
        }
    }    
}
