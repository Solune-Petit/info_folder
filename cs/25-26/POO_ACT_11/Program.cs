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
                        "\n5. Ajouter une salle de classe" +
                        "\n6. Ajouter un cours" +
                        "\n7. Ajouter un etudiant" +
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
                                    Console.WriteLine("Choisissez un département pour ajouter un enseignant :");
                                    int index = 1;
                                    foreach (var dept in ITN.ListeDepartement)
                                    {
                                        Console.WriteLine($"{index}- {dept.Nom}");
                                        index++;
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

                            case 5:
                                Console.WriteLine("Veuillez entrer le nom de la salle de classe :");
                                string nomSalle = Console.ReadLine();
                                int capaciteSalle;
                                do
                                {
                                    Console.WriteLine("Veuillez entrer la capacité de la salle de classe :");
                                    UserInput = Console.ReadLine();

                                }while(!int.TryParse(UserInput, out capaciteSalle));
                                Salle newSalle = new Salle(nomSalle, capaciteSalle);
                                ITN.ListeSalle.Add(newSalle);
                                break;

                            case 6:
                                Console.WriteLine("Veuillez entrer le nom du cours :");
                                string nomCours = Console.ReadLine();
                                int choixDep;

                                do
                                {
                                    Console.WriteLine("Choisissez un département pour ajouter votre cours a cette matiere matière :");
                                    foreach (var dept in ITN.ListeDepartement)
                                    {
                                        Console.WriteLine($"- {dept.Nom}");
                                    }
                                    UserInput = Console.ReadLine();
                                    if (int.TryParse(UserInput, out choixDep))
                                    {
                                        choixDep--;
                                        valid = true;
                                    }
                                } while (!valid);

                                do
                                {
                                    Console.WriteLine("Choisissez une matiere pour ce cours :");
                                    int index = 1;
                                    foreach (var mat in ITN.ListeDepartement[choixDep].ListeMatiere)
                                    {
                                        Console.WriteLine($"{index}- {mat.Nom}");
                                        index++;
                                    }
                                    UserInput = Console.ReadLine();
                                    if (int.TryParse(UserInput, out choice))
                                    {
                                        choice--;
                                        valid = true;
                                    }
                                } while (!valid);

                                int choixSalle;
                                do
                                {
                                    Console.WriteLine("Choisissez une salle pour cette matiere :");
                                    foreach (var salle in ITN.ListeSalle)
                                    {
                                        Console.WriteLine($"- {salle.Nom}");
                                    }
                                    UserInput = Console.ReadLine();
                                    if (int.TryParse(UserInput, out choixSalle))
                                    {
                                        choixSalle--;
                                        valid = true;
                                    }
                                } while (!valid);

                                int choixProf;
                                do
                                {
                                    Console.WriteLine("Choisissez un ensignant pour cette matiere :");
                                    foreach (var prof in ITN.ListeDepartement[choixDep].ListeEnseignant)
                                    {
                                        Console.WriteLine($"- {prof.Infos()}");
                                    }
                                    UserInput = Console.ReadLine();
                                    if (int.TryParse(UserInput, out choixProf))
                                    {
                                        choixProf--;
                                        valid = true;
                                    }
                                } while (!valid);

                                Cours newCours = new Cours(ITN.ListeDepartement[choixDep].ListeMatiere[choice], ITN.ListeSalle[choixSalle], nomCours);
                                ITN.ListeDepartement[choixDep].ListeEnseignant[choixProf].ListeCours.Add(newCours);
                                break;

                            case 7:
                                Console.WriteLine("Veuillez entrer le nom de l'étudiant :");
                                string nomEtudiant = Console.ReadLine();
                                Console.WriteLine("Veuillez entrer le prenom de l'étudiant :");
                                string prenomEtudiant = Console.ReadLine();
                                Console.WriteLine("Veuillez entrer l'email de l'étudiant :");
                                string emailEtudiant = Console.ReadLine();
                                Console.WriteLine("Veuillez entrer le numéro de téléphone de l'étudiant :");
                                string telEtudiant = Console.ReadLine();
                                DateTime dateEntreeEcole;
                                string response = null;
                                bool ajouterMatiere = true;
                                do
                                {
                                    Console.WriteLine("Veuillez entrer la date d'entree dans l'ecole (format : yyyy-MM-dd) :");
                                    UserInput = Console.ReadLine();
                                    if (DateTime.TryParse(UserInput, out dateEntreeEcole))
                                    {
                                        valid = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Format de date invalide. Veuillez réessayer.");
                                    }
                                } while (!valid);
                                Etudiant newEtudiant = new Etudiant(dateEntreeEcole, nomEtudiant, prenomEtudiant, emailEtudiant, telEtudiant);

                                do
                                {
                                    do
                                    {
                                        Console.WriteLine("Choisissez un département pour ajouter une matiere a l'etudiant:");
                                        foreach (var dept in ITN.ListeDepartement)
                                        {
                                            Console.WriteLine($"- {dept.Nom}");
                                        }
                                        UserInput = Console.ReadLine();
                                        if (int.TryParse(UserInput, out choixDep))
                                        {
                                            choixDep--;
                                            valid = true;
                                        }
                                    } while (!valid);

                                    int choixMat;
                                    do
                                    {
                                        Console.WriteLine("Choisissez une matiere a assigner a l'etudiant:");
                                        foreach (var mat in ITN.ListeDepartement[choixDep].ListeMatiere)
                                        {
                                            Console.WriteLine($"- {mat.Nom}");
                                        }
                                        UserInput = Console.ReadLine();
                                        if (int.TryParse(UserInput, out choixMat))
                                        {
                                            valid = true;
                                        }
                                    } while (!valid);

                                    int indexCours = 0;
                                    foreach (var cours in ITN.ListeDepartement[choixDep].ListeEnseignant.SelectMany(e => e.ListeCours))
                                    {
                                        if (cours.Matiere == ITN.ListeDepartement[choixDep].ListeMatiere[choixMat])
                                        {
                                            newEtudiant.ListeCours.Add(new InfosCours(cours, 0));
                                            indexCours++;
                                        }
                                    }

                                    do
                                    {
                                        Console.WriteLine("Voulez-vous ajouter une autre matière à l'étudiant ? (o/n)");
                                        response = Console.ReadLine().ToLower();
                                    } while (response != "o" || response != "n");
                                    if(response == "n")
                                    {
                                        ajouterMatiere = false;
                                    }
                                    else
                                    {
                                        ajouterMatiere = true;
                                    }
                                }while (ajouterMatiere);
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
