using ClassesLieeV2.classes;
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

		public void supprime_livres_abimes(int Marque)
		{
			_livres.RemoveAll(livre => livre.Etat <= Marque);
        }
		
		public string inventaire()
		{
            //affiche le contenu de la bibliotheque
			string inventaire = "Contenu de la bibliothèque :\n\n";
			foreach (Livres livre in _livres)
			{
				inventaire += $"- {livre.Titre} par {livre.Auteur}. en état {livre.Etat}\n";
            }
			inventaire += $"\n\nNombre total de livres : {_livres.Count}\n\nAppuiez sur une touche pour continuer";
            return inventaire;
        }

		public void degrade_livre(string titre)
		{
			Livres livre = _livres.Find(l => l.Titre == titre);
			if (livre != null)
			{
				livre.degrade();
            }
        }

		public void CreerAbonne(Abonne abo,string nom)
		{
			abo = new Abonne(nom);
        }

        //retirer un livre de la bibliotheque
		public void RetirerLivre(string titre)
		{
			Livres livre = _livres.Find(l => l.Titre == titre);
			if (livre != null)
			{
				_livres.Remove(livre);
            }
        }

        public void EmprunterLivre(Emprunt emprunter,Livres livre, Abonne abo)
		{
			emprunter = new Emprunt();
			emprunter.Livre = livre;
			emprunter.Abo = abo;
			Bibliotheque bibli = new Bibliotheque();
			bibli.RetirerLivre(livre.Titre);
        }

        //retourner un livre a la bibliotheque et le supprimer de l'emprunt
        public void RetournerLivre(Emprunt emprunter)
		{
			Bibliotheque bibli = new Bibliotheque();
			bibli.ajoute(emprunter.Livre);
			emprunter.Livre = null;
        }
    }
}
