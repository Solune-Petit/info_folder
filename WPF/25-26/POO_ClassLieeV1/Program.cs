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
                Console.Clear();
                Console.WriteLine("Bienvenu dans ma bibliothèque\n" +
                    "Choisissez votre option\n\n" +
                    "1 : Pour generer un livre\n" +
                    "2 : Pour voir la liste des livres dans la bibliothèque\n"+
                    "3 : Pour supprimer les livres endomagés\n" +
                    "4 : Pour sortir du programe");
                switch (Console.ReadKey().Key)
                {
                    //Générer un livre
                    case ConsoleKey.NumPad1: case ConsoleKey.D1:
                        Console.Clear();
                        string titre, auteur, temp;
                        int etat;
                            Console.WriteLine("Entrez le titre du livre :");
                            titre = Console.ReadLine();
                        Console.WriteLine("Entrez l'auteur du livre :");
                        auteur = Console.ReadLine();
                        do
                        {
                            do
                            {
                                Console.WriteLine("Entrez l'état du livre (0-5) :");
                                temp = Console.ReadLine();
                            } while (!int.TryParse(temp, out etat));
                            etat = int.Parse(temp);
                        } while (etat < 0 || etat > 5);
                        Livres livre = new Livres(titre, auteur, etat);
                        bibli.ajoute(livre);
                        break;
                    //Voir la liste des livres
                    case ConsoleKey.NumPad2: case ConsoleKey.D2:
                        Console.Clear();
                        temp=string.Empty;
                        int limite;

                        Console.WriteLine(bibli.inventaire());
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad3: case ConsoleKey.D3:
                        Console.Clear();
                        do
                        {
                            do
                            {
                                Console.WriteLine("à quel état minimum doit être un livre pour ne pas être supprimé ? (0-5)");
                                temp = Console.ReadLine();
                            } while (!int.TryParse(temp, out limite));
                        } while (limite <= 0 || limite >= 5);
                        bibli.supprime_livres_abimes(limite);
                        break;
                    case ConsoleKey.NumPad4: case ConsoleKey.D4:
                        Console.Clear();
                        restart = false;
                        break;
                }
            } while (restart);
        }
    }
}
