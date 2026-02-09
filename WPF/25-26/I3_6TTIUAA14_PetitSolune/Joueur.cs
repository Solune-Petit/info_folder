using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3_6TTIUAA14_PetitSolune
{
    internal class Joueur
    {
		private string _pseudo;

		private byte _nbCartouchesEnPoche;

		private PaintBallGun _myPaintBallGun;

		public PaintBallGun MyPaintBallGun
		{
			get { return _myPaintBallGun; }
			set { _myPaintBallGun = value; }
		}


		public byte NbCartouchesEnPoche
		{
			get { return _nbCartouchesEnPoche; }
			set { _nbCartouchesEnPoche = value; }
		}

		public string Pseudo
		{
			get { return _pseudo; }
		}

		public Joueur(string Pseudo, byte NbCartouchesEnPoche, PaintBallGun MyPaintBallGun)
		{
			_pseudo = Pseudo;
			_nbCartouchesEnPoche = NbCartouchesEnPoche;
			_myPaintBallGun = MyPaintBallGun;
		}

		public string ReprendreLesCartouches()
		{
			_nbCartouchesEnPoche += 30;
			return "vous venez de recevoir 30 cartouches";
		}

		public string VerifiePoches()
		{
			return $"il vous restes {_nbCartouchesEnPoche} en poche et {_myPaintBallGun.NbBallesChargeur} dans le chargeur";
		}
	}
}
