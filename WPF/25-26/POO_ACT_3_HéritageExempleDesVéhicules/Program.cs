namespace POO_ACT_3_HéritageExempleDesVéhicules
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicule[] vehi = new Vehicule[4];


            //Création d'une voiture
            vehi[0] = new Voiture("Peugeot", "208", "Rouge", 20000, "Essence", true);
            vehi[1] = new Velo("Giant", "Escape 3", "Bleu", 500, "Vélo de ville", false);
            vehi[2] = new Voiture("Tesla", "Model 3", "Noir", 45000, "Électrique", true);
            vehi[3] = new Velo("Specialized", "Turbo Vado", "Blanc", 3000, "Vélo électrique", true);

            foreach (Vehicule v in vehi)
            {
                Console.WriteLine($"{v.Affiche()}\n");
            }

        }
    }
}
