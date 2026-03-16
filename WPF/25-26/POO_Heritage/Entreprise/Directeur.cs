using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    internal class Directeur : Employers
    {
        private double _chiffreAffaire;
        public double ChiffreAffaire
        {
            get { return _chiffreAffaire; }
            set { _chiffreAffaire = value; }
        }

        private double _pourcentage;
        public double Pourcentage
        {
            get { return _pourcentage; }
            set { _pourcentage = value; }
        }

        public Directeur(string Matricule, string Nom, string Prenom, DateOnly DateNaissance, ushort Salaire, double ChiffreAffaire, double Pourcentage) : base(Matricule, Nom, Prenom, DateNaissance, Salaire)
        {
            _chiffreAffaire = ChiffreAffaire;
            _pourcentage = Pourcentage;
        }

        public override int CalculerSalaire()
        {
            return (int)(ChiffreAffaire * (Pourcentage / 100));
        }

        public override string Infos()
        {
            return $"Directeur: {Prenom} {Nom}, Matricule: {Matricule}, Date de naissance: {Naissance}, Chiffre d'affaire: {ChiffreAffaire} euros, Pourcentage: {Pourcentage}%, Salaire: {Salaire} euros.";
        }
    }
}
