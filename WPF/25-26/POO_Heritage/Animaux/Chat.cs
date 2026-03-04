using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animaux
{
    internal class Chat : Animal
    {
        public Chat (string nom, DateTime naissance, ushort puce, ushort taille, bool concours) : base(nom, naissance, puce, taille, concours)
        {

        }
        
        public string Miauler()
        {
            return "miaou miaou";
        }
    }
}
