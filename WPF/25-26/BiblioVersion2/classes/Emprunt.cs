using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BiblioVersion1.classes
{
    public class Emprunt
    {
		private Livre _livreEmprunte;

		public Livre LivreEmprunte
		{
			get { return _livreEmprunte; }
		}
		private DateTime _dateEmprunt;

		public DateTime DateEmprunt
		{
			get { return _dateEmprunt; }
		}
        private DateTime? _dateRetour;

        public DateTime? DateRetour
        {
            get { return _dateRetour; }
			set { _dateRetour = value; }
        }
        private Abonne _emprunteur;

		public Abonne Emprunteur
		{
			get { return _emprunteur; }
		}

		private int _id;

		public int Id
		{
			get { return _id; }
		}

		public Emprunt(Livre livreEmprunte, DateTime dateEmprunt, Abonne emprunteur, int Id)
		{
			_livreEmprunte = livreEmprunte;
			_dateEmprunt = dateEmprunt;
            _emprunteur = emprunteur;
			_id = Id;
        }
        public string infos()
        {
			string info = $"Le livre {_livreEmprunte.Description()} a été emprunté par {Emprunteur.Infos()} le {DateEmprunt.ToShortDateString()}";

            if (DateRetour != null)
            {
                info += " et rendu le " + DateRetour?.ToString("dd/MM/yyyy");
            }
            return info;
		}
	}
}
