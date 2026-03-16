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

		private int _id;

		public int Id
		{
			get { return _id; }
		}

		private string _mdp;

		public string Mdp
		{
			get { return _mdp; }
			set { _mdp = value; }
		}


		public Abonne(string nom, string prenom, string email, string mdp, int id)
		{
			_nom = nom;
			_prenom = prenom;
			_email = email;
			_mdp = mdp;
			_id = id;
		}
		public string Infos()
		{
			return _prenom + "   " + _nom + "  " + _email;	
		}
	}
}
