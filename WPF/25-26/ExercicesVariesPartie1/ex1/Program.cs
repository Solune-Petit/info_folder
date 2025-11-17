namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool restart = true;
            do
            {
                string input;
                do
                {
                    Console.WriteLine("Entrez le rayon du cercle (ou tapez 'exit' pour quitter) :");
                    input = Console.ReadLine();
                    if (input != null && input.ToLower() != "exit")
                    {
                        if (decimal.TryParse(input, out decimal rayon))
                        {
                            Cercle cercle = new Cercle(rayon);
                            Console.WriteLine(cercle.AfficherDetails());
                        }
                        else
                        {
                            Console.WriteLine("Veuillez entrer un nombre valide pour le rayon.");
                        }
                    }
                } while (input != null && input.ToLower() != "exit");

                Console.WriteLine("Voulez-vous calculer un autre cercle ? (o/n) :");
                string response = Console.ReadLine();
                if (response == null || response.ToLower() != "o")
                {
                    restart = false;
                }
            } while (restart);


        }
    }
}
