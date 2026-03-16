using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioVersion1.classes
{
    public class Livre
    {
        private string _titre;
        private string _nom;
        private int _etat;
        private string _prenom;
        public string Titre { get { return _titre; } }
        public string Nom { get { return _nom; } }
        public string Prenom { get { return _prenom; } }
        public int Etat { get { return _etat; } set { _etat = value; } }

        public Livre(string titre, string nom, string prenom, int etat)
        {
            _titre = titre;
            _nom = nom;
            _prenom = prenom;
            _etat = etat;
        }

        public bool Degrade()
        {
            _etat--;
            if (_etat <= 0)
            {
                _etat = 0;
                return true;
            }
            return false;
        }
        public string Description()
        {
            return _titre + " " + _prenom + " " + _nom + " " + _etat + "\n";
        }
    }
}
