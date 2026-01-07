namespace Personnes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool FullReset = false;
            do
            {
                Console.WriteLine("Bienvenue sur le site d'échange !" +
                    "\nPour commencer, veuillez donner le nom de la première personne.\n");
                string nom1 = Console.ReadLine();
                Console.WriteLine($"\nMerci {nom1} ! Combien d'argent possèdez-vous ?\n");
                int argent1 = int.Parse(Console.ReadLine());
                Console.WriteLine("\nVeuillez maintenant donner le nom de la deuxième personne.\n");
                string nom2 = Console.ReadLine();
                Console.WriteLine($"\nMerci {nom2} ! Combien d'argent possèdez-vous ?\n");
                int argent2 = int.Parse(Console.ReadLine());
                Personnage pers1 = new Personnage(nom1, argent1);
                Personnage pers2 = new Personnage(nom2, argent2);
                Console.Clear();


            } while (!FullReset);
        }
    }
}
