using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnes
{
    internal class Personnage
    {
		private string _nom;
		private int _argent;

		public int Argent
		{
			get { return _argent; }
			set { _argent = value; }
		}

		public string Nom
		{
			get { return _nom; }
			set { _nom = value; }
		}

		public Personnage(string nom, int argent)
		{
			_nom = nom;
			_argent = argent;
        }

		public bool donnerArgent(int montant)
		{
			if (montant > _argent)
			{
				Console.WriteLine($"{_nom} n'a pas assez d'argent pour donner {montant}.");
				return false;
			}
			else
			{
				_argent -= montant;
				return true;
            }
		}

		public void recevoirArgent(int montant)
		{
			_argent += montant;
		}

		public void ajouterArgent(int montant)
		{
			_argent += montant;
        }
    }
}
