using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioVersion1.classes
{
    public class Abonne
    {
		private string _nom;

		public string Nom
		{
			get { return _nom; }
			set { _nom = value; }
		}
		private string _prenom;

		public string Prenom
		{
			get { return _prenom; }
			set { _prenom = value; }
		}
		private string _email;

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
		public Abonne(string nom, string prenom, string email)
		{
			_nom = nom;
			_prenom = prenom;
			_email = email;
		}
		public string Infos()
		{
			return _prenom + "   " + _nom + "  " + _email;	
		}

		public string CreerAbo(string nom, string prenom, string mail, string mdp, string pseudo, Bdd bdd)
		{
			bdd.TrouverAbo(mail ,mdp, pseudo, out bool aboTrouve, out DataSet abo);

			if (aboTrouve)
			{
				return "Vous avez déjà un compte avec cette adresse mail.";
			}
			else
			{
				bdd.CreerAbo(nom, prenom, mail, pseudo, mdp);
				return "Votre compte a été créé avec succès.";
            }
		}

	}
}
