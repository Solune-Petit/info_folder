namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //création d'un tableau 2D pour stocker les informations des voitures
            string[,] voitures = new string[5, 4]
            {
                { "Model S", "Tesla", "ABC123", "100" },
                { "Civic", "Honda", "DEF456", "50" },
                { "Corolla", "Toyota", "GHI789", "55" },
                { "Mustang", "Ford", "JKL012", "60" },
                { "Impreza", "Subaru", "MNO345", "45" }
            };

            Vehicule[] garage = new Vehicule[5];
            //stockage des véhicules dans la classe Vehicule
            for (int i = 0; i < voitures.GetLength(0); i++)
            {
                string modele = voitures[i, 0];
                string marque = voitures[i, 1];
                string plaque = voitures[i, 2];
                uint capaciteMaxReservoir = uint.Parse(voitures[i, 3]);
                garage[i] = new Vehicule(modele, marque, plaque, capaciteMaxReservoir);
            }


            bool recommancer = false;
            //boucle principale
            do
            {
                Console.Clear();
                //affichage des véhicules de la classe Vehicule avec la méthode TypeVehicule
                foreach (var vehicule in garage)
                {
                    Console.WriteLine($"{vehicule.TypeVehicule()}\n");
                }

                ConsoleKeyInfo key;
                bool plaqueValide = false;
                //demander à l'utilisateur si il veut ajouter du carburant à une voiture ou de faire le plein
                do
                {

                    //demander l'operation à effectuer
                    do
                    {
                        Console.WriteLine("Voulez-vous :" +
                            "\n1. Ajouter du carburant à une voiture ?" +
                            "\n2. Faire le plein à une voiture ?");
                        key = Console.ReadKey();
                    } while (key.KeyChar != '1' && key.KeyChar != '2');

                    //demander la plaque de la voiture
                    Console.WriteLine("\nEntrez la plaque de la voiture :");
                    string plaqueRecherchee = Console.ReadLine();

                    //rechercher la voiture dans le garage
                    Vehicule vehiculeTrouve = null;
                    foreach (var vehicule in garage)
                    {
                        if (vehicule.Plaque.Equals(plaqueRecherchee, StringComparison.OrdinalIgnoreCase))
                        {
                            vehiculeTrouve = vehicule;
                            break;
                        }
                    }

                    if (vehiculeTrouve != null)
                    {
                        //si la voiture est trouvée

                        int temp;
                        plaqueValide = true;

                        //vérifier si la voiture à déjà le plein ou si l'ajout de carburant dépasse la capacité maximale
                        if (vehiculeTrouve.CapaciteMaxReservoir == vehiculeTrouve.JaugeCarburant)
                        {
                            Console.WriteLine("\nLa voiture a déjà le plein.\n");
                        }
                        else if (key.KeyChar == '1')
                        {
                            Console.WriteLine("Entrez la quantité de carburant à ajouter :");
                            uint quantiteAAjouter;
                            while (!uint.TryParse(Console.ReadLine(), out quantiteAAjouter))
                            {
                                Console.WriteLine("Veuillez entrer un nombre valide.");
                            }

                            //vérifier si l'ajout de carburant dépasse la capacité maximale
                            temp = (int)(vehiculeTrouve.JaugeCarburant + quantiteAAjouter);
                            if (temp > vehiculeTrouve.CapaciteMaxReservoir)
                            {
                                Console.WriteLine("\nL'ajout de carburant dépasse la capacité maximale du réservoir.\n");
                            }
                            else
                            {
                                vehiculeTrouve.AjouterCarburant(quantiteAAjouter);
                            }
                        }
                        else if (key.KeyChar == '2')
                        {
                            vehiculeTrouve.FaireLePlein();
                        }
                        }
                        else
                        {
                            Console.WriteLine("\nVoiture non trouvée.");
                        }
                    } while (!plaqueValide) ;

                    //demander à l'utilisateur s'il veut recommencer
                    char recommanceKey;
                    do
                    {
                        Console.WriteLine("Voulez-vous recommencer ? (o/n)");
                        recommanceKey = Console.ReadKey().KeyChar;
                        if (recommanceKey == 'o' || recommanceKey == 'O')
                        {
                            recommancer = true;
                        }
                        else
                        {
                            recommancer = false;
                        }
                    } while (recommanceKey != 'o' && recommanceKey != 'O' && recommanceKey != 'n' && recommanceKey != 'N');
            } while (recommancer);
        }
    }
}