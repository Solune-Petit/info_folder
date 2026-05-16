namespace POO_ACT11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Academie aca = new Academie("Asty Moulin");

            Ecole ITN = new Ecole("ITN", "Rue de la pepinère");

            aca.AjouterEcole(ITN);

            bool restart = true;

            do
            {
                bool valid = false;
                while (!valid)
                {
                    Console.Clear();
                    Console.WriteLine("Menu Principal :" +
                        "\n1. Ajouter un Departement" +
                        "\n2. Afficher les Departements" +
                        "\n3. Ajouter une matière" +
                        "\n4. Ajouter un Enseignant" +
                        "\n0. Quitter");
                    string UserInput = Console.ReadLine();
                    if (int.TryParse(UserInput, out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Veuillez entrer le nom du département :");
                                UserInput = Console.ReadLine();
                                Departement newDepartement = new Departement(UserInput);
                                ITN.AjoterDepartement(newDepartement);
                                break;

                            case 2:
                                Console.WriteLine("Départements de l'école ITN :");
                                ITN.afficherDepartement();
                                Console.ReadKey();
                                break;

                            case 3:
                                do
                                {
                                    Console.WriteLine("Choisissez un département pour ajouter une matière :");
                                    foreach (var dept in ITN.ListeDepartement)
                                    {
                                        Console.WriteLine($"- {dept.Nom}");
                                    }
                                    UserInput = Console.ReadLine();
                                    if(int.TryParse(UserInput, out choice))
                                    {
                                        valid = true;
                                    }
                                } while(!valid);

                                Console.WriteLine("Veuillez entrer le nom de la matière :");
                                UserInput = Console.ReadLine();
                                Matiere newMatiere = new Matiere(UserInput);
                                ITN.ListeDepartement[choice - 1].ListeMatiere.Add(newMatiere);
                                break;

                            case 4:
                                DateTime datePriseDeFonction;
                                do
                                {
                                    Console.WriteLine("Choisissez un département pour ajouter une matière :");
                                    foreach (var dept in ITN.ListeDepartement)
                                    {
                                        Console.WriteLine($"- {dept.Nom}");
                                    }
                                    UserInput = Console.ReadLine();
                                    if (int.TryParse(UserInput, out choice))
                                    {
                                        valid = true;
                                    }
                                } while (!valid);
                                valid = false;

                                Console.WriteLine("Veuillez entrer le nom de l'enseignant :");
                                string nomEnseignant = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le prenom de l'enseignant :");
                                string prenomEnseignant = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer l'email de l'enseignant :");
                                string emailEnseignant = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le numéro de téléphone de l'enseignant :");
                                string telEnseignant = Console.ReadLine();

                                do
                                {
                                    Console.WriteLine("Veuillez entrer la date de prise de fonction (format : yyyy-MM-dd) :");
                                    UserInput = Console.ReadLine();
                                    if (DateTime.TryParse(UserInput, out datePriseDeFonction))
                                    {
                                        valid = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Format de date invalide. Veuillez réessayer.");
                                    }
                                }while(!valid);

                                ITN.ListeDepartement[choice - 1].AjouterEnseignant(new Enseignant(datePriseDeFonction, nomEnseignant, prenomEnseignant, emailEnseignant, telEnseignant));
                                break;

                            /////////////////////////
                            case 0:
                                restart = false;
                                break;
                            default:
                                Console.WriteLine("Choix invalide. Veuillez réessayer.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrée invalide. Veuillez entrer un nombre.");

                    }
                }
            } while (restart);
        }
    }
}
