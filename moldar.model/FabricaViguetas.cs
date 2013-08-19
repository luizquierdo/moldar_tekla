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
    class FabricaViguetas
    {
        public static Vigueta fabricarViguetaHorizontal(Beam muro, double X, double Y, double dBarras, double dDiagonal)
        {
            Vigueta vigueta = new Vigueta(muro, X, Y);
            vigueta.diametroBarras = dBarras;
            vigueta.diametroDiagonal = dDiagonal;

            DiagonalesHorizontalIzqDer diagonalesHorizontalesIzqDer = new DiagonalesHorizontalIzqDer(muro, X, Y);
            diagonalesHorizontalesIzqDer.diametroDiagonal = dDiagonal;
            diagonalesHorizontalesIzqDer.diametroBarras = dBarras;

            DiagonalesHorizontalDerIzq diagonalesHorizontalesDerIzq = new DiagonalesHorizontalDerIzq(muro, X, Y);
            diagonalesHorizontalesDerIzq.diametroDiagonal = dDiagonal;
            diagonalesHorizontalesDerIzq.diametroBarras = dBarras;

            BarrasHorizontalesVigueta barrasHorizontales = new BarrasHorizontalesVigueta(muro, X, Y);
            barrasHorizontales.diametroBarras = dBarras;

            vigueta.addComponente(diagonalesHorizontalesIzqDer);
            vigueta.addComponente(diagonalesHorizontalesDerIzq);
            vigueta.addComponente(barrasHorizontales);

            return vigueta;
        }

        public static Vigueta fabricarViguetaVertical(Beam muro, double X, double Y, double dBarras, double dDiagonal)
        {
            Vigueta vigueta = new Vigueta(muro, X, Y);
            vigueta.diametroBarras = dBarras;
            vigueta.diametroDiagonal = dDiagonal;

            DiagonalesVerticalIzqDer diagonalesVerticalesIzqDer = new DiagonalesVerticalIzqDer(muro, X, Y);
            diagonalesVerticalesIzqDer.diametroDiagonal = dDiagonal;
            diagonalesVerticalesIzqDer.diametroBarras = dBarras;

            DiagonalesVerticalDerIzq diagonalesVerticalesDerIzq = new DiagonalesVerticalDerIzq(muro, X, Y);
            diagonalesVerticalesDerIzq.diametroDiagonal = dDiagonal;
            diagonalesVerticalesDerIzq.diametroBarras = dBarras;

            BarrasVerticalesVigueta barrasVerticales = new BarrasVerticalesVigueta(muro, X, Y);
            barrasVerticales.diametroBarras = dBarras;

            TubosVigueta tubosVigueta = new TubosVigueta(muro, X, Y);

            vigueta.addComponente(diagonalesVerticalesIzqDer);
            vigueta.addComponente(diagonalesVerticalesDerIzq);
            vigueta.addComponente(tubosVigueta);
            vigueta.addComponente(barrasVerticales);

            return vigueta;
        }
    }
}
