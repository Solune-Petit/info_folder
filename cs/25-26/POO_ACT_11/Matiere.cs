using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT11
{
    internal class Matiere
    {
		private string _nom;

		public string Nom
		{
			get { return _nom; }
			set { _nom = value; }
		}

		public Matiere(string nom)
		{
			_nom = nom;
        }
    }
}
