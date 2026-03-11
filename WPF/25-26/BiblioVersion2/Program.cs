using BiblioVersion1.classes;

namespace BiblioVersion1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque biblio = new Bibliotheque();
            do
            {
                Console.Clear();
                Console.WriteLine("L: Créer un livre\n" +
                        "B: Créer un abonné\n" +
                        "A: Afficher les abonnés\n" +
                        "D: Dégrader un livre\n" +
                        "S: Supprimer les livres abimés\n" +
                        "I: Afficher les livres se trouvant dans la bibliothèque\n" +
                        "C: Créer un emprunt \n" +
                        "E: Afficher les livres empruntés \n" +
                        "R: Rendre un livre"
                    );
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.L:
                        string titre = "";
                        string auteur = "";
                        int etat = 5;

                        Console.WriteLine("\nTitre du livre:");
                        titre = Console.ReadLine();
                        Console.WriteLine("auteur du livre:");
                        auteur = Console.ReadLine();

                        Livre livreExistant;
                        if (!TrouveLivre(titre, biblio.Contenu, out livreExistant))
                        {
                            biblio.Contenu.Add(new Livre(titre, auteur, etat));
                            Console.WriteLine("livre créé");
                        }
                        else
                        {
                            Console.WriteLine("Ce livre existe déjà dans la bibliothèque !");
                        }

                        break;
                    case ConsoleKey.B:
                        string nom = "";
                        string prenom = "";
                        string email = "";

                        Console.WriteLine("\nNom de l'abonné :");
                        nom = Console.ReadLine();
                        Console.WriteLine("Prénom de l'abonné :");
                        prenom = Console.ReadLine();

                        Abonne abonneExistant;
                        if (!TrouveAbonne(nom, biblio.Abonnes, out abonneExistant))
                        {
                            biblio.CreeAbonne(nom, prenom, "");
                            Console.WriteLine("Abonné enregistré !");
                        }
                        else
                        {
                            Console.WriteLine("L'abonné existe déjà");
                        }

                        break;
                    case ConsoleKey.A:
                        Console.WriteLine("\n" + biblio.ListeAbonnes());
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("\n" + biblio.Inventaire());
                        Console.WriteLine("Titre du livre qui est dégradé :");
                        titre = Console.ReadLine();
                        Livre livreADegrader;
                        if (TrouveLivre(titre, biblio.Contenu, out livreADegrader))
                        {
                            livreADegrader.Degrade();
                            Console.WriteLine("Mise à jour de l'état effectuée !");
                        }
                        else
                        {
                            Console.WriteLine("Ce livre n'est pas dans la bibliothèque !");
                        }
                        break;
                    case ConsoleKey.S:
                        biblio.Supprimer_livre_abimes();
                        Console.WriteLine("\nLivres abimés supprimés !");
                        break;
                    case ConsoleKey.I:
                        Console.WriteLine("\n" + biblio.Inventaire());
                        break;
                    case ConsoleKey.C:
                        Console.WriteLine("\nChoisissez un livre \n");
                        Console.WriteLine("\n" + biblio.Inventaire());
                        Console.WriteLine("Titre du livre que vous désirez emprunter :");
                        titre = Console.ReadLine();
                        Livre livreAEmprunter;
                        if (TrouveLivre(titre, biblio.Contenu, out livreAEmprunter))
                        {
                            Console.WriteLine("Quel abonné veut l'emprunter ? Taper son nom.");
                            nom = Console.ReadLine();
                            Abonne emprunteur;
                            if (TrouveAbonne(nom, biblio.Abonnes, out emprunteur))
                            {
                                biblio.AjouteEmpruntLivre(livreAEmprunter, emprunteur, DateTime.Today);
                                Console.WriteLine("Emprunt enregistré !");
                            }
                            else
                            {
                                Console.WriteLine("L'abonné n'existe pas");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Ce livre n'est pas dans la bibliothèque !");
                        }
                        break;
                    case ConsoleKey.E:
                        Console.WriteLine("\nListe des emprunts : \n" + biblio.ListeEmprunts());
                        break;
                    case ConsoleKey.R:
                        Console.WriteLine("\nTitre du livre qui rentre :");
                        titre = Console.ReadLine();
                        Emprunt emprunt;
                        if (TrouveEmprunt(titre, biblio.Emprunts, out emprunt))
                        {
                            Console.WriteLine(biblio.NotifieRetourLivre(emprunt, DateTime.Today));
                            
                        }
                        else
                        {
                            Console.WriteLine("Ce livre n'est pas dans la bibliothèque !");
                        }
                        Console.WriteLine("\n");
                        break;
                    default:
                        break;
                }
                Console.Write("Appuyez sur une touche pour continuer !");
                Console.ReadLine();
                //    Console.WriteLine("\nAppuyez sur espace pour recommencer");
                //} while (Console.ReadKey().Key == ConsoleKey.Spacebar);
            } while (true);
        }
        static bool TrouveLivre(string titre, List<Livre> biblio, out Livre livre)
        {
            bool trouve = false;
            livre = null;
            foreach (Livre item in biblio)
            {
                if (item.Titre == titre)
                {
                    livre = item;
                    trouve = true;
                }
            }
            return trouve;
        }
        static bool TrouveEmprunt(string titre, List<Emprunt> emprunts, out Emprunt emprunt)
        {
            bool trouve = false;
            emprunt = null;
            foreach (Emprunt item in emprunts)
            {
                if (item.LivreEmprunte.Titre == titre)
                {
                    emprunt = item;
                    trouve = true;
                }
            }
            return trouve;
        }
        static bool TrouveAbonne(string nom, List<Abonne> abonnes, out Abonne abonne)
        {
            bool trouve = false;
            abonne = null;
            foreach (Abonne item in abonnes)
            {
                if (item.Nom == nom)
                {
                    abonne = item;
                    trouve = true;
                }
            }
            return trouve;
        }
    }
}
