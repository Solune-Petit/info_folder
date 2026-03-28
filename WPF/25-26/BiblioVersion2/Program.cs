using BiblioVersion1.classes;
using System.Data;

namespace BiblioVersion1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque biblio = new Bibliotheque();
            Bdd bdd = new Bdd();

            string nom = "";
            string prenom = "";

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
                    ////////////////////////création d'un livre
                    case ConsoleKey.L:
                        string titre = "";
                        string tempDate = "";
                        DateOnly date;
                        int etat = 5;


                        Console.Clear();
                        Console.WriteLine("Titre du livre:");
                        titre = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("nom de l'auteur:");
                        nom = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("prénom de l'auteur:");
                        prenom = Console.ReadLine();
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Année de publication du livre (format: yyyy) :");
                            tempDate = Console.ReadLine();
                        } while (!DateOnly.TryParseExact(tempDate, "yyyy", null, System.Globalization.DateTimeStyles.None, out date));

                        Livre livreExistant;
                        if (!TrouveLivre(titre, biblio.Contenu, out livreExistant))
                        {
                            if (bdd.AjouterLivre(titre, nom, prenom, date, out DataSet livre))
                            {
                                biblio.Contenu.Add(new Livre(titre, nom, prenom, etat, int.Parse(livre.Tables[0].Rows[0]["id"].ToString())));
                                Console.WriteLine("livre créé");
                            }
                            else
                            {
                                Console.WriteLine("Erreur lors de la création du livre en base de données !");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ce livre existe déjà dans la bibliothèque !");
                        }

                        break;
                    ////////////////////////création d'un abonné
                    case ConsoleKey.B:
                        string email = "";

                        Console.Clear();
                        Console.WriteLine("Nom de l'abonné :");
                        nom = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Prénom de l'abonné :");
                        prenom = Console.ReadLine();

                        Abonne abonneExistant;
                        if (!TrouveAbonne(nom, biblio.Abonnes, out abonneExistant))
                        {
                            Console.Clear();
                            Console.WriteLine("Email de l'abonné :");
                            email = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Login de l'abonné :");
                            string login = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Mot de passe de l'abonné :");
                            string mdp = Console.ReadLine();
                            Console.Clear();
                            biblio.CreeAbonne(nom, prenom, email, login, mdp);
                            Console.Clear();
                            Console.WriteLine("Abonné enregistré !");
                        }
                        else
                        {
                            Console.WriteLine("L'abonné existe déjà");
                        }

                        break;
                    ////////////////////////liste des abonnés
                    case ConsoleKey.A:
                        Console.WriteLine("\n" + biblio.ListeAbonnes());
                        break;
                    ////////////////////////dégrader un livre
                    case ConsoleKey.D:
                        Console.WriteLine("\n" + biblio.Inventaire());
                        Console.WriteLine("Titre du livre qui est dégradé :");
                        titre = Console.ReadLine();
                        Livre livreADegrader;
                        if (TrouveLivre(titre, biblio.Contenu, out livreADegrader))
                        {
                            if (bdd.DegradeLivre(titre))
                            {
                                livreADegrader.Degrade();
                                Console.WriteLine("Mise à jour de l'état effectuée !");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ce livre n'est pas dans la bibliothèque !");
                        }
                        break;
                    ////////////////////////Suprimer les livres abimés
                    case ConsoleKey.S:
                        if (bdd.SupprimerLivresAbimes())
                        {
                            Console.WriteLine("Mise à jour de la bibliothèque effectuée !");
                        }
                        biblio.Supprimer_livre_abimes();
                        Console.WriteLine("\nLivres abimés supprimés !");
                        break;
                    ////////////////////////Afficher les livres
                    case ConsoleKey.I:
                        Console.WriteLine("\n" + biblio.Inventaire());
                        break;
                    ////////////////////////Créer un emprunt
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
                                if(bdd.EmprunterLivre(livreAEmprunter, emprunteur.Id, biblio))
                                {
                                bdd.RecupEmprunts(out DataSet em);
                                Console.WriteLine("Emprunt enregistré !");
                                }
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
                    ////////////////////////Liste des emprunts
                    case ConsoleKey.E:
                        Console.WriteLine("\nListe des emprunts : \n" + biblio.ListeEmprunts());
                        break;
                    ///////////////////////Rendre un livre
                    case ConsoleKey.R:
                        Livre livreARendre;
                        do
                        {
                            Console.WriteLine("\nTitre du livre qui rentre :");
                            titre = Console.ReadLine();
                        } while (!TrouveLivre(titre, biblio.Contenu, out livreARendre));

                        if (TrouveEmprunt(livreARendre.Id, biblio.Emprunts, out int emprunt))
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
        static bool TrouveEmprunt(int livre, List<Emprunt> emprunts, out int emprunt)
        {
            bool trouve = false;
            emprunt = 0;
            foreach (Emprunt item in emprunts)
            {
                if (item.LivreEmprunte.Id == livre)
                {
                    emprunt = item.Id + 1;
                    trouve = true;
                    return trouve;
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
