using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitSolune_ExerciceChien
{
    internal class Chien
    {
        //attributs
        private string _nom, _race, _pelage, _tag;
        private double _age, _taille, _poids, _sociabilite;
        private bool _agresif;

        public Chien(string nom, string race, string pelage, string tag, double age, double taille, double poids, double sociabilite, bool agresif)
        {
            _nom = nom;
            _race = race;
            _pelage = pelage;
            _tag = tag;
            _age = age;
            _taille = taille;
            _poids = poids;
            _sociabilite = sociabilite;
            _agresif = agresif;
        }

        public string Sauter()
        {
            return $"{_nom} saute de joie !";
        }

        public string Aboyer()
        {
            return $"{_nom} aboie ! Wouaf Wouaf !";
        }

        public string Manger()
        {
            return $"{_nom} mange sa nourriture.";
        }
    }
}
