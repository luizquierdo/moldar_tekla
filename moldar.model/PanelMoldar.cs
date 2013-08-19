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
    public class PanelMoldar : ComponenteMoldarRaiz {

        private double avanceX, avanceY = 0;

        public PanelMoldar(Beam muro) : base(muro)
        {
            componentes = new ArrayList();            
        }

        public void inicializarComponentes()
        {
            avanceX = dx;
            avanceY = dy;

            Vigueta viguetaSuperior = FabricaViguetas
                .fabricarViguetaHorizontal(muro, avanceX, avanceY, diametroBarras, diametroDiagonal);

            addComponente(viguetaSuperior);

            while (avanceY + 400 < 2 * max.Y)
            {
                avanceY += 400.0;
            }

            Vigueta viguetaInferior = FabricaViguetas
                .fabricarViguetaHorizontal(muro, avanceX, avanceY, diametroBarras, diametroDiagonal);

            addComponente(viguetaInferior);            

            avanceY = dy;
            avanceX = dx;
            while (avanceX < max.X)
            {
                Vigueta vVertical = FabricaViguetas.fabricarViguetaVertical(muro, avanceX, avanceY, diametroBarras, diametroDiagonal);
                addComponente(vVertical);
                avanceX += 400.0;
            }
        }
    }
}
