using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallelepipede
{
    internal class Rectangle : Parallelepipede
    {
		private double _longueur;

		private double _largeur;

		public double Largeur
		{
			get { return _largeur; }
		}

		public double Longueur
		{
			get { return _longueur; }
		}

		public Rectangle(double longueur, double largeur, string couleur) : base(couleur)
        {
			_longueur = longueur;
			_largeur = largeur;
        }

		override public double CalculerSurface()
		{
			return _longueur * _largeur;
        }

		override public double CalculerPerimetre()
		{
			return 2 * (_longueur + _largeur);
		}

		override public string Infos()
		{
			return $"Rectangle de longueur {_longueur} et de largeur {_largeur} de couleur {Couleur}";
        }
    }
}
