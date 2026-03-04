using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallelepipede
{
    public abstract class Parallelepipede
    {
		protected string _couleur;

		public string Couleur
		{
			get { return _couleur; }
		}

		public Parallelepipede(string couleur)
		{
			_couleur = couleur;
        }

        public abstract double CalculerSurface();

		public abstract double CalculerPerimetre();

		public abstract string Infos();
    }
}
