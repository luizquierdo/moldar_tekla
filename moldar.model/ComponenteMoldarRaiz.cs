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
    public abstract class ComponenteMoldarRaiz : ComponentePanel
    {

        protected Beam muro;
        protected ArrayList componentes;
        protected T3D.Point max, min;
        
        protected const double ANCHO_VIGUETA_HORIZONTAL = 100.0;
        protected const double NORMAL_DIAGONAL = 150.0;
        protected const double DISTANCIA_A_TUBO = 18.0;

        private double _diametroDiagonal;
        private double _diametroBarras;
        private double _dx;
        private double _dy;
        private double _adicionalIzquierda;
        private double _adicionalDerecha;
        private double _adicionalSuperior;
        private double _adicionalInferior;

        public ComponenteMoldarRaiz(Beam muro)
        {
            inicializarConstructor(muro);
        }

        public ComponenteMoldarRaiz(Beam muro, double dx, double dy)
        {
            inicializarConstructor(muro);

            _dx = dx;
            _dy = dy;            
        }

        private void inicializarConstructor(Beam muro)
        {
            this.muro = muro;

            max = muro.GetSolid().MaximumPoint;
            min = muro.GetSolid().MinimumPoint;

            componentes = new ArrayList();  
        }

        public void addComponente(ComponentePanel componente)
        {
            componentes.Add(componente);
        }

        public virtual void fabricar()
        {
            for (int i = 0; i < componentes.Count; i++)
            {
                ((ComponentePanel)componentes[i]).fabricar();
            }
        }

        public double dx
        {
            get { return _dx; }
            set { _dx = value; }
        }

        public double dy
        {
            get { return _dy; }
            set { _dy = value; }
        }

        public double diametroDiagonal
        {
            get { return _diametroDiagonal; }
            set { _diametroDiagonal = value; }
        }

        public double diametroBarras
        {
            get { return _diametroBarras; }
            set { _diametroBarras = value; }
        }

        public double adicionalDerecha
        {
            get { return _adicionalDerecha; }
            set { _adicionalDerecha = value; }
        }

        public double adicionalIzquierda
        {
            get { return _adicionalIzquierda; }
            set { _adicionalIzquierda = value; }
        }
    }
}
