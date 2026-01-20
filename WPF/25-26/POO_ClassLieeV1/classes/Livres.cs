using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ClassLieeV1
{
    internal class Livres
    {
		private string _titre;

		private string _auteur;

		private int _etat;

		public int Etat
		{
			get { return _etat; }
			set { _etat = value; }
		}

		public string Auteur
		{
			get { return _auteur; }
			set { _auteur = value; }
		}

		public string Titre
		{
			get { return _titre; }
			set { _titre = value; }
        }

		public Livres(string titre, string auteur, int etat)
		{
			_titre = titre;
			_auteur = auteur;
			_etat = etat;
        }

		public void degrade()
		{
			_etat--;
        }

		public string description()
		{
			string desc = $"Le livre { _titre } de l'auteur { _auteur } est dans un état de {_etat}/5";
			return desc;
        }

    }
}
