using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT11
{
    internal class Academie
    {
		private string _nom;

		public string Nom
		{
			get { return _nom; }
		}

		private List<Ecole> _listeEcole;

		public int ListeEcole
		{
			get { return _listeEcole.Count; }
        }

		public Academie(string nom)
		{
			_nom = nom;
			_listeEcole = new List<Ecole>();
        }


        public void AjouterEcole(Ecole ecole)
		{
			_listeEcole.Add(ecole);
        }

		public string AfficherEcoles()
		{
			string result = "Liste des écoles de l'académie :\n";
            foreach (Ecole ecole in _listeEcole)
			{
				result += "- " + ecole.CodeEcole + "\n";
            }
			return result;
        }
    }
}
