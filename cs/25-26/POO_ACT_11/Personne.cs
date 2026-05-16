using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT11
{
    abstract internal class Personne
    {
        protected string _nom;

        protected string _prenom;

        protected string _email;

        protected string _telephone;

        public Personne(string nom, string prenom, string email, string telephone)
        {
            _nom = nom;
            _prenom = prenom;
            _email = email;
            _telephone = telephone;
        }

        public string Infos()
        {
            return $"{_nom}; {_prenom}; {_email}; {_telephone}";
        }
    }
}
