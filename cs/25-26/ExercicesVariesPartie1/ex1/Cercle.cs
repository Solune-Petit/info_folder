using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    internal class Cercle
    {
		private decimal _rayon;
		public decimal Rayon
		{
			get { return _rayon; }
			set { _rayon = value; }
		}

		public Cercle(decimal rayon)
		{
			_rayon = rayon;
        }

		public decimal CalculerAire()
		{
            //calculer l'aire du cercle
			return (decimal)(Math.PI * Math.Pow((double)_rayon, 2));
        }

		public decimal CalculerPerimetre()
		{
            //calculer le périmètre du cercle
			return (decimal)(2 * Math.PI * (double)_rayon);
        }

		public string AfficherDetails()
		{
			return $"Cercle de rayon {_rayon}: Aire = {CalculerAire()}, Périmètre = {CalculerPerimetre()}";
        }

    }
}
