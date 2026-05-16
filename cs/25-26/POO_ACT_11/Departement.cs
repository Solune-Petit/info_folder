using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT11
{
    internal class Departement
    {
		private string _nom;

		public string Nom
		{
			get { return _nom; }
		}

		private List<Enseignant> _listeEnseignant;

		public List<Enseignant> ListeEnseignant
		{
			get { return _listeEnseignant; }
			set { _listeEnseignant = value; }
		}

		private List<Matiere> _listeMatiere;

		public List<Matiere> ListeMatiere
		{
			get { return _listeMatiere; }
			set { _listeMatiere = value; }
		}


		public Departement(string nom)
		{
			_nom = nom;
			_listeEnseignant = new List<Enseignant>();
			_listeMatiere = new List<Matiere>();
        }

		public void AjouterEnseignant(Enseignant enseignant)
		{
			_listeEnseignant.Add(enseignant);
        }
    }
}
