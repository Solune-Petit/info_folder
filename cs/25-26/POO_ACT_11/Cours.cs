using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ACT11
{
    internal class Cours
    {
		private Matiere _matiere;

		public Matiere Matiere
		{
			get { return _matiere; }
			set { _matiere = value; }
		}

		private Salle _salle;

		public Salle Salle
		{
			get { return _salle; }
			set { _salle = value; }
		}

		private string _nom;

		public string Nom
		{
			get { return _nom; }
			set { _nom = value; }
		}

		private List<double> _notes;

		public List<double> Notes
		{
			get { return _notes; }
			set { _notes = value; }
		}

		private List<Etudiant> _listeEtudiants;

		public List<Etudiant> ListeEtudiants
		{
			get { return _listeEtudiants; }
			set { _listeEtudiants = value; }
		}

		public Cours(Matiere matiere, Salle salle, string nom)
		{
			_matiere = matiere;
			_salle = salle;
			_nom = nom;
			_notes = new List<double>();
			_listeEtudiants = new List<Etudiant>();
        }

		public void AjouterNote(double note)
		{
			_notes.Add(note); 
		}

		public double CalculerMoyenne()
		{
			if (_notes.Count == 0)
			{
				return 0; 
			}
			double somme = 0;
			foreach (double note in _notes)
			{
				somme += note;
			}
			return somme / _notes.Count;
        }
    }
}
