using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT_3_HéritageExempleDesVéhicules
{
    internal class Voiture : Vehicule
    {
		private bool _gps;
		public bool Gps
		{
			get { return _gps; }
			set { _gps = value; }
		}


		private string _motorisation;
		public string Motorisation
		{
			get { return _motorisation; }
			set { _motorisation = value; }
		}

		public Voiture(string marque, string modele, string couleur, decimal prix, string motorisation,  bool gps) : base(marque, modele, couleur, prix)
		{
			_motorisation = motorisation;
			_gps = gps;
        }

        public override string Affiche()
		{
			return $"{base.Affiche()}, Motorisation: {Motorisation}, GPS: {Gps}";
        }
    }
}
