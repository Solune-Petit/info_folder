using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3_6TTIUAA14_PetitSolune
{
    internal class PaintBallGun
    {
		private byte _nbBallesChargeur;

		private byte _tailleChargeur;

		public byte TailleChargeur
		{
			get { return _tailleChargeur; }
		}

		public byte NbBallesChargeur
		{
			get { return _nbBallesChargeur; }
			set { _nbBallesChargeur = value; }
		}

		public PaintBallGun(byte TailleChargeur, byte NbBallesChargeur)
		{
			_tailleChargeur = TailleChargeur;
			_nbBallesChargeur = NbBallesChargeur;
		}

		public bool ChargeurEstVide()
		{
			if (_nbBallesChargeur == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool Tirer()
		{
			if (!ChargeurEstVide())
			{
				_nbBallesChargeur--;
				return true;
			}
			else
			{
				return false;
			}
		}

		public string Recharge()
		{
			_nbBallesChargeur = 16;
			return "le chargeur est rechargé";
		}
	}
}
