using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT_3_HéritageExempleDesVéhicules
{
	internal class Velo : Vehicule
	{
		private Boolean _estElectrique;
		public Boolean EstElectrique
		{
			get { return _estElectrique; }
			set { _estElectrique = value; }
		}


		private string _type;
		public string Type
		{
			get { return _type; }
			set { _type = value; }
		}

		public Velo(string marque, string modele, string couleur, decimal prix, string type, Boolean estElectrique) : base(marque, modele, couleur, prix)
		{
			_type = type;
			_estElectrique = estElectrique;
		}
		public override string Affiche()
		{
			return $"Marque: {Marque}, Modèle: {Modele}, Couleur: {Couleur}, Prix: {Prix} Euros, Type: {Type}, Électrique: {EstElectrique}";
		}
	}
}
