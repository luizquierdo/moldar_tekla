using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace moldar
{
    public class ParametrosPanel
    {
        private double _diametroDiagonal;
        private double _diametroBarras;
        private double _dx;
        private double _dy;
        private double _adicionalIzquierda;
        private double _adicionalDerecha;
        private double _adicionalSuperior;
        private double _adicionalInferior;

        private Beam _muro;
        private T3D.Point _max, _min;

        public ParametrosPanel(Beam muro)
        { 
            _muro = muro;
            _max = muro.GetSolid().MaximumPoint;
            _min = muro.GetSolid().MinimumPoint;
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

        public double adicionalSuperior
        {
            get { return _adicionalSuperior; }
            set { _adicionalSuperior = value; }
        }

        public double adicionalInferior
        {
            get { return _adicionalInferior; }
            set { _adicionalInferior = value; }
        }

        public T3D.Point max
        {
            get { return _max; }
        }

        public T3D.Point min
        {
            get { return _min; }
        }

        public Beam muro
        {
            get { return _muro; }
        }

    }
}
