using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            Bdd bdd = new Bdd();

            _contenu = new List<Livre>();
            if(bdd.RecupLivres(out DataSet dl))
            {
                for (int i = 0; i < dl.Tables[0].Rows.Count; i++)
                {
                    _contenu.Add(new Livre(dl.Tables[0].Rows[i]["titre"].ToString(), dl.Tables[0].Rows[i]["nom"].ToString(), dl.Tables[0].Rows[i]["prenom"].ToString(), Convert.ToInt32(dl.Tables[0].Rows[i]["etat"]), Convert.ToInt32(dl.Tables[0].Rows[i]["id"])));
                }
            }

            _emprunts = new List<Emprunt>();
            if(bdd.RecupEmprunts(out DataSet de))
            {
                for (int i = 0; i < de.Tables[0].Rows.Count; i++)
                {
                    Livre livreEmprunte = new Livre(de.Tables[0].Rows[i]["titre"].ToString(), de.Tables[0].Rows[i]["auteur"].ToString(), de.Tables[0].Rows[i]["prenom"].ToString(), Convert.ToInt32(de.Tables[0].Rows[i]["etat"]), Convert.ToInt32(dl.Tables[0].Rows[i]["id"]));
                    Abonne emprunteur = new Abonne(de.Tables[0].Rows[i]["nom"].ToString(), de.Tables[0].Rows[i]["prenom"].ToString(), de.Tables[0].Rows[i]["email"].ToString(), de.Tables[0].Rows[i]["mdp"].ToString(), Convert.ToInt32(de.Tables[0].Rows[i]["id_abonne"]));
                    DateTime dateEmprunt = Convert.ToDateTime(de.Tables[0].Rows[i]["date_emprunt"]);
                    Emprunt emprunt = new Emprunt(livreEmprunte, dateEmprunt, emprunteur);
                    if (de.Tables[0].Rows[i]["date_retour"] != DBNull.Value)
                    {
                        emprunt.DateRetour = Convert.ToDateTime(de.Tables[0].Rows[i]["date_retour"]);
                    }
                    _emprunts.Add(emprunt);
                }
            }

            _abonnes= new List<Abonne>();
            if(bdd.RecupAbonnes(out DataSet da))
            {
                for (int iAbonne = 0; iAbonne < da.Tables[0].Rows.Count; iAbonne++)
                {
                    _abonnes.Add(new Abonne(da.Tables[0].Rows[iAbonne]["nom"].ToString(), da.Tables[0].Rows[iAbonne]["prenom"].ToString(), da.Tables[0].Rows[iAbonne]["email"].ToString(), da.Tables[0].Rows[iAbonne]["motDePasse"].ToString(), Convert.ToInt32(da.Tables[0].Rows[iAbonne]["id"])));
                }
            }
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
        public void CreeAbonne(string nom, string prenom, string email, string login, string mdp)
        {
            Bdd bdd = new Bdd();
            bdd.AjouterAbo(nom, prenom, email, login, mdp);
            if (bdd.ChercherAbonne(nom, prenom, email, login, mdp, out int id))
            {
                _abonnes.Add(new Abonne(nom, prenom, email, mdp, id));
            }
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
                infosAbonnes += $"\n{_abonnes[iAbonne].Infos()}";
            }
            return infosAbonnes;
        }
    }
}
