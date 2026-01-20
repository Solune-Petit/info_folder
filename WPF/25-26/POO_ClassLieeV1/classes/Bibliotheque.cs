using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ClassLieeV1.classes
{
    internal class Bibliotheque
    {
		private List<Livres> _livres;

		public List<Livres> Livres
		{
			get { return _livres; }
			set { _livres = value; }
		}

		public Bibliotheque()
		{
			_livres = new List<Livres>();
        }

        public void ajoute(Livres livre)
		{
			_livres.Add(livre);
        }

		public void supprime_livres_abimes()
		{
			
        }
		
		public string inventaire()
		{
            //affiche le contenu de la bibliotheque
			string inventaire = "Contenu de la bibliothèque :\n";
			foreach (Livres livre in _livres)
			{
				inventaire += $"- {livre}\n";
            }
			return inventaire;
        }
    }
}
