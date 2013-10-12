using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace moldar
{
    public class ConjuntoPlacas : ComponentePanel
    {
        private double avanceY, avanceX = 0;
        private ParametrosPanel p;
        private double _largoPrimeraPlaca;
        private double _largoUltimaPlaca;
        private double _largoPlacaEntera; // si las placas se colocan verticalmente, debiese ser 1200. Sino 2400
        private double _alto1Corrida;
        private double _alto2Corrida;
        private double _alto3Corrida;
        private double _dyPlacas; // cota superior de la placa más alta
        private double _dxPlacas; // plomo de partida de la placa de más a la izquierda

        public ConjuntoPlacas(ParametrosPanel p)
        {
            this.p = p;
            if (p.dx == 0)
            {
                _largoPrimeraPlaca = largoPrimeraYUltimaPlaca();
            }
            else
            {
                _largoPrimeraPlaca = p.dx;
            }
        }

        public void fabricar()
        {
             avanceY = p.max.Y - p.dy;

            while (avanceY > p.min.Y)
            {
                avanceX = 0;
                int alto = (int)Math.Min(Math.Abs(avanceY - p.min.Y), 2400.0);

                while (avanceX < p.max.X)
                {
                    // el largo de las placas en general es 1200
                    double largoPlaca = Math.Min(p.max.X - avanceX, 1200);
                    // la primera placa (avanceX == 0) puede ser menor
                    if (avanceX == 0 && _largoPrimeraPlaca > 0) largoPlaca = _largoPrimeraPlaca;

                    T3D.Point p1 = new T3D.Point(avanceX, avanceY - alto / 2, p.max.Z + 18);
                    T3D.Point p2 = new T3D.Point(avanceX + largoPlaca, avanceY - alto / 2, p.max.Z + 18);
                    Placa placa = new Placa(p1, p2, p.muro, alto);

                    T3D.Point p3 = new T3D.Point(avanceX, avanceY - alto / 2, p.min.Z);
                    T3D.Point p4 = new T3D.Point(avanceX + largoPlaca, avanceY - alto / 2, p.min.Z);
                    Placa placa2 = new Placa(p3, p4, p.muro, alto);

                    placa.insert();
                    placa2.insert();

                    // en la primera placa hay que avanzar p.dx. En las demás hay que avanzar 1200
                    if (avanceX == 0 && _largoPrimeraPlaca > 0) avanceX += _largoPrimeraPlaca;
                    else avanceX += 1200;
                }

                avanceY -= 2400;
            }        
        }

        public double largoPrimeraYUltimaPlaca()
        {
            double largoPanel = p.max.X - p.min.X;
            double numeroPlacas = largoPanel / 1200;
            int enteroPlacas = (int)numeroPlacas;
            double alternativaA = (numeroPlacas - enteroPlacas) * 600;

            if (alternativaA > 400 || alternativaA < 1) return alternativaA;

            return alternativaA + 600;
        }
    }
}
