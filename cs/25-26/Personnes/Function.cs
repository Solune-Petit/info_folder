using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnes
{
    internal class Function
    {
        public string menu(string PersActif)
        {
            Console.WriteLine($"Que souhaitez-vous faire {PersActif} ?" +
                "\n0. Changer D'utillisateur" +
                "\n1. Donner de l'argent" +
                "\n2. Recevoir de l'argent" +
                "\n3. Afficher le solde" +
                "\n4. Quitter");
        }
    }
}
