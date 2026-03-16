using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    internal class Ouvrier : Employers
    {
		private DateOnly _entreSociete;

		public DateOnly EntreSociete
		{
			get { return _entreSociete; }
		}

		public Ouvrier(string Matricule, string Nom, string Prenom, DateOnly DateNaissance,ushort Salaire, DateOnly EntreSociete) : base(Matricule, Nom, Prenom, DateNaissance, Salaire)
		{
			_entreSociete = EntreSociete;
        }

        public override int CalculerSalaire()
        {
            return (2500 + (100*(DateTime.Now.Year - _entreSociete.Year)));
        }

        public override string Infos()
        {
            return $"Ouvrier: {Prenom} {Nom}, Matricule: {Matricule}, Date de naissance: {Naissance}, Date d'entrée dans la société: {EntreSociete}, Salaire: {Salaire} euros.";
        }
    }
}
