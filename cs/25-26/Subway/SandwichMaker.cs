using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway
{
    internal class SandwichMaker
    {
		private string[] _proteine;
		private string[] _condiment;
		private string[] _pain;
		private string[] _crudite;

		public string[] Crudite
		{
			get { return _crudite; }
		}

		public string[] Pain
		{
			get { return _pain; }
		}

		public string[] Proteine
		{
			get { return _proteine; }
		}

		public string[] Condiment
		{
			get { return _condiment; }
		}

		public SandwichMaker()
		{
			_proteine = new string[] { "Poulet", "Jambon", "Dinde", "Boeuf", "Tofu" };
			_condiment = new string[] { "Mayo", "Ketchup", "Moutarde", "Sauce BBQ", "Vinaigrette" };
			_pain = new string[] { "Blanc", "Complet", "Céréales", "Sans gluten", "Baguette" };
			_crudite = new string[] { "Laitue", "Tomate", "Concombre", "Oignon", "Poivron" };
        }


		public string composeSandwich()
		{
			string[] sandwich = new string[4];
			Random rand = new Random();
			sandwich[0] = _pain[rand.Next(_pain.Length)];
			sandwich[1] = _proteine[rand.Next(_proteine.Length)];
			sandwich[2] = _crudite[rand.Next(_crudite.Length)];
			sandwich[3] = _condiment[rand.Next(_condiment.Length)];
			return $"Votre sandwich est composé de :" +
				$"\n-	Pain : {sandwich[0]}" +
				$"\n-	Protéine : {sandwich[1]}" +
				$"\n-	Crudité : {sandwich[2]}" +
				$"\n-	Condiment : {sandwich[3]}";
        }


    }
}
