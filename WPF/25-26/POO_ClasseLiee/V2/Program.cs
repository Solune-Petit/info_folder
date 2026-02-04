using ClassesLieeV2.classes;
using POO_ClassLieeV1.classes;

namespace POO_ClassLieeV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque bibli = new Bibliotheque();
            Abonne abo;

            bool restart = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenu dans ma bibliothèque\n" +
                    "Choisissez votre option\n\n" +
                    "1 : Pour generer un livre\n" +
                    "2 : Pour voir la liste des livres dans la bibliothèque\n" +
                    "3 : Pour supprimer les livres endomagés\n" +
                    "4 : Pour sortir du programe\n" +
                    "5 : Pour dégrader un livre\n" +
                    "7 : Pour créer un abonné\n" +
                    "8 : Pour emprunter un livre\n" +
                    "9 : Pour retourner un livre");
                switch (Console.ReadKey().Key)
                {
                    //Générer un livre
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
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
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Clear();
                        temp = string.Empty;
                        int limite;

                        Console.WriteLine(bibli.inventaire());
                        Console.ReadKey();
                        break;
                    //Pour supprimer les livres endomagés
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
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
                    //Pour quitter le programme
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Console.Clear();
                        restart = false;
                        break;
                    //Affiches une liste numérotée des livres pour choisir auquel retirer un point d'état d'un livre sauf s'il est à 0
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine(bibli.inventaire());
                        string Uinput;
                        int choix;
                        do
                        {
                            do
                            {
                                Console.WriteLine("Quel livre voulez-vous dégrader ? (Entrez le numéro)");
                                Uinput = Console.ReadLine();
                            } while (!int.TryParse(Uinput, out choix));
                            choix = int.Parse(Uinput);
                        } while (choix < 1 || choix > bibli.Livres.Count);
                        bibli.Livres[choix - 1].degrade();
                        break;
                    //Créer un abonné
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.D7:
                        Console.Clear();
                        string nomAbonne;
                        Console.WriteLine("Entrez le nom de l'abonné :");
                        nomAbonne = Console.ReadLine();
                        abo = new Abonne(nomAbonne); // Initialisation de 'abo' avec le nom
                        bibli.CreerAbonne(abo, nomAbonne); // Passage d'une instance non nulle
                        break;
                    //Choisir un abonné et emprunter un livre
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.D8:
                        Console.Clear();
                        Console.WriteLine("Entrez le nom de l'abonné :");
                        string nomEmprunt = Console.ReadLine();
                        abo = new Abonne(nomEmprunt);
                        Console.WriteLine(bibli.inventaire());
                        do
                        {
                            do
                            {
                                Console.WriteLine("Quel livre voulez-vous emprunter ? (Entrez le numéro)");
                                Uinput = Console.ReadLine();
                            } while (!int.TryParse(Uinput, out choix));
                            choix = int.Parse(Uinput);
                        } while (choix < 1 || choix > bibli.Livres.Count);
                        bibli.EmprunterLivre(new Emprunt(), bibli.Livres[choix - 1], abo);
                        break;
                    //Retourner un livre
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.D9:
                        Console.Clear();
                        Console.WriteLine("Entrez le nom de l'abonné :");
                        string nomRetour = Console.ReadLine();
                        abo = new Abonne(nomRetour);
                        Console.WriteLine("Entrez le titre du livre à retourner :");
                        string titreRetour = Console.ReadLine();
                        Livres livreRetour = null;
                        foreach (var l in abo.Emprunt)
                        {
                            if (l.Titre == titreRetour)
                            {
                                livreRetour = l;
                                break;
                            }
                        }
                        if (livreRetour != null)
                        {
                            bibli.RetournerLivre(new Emprunt() { Abo = abo, Livre = livreRetour });
                        }
                        else
                        {
                            Console.WriteLine("Le livre n'a pas été trouvé dans les emprunts de l'abonné.");
                            Console.ReadKey();
                        }
                        break;
                }
            } while (restart);
        }
    }
}
