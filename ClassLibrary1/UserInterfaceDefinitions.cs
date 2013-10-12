using System;
using System.Collections.Generic;
using Tekla.Structures.Plugins;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;
using TSM = Tekla.Structures.Model;

namespace pluginmoldar
{
    class UserInterfaceDefinitions
    {
        public const string interfazPlugin1 = @"" +
           @"page(""TeklaStructures"","""")" + "\n" +
            "{\n" +
            "    plugin(1, Panel Moldar)\n" +
            "    {\n" +
           @"        tab_page(""Panel"", ""Parametri_1"", 1)" + "\n" +
            "        {\n" +
           @"            parameter(""Distancia Horizontal"", ""P1"", distance, number, 1)" + "\n" +
           @"            parameter(""Distancia Vertical"", ""P2"", distance, number, 2)" + "\n" +
           @"            parameter(""Diametro Barras"", ""P3"", distance, number, 3)" + "\n" +
           @"            parameter(""Diametro Diagonales"", ""P4"", distance, number, 4)" + "\n" +
           @"            parameter(""Largo Superior"", ""P5"", distance, number, 5)" + "\n" +
           @"            parameter(""Largo Inferior"", ""P6"", distance, number, 6)" + "\n" +
           @"            parameter(""Largo Izquierda"", ""P7"", distance, number, 7)" + "\n" +
           @"            parameter(""Largo Derecha"", ""P8"", distance, number, 8)" + "\n" +
            "        }\n" +
            "    }\n" +
            "}\n";
    }
}
