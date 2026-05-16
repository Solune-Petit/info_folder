using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT11
{
    internal class Etudiant : Personne
    {
		private int _anneeEntree;

		public int AnneeEntree
		{
			get { return _anneeEntree; }
			set { _anneeEntree = value; }
		}

		private List<InfosCours> _listeCours;

		public List<InfosCours> ListeCours
		{
			get { return _listeCours; }
			set { _listeCours = value; }
		}

		public Etudiant(int anneeEntree, string nom, string prenom, string email, string telephone) : base(nom, prenom, email, telephone)
		{
			_anneeEntree = anneeEntree;
			_listeCours = new List<InfosCours>();
        }

		public double CalculerMoyenneGenerale()
		{
			double somme = 0;
			int nombreNotes = 0;
			foreach (InfosCours infos in _listeCours)
			{
				somme += infos.NoteEleve;
				nombreNotes++;
            }
			return nombreNotes > 0 ? somme / nombreNotes : 0;
        }

		public string AfficherMatieresNotees()
		{
			string result = "Matières notées :\n";
			foreach (InfosCours infos in _listeCours)
			{
				if (infos.NoteEleve > 0)
				{
					result += "- " + infos.Cours.Nom + "\n";
				}
			}
			return result;
        }

		public string Infos()
		{
			string result = base.Infos() + $"; Année d'entrée : {_anneeEntree}\n";
			result += AfficherMatieresNotees();
			return result;
        }

    }
}
