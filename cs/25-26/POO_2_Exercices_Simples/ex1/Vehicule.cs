using System;
using System.Collections.Generic;
using System.Text;

namespace ex1
{
    internal class Vehicule
    {

		private uint _jaugeCarburant;

		public uint JaugeCarburant
		{
			get { return _jaugeCarburant; }
			set { _jaugeCarburant = value; }
		}

		private uint _capaciteMaxReservoir;
		public uint CapaciteMaxReservoir
		{
			get { return _capaciteMaxReservoir; }
			set { _capaciteMaxReservoir = value; }
		}

		private string _modele;
		public string Modele
		{
			get { return _modele; }
		}

		private string _marque;
		public string Marque
		{
			get { return _marque; }
		}

		private string _plaque;
		public string Plaque
		{
			get { return _plaque; }
		}


		public Vehicule(string modele, string marque, string plaque, uint capaciteMaxReservoir)
		{
			_modele = modele;
			_marque = marque;
			_plaque = plaque;
			_capaciteMaxReservoir = capaciteMaxReservoir;
			_jaugeCarburant = 0;
        }


		public string TypeVehicule()
		{
			return $"Modèle: {_modele}, Marque: {_marque}, Plaque: {_plaque}, Capacité du réservoir: {_capaciteMaxReservoir}L, Jauge de carburant: {_jaugeCarburant}L";
        }

		public void AjouterCarburant(uint quantite)
		{
			_jaugeCarburant += quantite;
        }

		public void FaireLePlein()
		{
			_jaugeCarburant = _capaciteMaxReservoir;
        }


    }
}
