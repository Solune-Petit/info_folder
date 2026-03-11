using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioVersion1.classes
{
    public class Bibliotheque
    {
        private List<Livre> _contenu;
        public List<Livre> Contenu { get { return _contenu; } }
        private List<Emprunt> _emprunts;

        public List<Emprunt> Emprunts
        {
            get { return _emprunts; }
            set { _emprunts = value; }
        }
        private List<Abonne> _abonnes;

        public List<Abonne> Abonnes
        {
            get { return _abonnes; }
            set { _abonnes = value; }
        }

        public Bibliotheque()
        {
            _contenu = new List<Livre>();
            _emprunts = new List<Emprunt>();
            _abonnes= new List<Abonne>();
        }

        public void Ajoute(Livre livre)
        {
            _contenu.Add(livre);
        }

        public void Supprimer_livre_abimes()
        {
            for (int iLivre = 0; iLivre < _contenu.Count(); iLivre++)
            {
                Livre unLivre = _contenu[iLivre];
                
                if (unLivre.Etat < 1)
                {
                    _contenu.Remove(unLivre);
                    iLivre--;
                }
            }
        }
        public string Inventaire()
        {
            string contenuBiblio = "";
            for (int iLivre = 0; iLivre < _contenu.Count(); iLivre++)
            {
                contenuBiblio += _contenu[iLivre].Description();
            }
            return contenuBiblio;
        }
        public void CreeAbonne(string nom, string prenom, string email)
        {
            _abonnes.Add(new Abonne(nom, prenom, email));   
        }
        public void AjouteEmpruntLivre (Livre livre, Abonne abonne, DateTime dateEmprunt)
        {
            _emprunts.Add(new Emprunt(livre, dateEmprunt,  abonne));
        }
        public string NotifieRetourLivre(Emprunt emprunt, DateTime dateRetour)
        {
            emprunt.DateRetour = dateRetour;
            return "\nRetour enregistré !";
        }
        public string ListeEmprunts()
        {
            string livresEmpruntes = "\n";
            for (int iLivre = 0; iLivre < _emprunts.Count(); iLivre++)
            {
                livresEmpruntes += _emprunts[iLivre].LivreEmprunte.Description() + " emprunté par " + _emprunts[iLivre].infos();
            }
            return livresEmpruntes;
        }
        public string ListeAbonnes()
        { 
            string infosAbonnes = "\n";
            for (int iAbonne = 0; iAbonne < _abonnes.Count(); iAbonne++)
            {
                infosAbonnes += _abonnes[iAbonne].Infos();
            }
            return infosAbonnes;
        }
    }
}
