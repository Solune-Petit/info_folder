using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animaux
{
    internal class Animal
    {
		protected string _nom;

		protected DateTime _naissance;

		protected ushort _puce;

		protected ushort _taille;

		protected bool _concours;

		public bool Concours
		{
			get { return _concours; }
			set { _concours = value; }
		}

		public ushort Taille
		{
			get { return _taille; }
			set { _taille = value; }
		}

		public ushort Puce
		{
			get { return _puce; }
		}

		public DateTime Naissance
		{
			get { return _naissance; }
		}

		public string Nom
		{
			get { return _nom; }
		}

		public Animal(string nom, DateTime naissance, ushort puce, ushort taille, bool concours)
		{
			_nom = nom;
			_naissance = naissance;
			_puce = puce;
			_taille = taille;
			_concours = concours;
        }

		public string Dormir()
		{
			return $"{_nom} dort";
        }

		public string Manger()
		{
			return $"{_nom} mange";
        }

		public virtual string Information()
		{
			return $"Nom : {_nom}\nNaissance : {_naissance}\nPuce : {_puce}\nTaille : {_taille}\nConcours : {_concours}";
        }
    }
}
