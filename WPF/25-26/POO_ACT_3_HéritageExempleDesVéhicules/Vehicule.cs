using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT_3_HéritageExempleDesVéhicules
{
    internal class Vehicule
    {
		protected decimal _prix;
		public decimal Prix
		{
			get { return _prix; }
			set { _prix = value; }
        }


		protected string _couleur;
		public string Couleur
		{
			get { return _couleur; }
			set { _couleur = value; }
		}


		protected string _marque;
		public string Marque
		{
			get { return _marque; }
		}


		protected string _modele;
		public string Modele
		{
			get { return _modele; }
		}

		public Vehicule(string marque, string modele, string couleur, decimal prix)
		{
			_marque = marque;
			_modele = modele;
			_couleur = couleur;
			_prix = prix;
        }

        public virtual string Affiche()
		{
			return $"Marque: {Marque}, Modèle: {Modele}, Couleur: {Couleur}, Prix: {Prix} Euros";
        }
    }
}
