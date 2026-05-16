using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT11
{
    internal class Enseignant : Personne
    {
		private DateTime _datePriseDeFonction;

		public DateTime DatePriseDeFonction
		{
			get { return _datePriseDeFonction; }
			set { _datePriseDeFonction = value; }
		}

		private List<Cours> _listeCours;

		public List<Cours> ListeCours
		{
			get { return _listeCours; }
			set { _listeCours = value; }
		}

		public Enseignant(DateTime datePriseDeFonction, string nom, string prenom, string email, string telephone) : base(nom, prenom, email, telephone)
		{
			_datePriseDeFonction = datePriseDeFonction;
			_listeCours = new List<Cours>();
        }

		public void AjouterCours(Cours cours)
		{
			_listeCours.Add(cours);
        }

		public string Infos()
		{
			string result = $"Date de prise de fonction : {_datePriseDeFonction.ToShortDateString()}\n";
			result += "Liste des cours enseignés :\n";
			foreach (Cours cours in _listeCours)
			{
				result += "- " + cours.Nom + "\n";
			}
			return result;
        }
    }
}
