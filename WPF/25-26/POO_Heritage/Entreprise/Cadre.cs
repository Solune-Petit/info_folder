using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    internal class Cadre : Employers
    {
		private int _indice;

		public int Indice
		{
			get { return _indice; }
			set { _indice = value; }
		}

		public Cadre(string Matricule, string Nom, string Prenom, DateOnly DateNaissance, ushort Salaire, int Indice) : base(Matricule, Nom, Prenom, DateNaissance, Salaire)
		{
			_indice = Indice;
		}

        public override int CalculerSalaire()
        {
			return _indice;
        }

		public override string Infos()
		{
			return $"Cadre: {Prenom} {Nom}, Matricule: {Matricule}, Date de naissance: {Naissance}, Indice: {Indice}, Salaire: {Salaire} euros.";
        }


    }
}
