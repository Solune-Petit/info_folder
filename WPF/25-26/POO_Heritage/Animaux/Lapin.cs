using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animaux
{
    internal class Lapin : Animal
    {
        private ushort _oreilles;

        public ushort Oreilles
        {
            get { return _oreilles; }
            set { _oreilles = value; }
        }


        public Lapin(string nom, DateTime naissance, ushort puce, ushort taille, bool concours) : base(nom, naissance, puce, taille, concours)
        {
            _oreilles = Oreilles;
        }
    }
}
