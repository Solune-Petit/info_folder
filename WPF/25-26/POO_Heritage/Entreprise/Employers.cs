using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    public abstract class Employers
    {
		protected string _matricule, _nom, _prenom;

		protected DateOnly _naissance;

		protected ushort _salaire;

		public ushort Salaire
		{
			get { return _salaire; }
			set { _salaire = value; }
		}

		public DateOnly Naissance
		{
			get { return _naissance; }
		}

		public string Prenom
		{
			get { return _prenom; }
        }

        public string Nom
		{
			get { return _nom; }
        }

        public string Matricule
		{
			get { return _matricule; }
		}

		//constructeur
		public Employers(string matricule, string nom, string prenom, DateOnly naissance, ushort salaire)
		{
			_matricule = matricule;
			_nom = nom;
			_prenom = prenom;
			_naissance = naissance;
			_salaire = salaire;
        }

		abstract public string Infos();

		abstract public string CalculerSalaire();
    }
}
