using POO_ClassLieeV1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLieeV2.classes
{
    internal class Abonne
    {
		private string _nom;
		private List <Livres> _emprunt;

		public List <Livres> Emprunt
		{
			get { return _emprunt; }
			set { _emprunt = value; }
		}

		public string Nom
		{
			get { return _nom; }
		}

		public Abonne (string nom)
		{
			_nom = nom;
        }

		public void emprunter (Livres livre)
		{
			_emprunt.Add(livre);
        }
    }
}
