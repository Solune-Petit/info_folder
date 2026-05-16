using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT11
{
    internal class Ecole
    {
		private string _codeEcole;

		public string CodeEcole
		{
			get { return _codeEcole; }
		}

		private string _adresse;

		public string Adresse
		{
			get { return _adresse; }
		}

		private List<Salle> _listeSalle;

		public List<Salle> ListeSalle
		{
			get { return _listeSalle; }
			set { _listeSalle = value; }
		}

		private List<Departement> _listeDepartement;

		public List<Departement> ListeDepartement
		{
			get { return _listeDepartement; }
			set { _listeDepartement = value; }
		}

		public Ecole(string codeEcole, string adresse)
		{
			_codeEcole = codeEcole;
			_adresse = adresse;
			_listeSalle = new List<Salle>();
			_listeDepartement = new List<Departement>();
        }

		public void AjoterDepartement(Departement departement)
		{
			_listeDepartement.Add(departement);
        }

		public void afficherDepartement()
		{
			string result = "Liste des départements de l'école :\n";
			foreach (Departement departement in _listeDepartement)
			{
				result += "- " + departement.Nom + "\n";
			}
			Console.WriteLine(result);
        }
    }
}
