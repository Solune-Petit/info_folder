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
        private string _auteur;
        private int _etat;
        public string Titre { get { return _titre; } }
        public string Auteur { get { return _auteur; } }
        public int Etat { get { return _etat; } set { _etat = value; } }

        public Livre(string titre, string auteur, int etat)
        {
            _titre = titre;
            _auteur = auteur;
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
            return _titre + " " + _auteur + " " + _etat + "\n";
        }
    }
}
