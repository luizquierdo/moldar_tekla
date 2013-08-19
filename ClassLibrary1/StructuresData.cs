using System;
using System.Collections.Generic;
using Tekla.Structures.Plugins;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;
using TSM = Tekla.Structures.Model;


namespace pluginmoldar
{
    public class StructuresData
    {
        [Tekla.Structures.Plugins.StructuresField("P1")]
        public double dx;

        [Tekla.Structures.Plugins.StructuresField("P2")]
        public double dy;

        [Tekla.Structures.Plugins.StructuresField("P3")]
        public double diametroBarras;

        [Tekla.Structures.Plugins.StructuresField("P4")]
        public double diametroDiagonales;

    }
}
