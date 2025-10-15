using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6I1_PetitSolune_Livres
{
    internal class fonctions
    {
        public string[,] GenererTableau() 
        {
            string[,] listeBouquins = new string[3,5]
            {
                {"Harry Potter à l'école des Sorciers","J.K Rowlling","Fantaisie","300","non commencé"},
                {"Marche ou crève","Stephen King","Distopique","500","non commencé"},
                {"Le dernier jour d'un condamné","Victor Hugo","roman","150","non commencé"},
            };

            return listeBouquins;
        }

    }
}
