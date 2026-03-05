using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    internal class Ouvrier : Employers
    {
		private DateOnly _entreSociete;

		public DateOnly EntreSociete
		{
			get { return _entreSociete; }
		}



	}
}
