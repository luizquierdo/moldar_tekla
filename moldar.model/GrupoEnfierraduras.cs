using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace moldar
{
    abstract class GrupoEnfierraduras : ComponentePanel
    {
        protected Beam muro;
        protected ArrayList poligonos;
        protected T3D.Point max, min;
        protected double spacing = 400.0;
        protected double fromPlane = 0;

        public GrupoEnfierraduras(Beam muro)
        {
            this.muro = muro;
            max = muro.GetSolid().MaximumPoint;
            min = muro.GetSolid().MinimumPoint;
            poligonos = new ArrayList();
        }

        public virtual void fabricar()
        {
            crearPoligonos();

            RebarGroup rg = new RebarGroup();

            rg.Polygons = poligonos;

            addRebarGroupSettings(rg);

            rg.Father = muro;

            rg.Insert();
        }

        public abstract void crearPoligonos();

        protected void addRebarGroupSettings(RebarGroup rg)
        {
            rg.RadiusValues.Add(40.0);
            rg.SpacingType = RebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_EXACT_SPACE_FLEX_AT_END;
            rg.Spacings.Add(400.0);
            rg.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_BOTH;
            rg.Name = "diagonales";
            rg.Class = 3;
            rg.Size = "8.0";
            rg.NumberingSeries.StartNumber = 0;
            rg.Grade = "Undefined";
            rg.FromPlaneOffset = fromPlane;
        }
    }
}
