using POO_ClassLieeV1.classes;

namespace POO_ClassLieeV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque bibli = new Bibliotheque();

            bool restart = true;
            do
            {
                Console.WriteLine("Bienvenu dans ma bibliothèque\n" +
                    "Choisissez votre option\n\n" +
                    "1 : Pour generer un livre\n" +
                    "2 : Pour voir la liste des livres pas dans la bibliothèque\n" +
                    "3 : Pour ajouter un livre à la bibliothèque\n" +
                    "4 : Pour supprimer les livres endomagés\n" +
                    "5 : Pour sortir du programe");
                switch (Console.ReadKey().Key)
                {

                    case ConsoleKey.NumPad1: case ConsoleKey.D1:
                        Console.Clear();
                        string titre, auteur;
                        int etat;
                        Console.WriteLine("Entrez le titre du livre :");
                        titre = Console.ReadLine();
                        Console.WriteLine("Entrez l'auteur du livre :");
                        auteur = Console.ReadLine();
                        Console.WriteLine("Entrez l'état du livre (0-5) :");
                        etat = int.Parse(Console.ReadLine());
                        Livres livre = new Livres(titre, auteur, etat);
                        break;
                    case ConsoleKey.NumPad2: case ConsoleKey.D2:
                        Console.Clear();

                        break;
                    case ConsoleKey.NumPad3: case ConsoleKey.D3:
                        Console.Clear();
                        break;
                    case ConsoleKey.NumPad4: case ConsoleKey.D4:
                        Console.Clear();
                        break;
                    case ConsoleKey.NumPad5: case ConsoleKey.D5:
                        restart = false;
                        break;
                }
            } while (restart);
        }
    }
}
