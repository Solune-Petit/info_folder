using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6I1_PetitSolune_Livres
{
    internal class Livre
    {
        //déclaration des variables
        private string _titre, _auteur, _genre, _etatLecture;
        private int _nombrePages;

        public Livre(string titre, string auteur, string genre, string etatLecture, int nombrePages)
        {
            _titre = titre;
            _auteur = auteur;
            _genre = genre;
            _etatLecture = etatLecture;
            _nombrePages = nombrePages;
        }

        //instanciation des classes
        public string Titre()
        {
            return _titre;
        }

        public string Auteur()
        {
            return _auteur;
        }

        public string Genre()
        {
            return _genre;
        }

        public int NombrePages()
        {
            return _nombrePages;
        }

        public string EtatLecture(string etat)
        {
            _etatLecture = etat;
            return _etatLecture;
        }

        public string CommencerLecture()
        {
            EtatLecture("en cours");
            return _etatLecture;
        }

        public string TerminerLecture()
        {
            EtatLecture("terminé");
            return _etatLecture;
        }

        public string DonneInfos()
        {
            return  $"Le Livre se nomme         : {_titre}\n" +
                    $"Il est écrit par          : {_auteur}\n" +
                    $"Son genre est             : {_genre}\n" +
                    $"Son nombre de pages est   : {_nombrePages}\n" +
                    $"Son état de lecture est   : {_etatLecture}\n";
        }
    }
}
