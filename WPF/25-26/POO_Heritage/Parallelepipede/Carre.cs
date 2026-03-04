using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallelepipede
{
    internal class Carre : Parallelepipede
    {
        private double _cote;

        public double Cote
        {
            get { return _cote; }
        }

        public Carre(double cote, string couleur) : base(couleur)
        {
            _cote = cote;
        }

        override public double CalculerSurface()
        {
            return _cote*_cote;
        }

        override public double CalculerPerimetre()
        {
            return 2 * _cote;
        }

        override public string Infos()
        {
            return $"Carré de longueur/largeur {_cote} et de couleur {Couleur}";
        }
    }
}
