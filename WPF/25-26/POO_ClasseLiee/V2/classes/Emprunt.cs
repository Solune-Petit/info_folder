using POO_ClassLieeV1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLieeV2.classes
{
    internal class Emprunt
    {
		private Livres _livre;
		private Abonne _abo;

		public Abonne Abo
		{
			get { return _abo; }
			set { _abo = value; }
		}

		public Livres Livre
		{
			get { return _livre; }
			set { _livre = value; }
		}


	}
}
