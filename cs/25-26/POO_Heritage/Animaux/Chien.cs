using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Animaux
{
    internal class Chien : Animal
    {
        public Chien(string nom, DateTime naissance, ushort puce, ushort taille, bool concours) : base(nom, naissance, puce, taille, concours)
        {

        }

        public string Aboyer()
        {
            return "ouaf uoaf";
        }
    }
}