using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT11
{
    internal class Salle
    {
		private string _nom;

		public string Nom
		{
			get { return _nom; }
			set { _nom = value; }
		}

		private int _nombrePlaces;

		public int NombrePlaces
		{
			get { return _nombrePlaces; }
			set { _nombrePlaces = value; }
		}


		public Salle(string nom, int nombrePlaces)
		{
			_nom = nom;
			_nombrePlaces = nombrePlaces;
		}

		public string Infos()
		{
			return $"{_nom}; {_nombrePlaces}";
		}
    }
}
