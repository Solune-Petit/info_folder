using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT11
{
    internal class InfosCours
    {
		private Cours _cours;

		public Cours Cours
		{
			get { return _cours; }
			set { _cours = value; }
		}

		private double _noteEleve;

		public double NoteEleve
		{
			get { return _noteEleve; }
			set { _noteEleve = value; }
		}

		public InfosCours(Cours cours, double noteEleve)
		{
			_cours = cours;
			_noteEleve = noteEleve;
        }
    }
}
