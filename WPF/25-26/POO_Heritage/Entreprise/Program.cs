namespace Entreprise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool restart = true;
            int nbrEmployers = 0;
            Employers[] Emp = new Employers[10];

            Console.WriteLine("Bienvenu");
            do
            {
                ConsoleKey Uinput;
                Console.Clear();
                do
                {
                    Console.WriteLine("Veuillez choisir une action :\n" +
                        "1- Ajouter un employé\n" +
                        "2- Voire les informations d'un employer\n" +
                        "3- Voire les informations d'un role\n" +
                        "4- Voire les informations de tout les employers de l'entreprise\n\n" +
                        "Pour quitter, appuiez sur la touche 'escape'");
                    Uinput = Console.ReadKey().Key;
                } while (Uinput != ConsoleKey.D1 && Uinput != ConsoleKey.D2 && Uinput != ConsoleKey.D3 && Uinput != ConsoleKey.D4 && Uinput != ConsoleKey.NumPad4 && Uinput != ConsoleKey.NumPad3 && Uinput != ConsoleKey.NumPad2 && Uinput != ConsoleKey.NumPad1 && Uinput != ConsoleKey.Escape);

                Console.Clear();

                string role = "";
                string matricule, nom, prenom;
                DateOnly naissance;

                switch (Uinput)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        bool validInput = false;
                        do
                        {
                            Console.WriteLine("Veuillez choisir le role de l'employé :\n" +
                                "1- Ouvrier\n" +
                                "2- Directeur\n" +
                                "3- Cadre\n\n" +
                                "Pour annuler, appuiez sur escape");
                            Uinput = Console.ReadKey().Key;

                            Console.Clear();

                            if (Uinput == ConsoleKey.D1 || Uinput == ConsoleKey.NumPad1)
                            {
                                role = "Ouvrier";
                                validInput = true;
                            }
                            else if (Uinput == ConsoleKey.D2 || Uinput == ConsoleKey.NumPad2)
                            {
                                role = "Directeur";
                                validInput = true;
                            }
                            else if (Uinput == ConsoleKey.D3 || Uinput == ConsoleKey.NumPad3)
                            {
                                role = "Cadre";
                                validInput = true;
                            }
                            else if (Uinput == ConsoleKey.Escape)
                            {
                                validInput = true;
                            }
                            else
                            {
                                Console.WriteLine("Entrée invalide, veuillez réessayer.");
                            }
                        } while (!validInput);

                        if (Uinput != ConsoleKey.Escape)
                        {
                            string input;
                            ushort salaire;

                            nbrEmployers++;
                            matricule = nbrEmployers.ToString("X4");

                            Console.WriteLine("Veuillez entrer le nom de l'employé :");
                            nom = Console.ReadLine();

                            Console.WriteLine("Veuillez entrer le prénom de l'employé :");
                            prenom = Console.ReadLine();

                            do
                            {
                                validInput = false;
                                Console.WriteLine("Veuillez entrer la date de naissance de l'employé (format: yyyy-MM-dd) :");
                                input = Console.ReadLine();
                                if (DateOnly.TryParse(input, out naissance))
                                {
                                    validInput = true;
                                }
                                else
                                {
                                    Console.WriteLine("Entrée invalide, veuillez réessayer.");
                                }
                            } while (!validInput);

                            if (role == "Ouvrier")
                            {
                                salaire = 2500;

                                DateOnly entreeEntreprise;

                                //demander la date d'entrée dans l'entreprise et la valider
                                do
                                {
                                    validInput = false;
                                    Console.WriteLine("Veuillez entrer la date d'entrée de l'employé dans l'entreprise (format: yyyy-MM-dd) :");
                                    input = Console.ReadLine();
                                    if (DateOnly.TryParse(input, out entreeEntreprise))
                                    {
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Entrée invalide, veuillez réessayer.");
                                    }
                                } while (!validInput);

                                Emp[nbrEmployers] = new Ouvrier(matricule, nom, prenom, naissance, salaire, entreeEntreprise);
                            } else if (role == "cadre")
                            {
                                ushort indice;
                                validInput = false;
                                salaire = 13000;
                                do
                                {
                                    Console.WriteLine("Veuillez entrer l'indice de l'employé :");
                                    input = Console.ReadLine();
                                    if (ushort.TryParse(input, out indice))
                                    {
                                        if (indice < 1 || indice > 4)
                                        {
                                            Console.WriteLine("L'indice doit être compris entre 1 et 4, veuillez réessayer.");
                                        }
                                        else
                                        {
                                            indice--;
                                            salaire += (ushort)(indice * 2000);
                                            validInput = true;
                                        }
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Entrée invalide, veuillez réessayer.");
                                    }
                                } while (!validInput);

                                Emp[nbrEmployers] = new Cadre(matricule, nom, prenom, naissance, salaire, indice);
                            }
                            else if (role == "Directeur")
                            {
                                double chiffreAffaires, pourcentage;
                                salaire = 0;

                                do
                                {
                                    Console.WriteLine("Veuillez entrer le chiffre d'affaires de l'employé :");
                                    input = Console.ReadLine();
                                    if (double.TryParse(input, out chiffreAffaires))
                                    {
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Entrée invalide, veuillez réessayer.");
                                    }
                                } while (!validInput);

                                do
                                {
                                    Console.WriteLine("Veuillez entrer le pourcentage de l'employé :");
                                    input = Console.ReadLine();
                                    if (double.TryParse(input, out pourcentage))
                                    {
                                        salaire = (ushort)(pourcentage / chiffreAffaires);
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Entrée invalide, veuillez réessayer.");
                                    }
                                } while (!validInput);

                                Emp[nbrEmployers] = new Directeur(matricule, nom, prenom, naissance, salaire, chiffreAffaires, pourcentage);
                            }
                        }

                        break;
                    /////////////////////////////////////////////
                    case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                        if(Emp is not null)
                        {
                            validInput = false;
                            int i = 0;
                            do
                            {
                                Console.WriteLine("Veuillez entrer le numéro de l'employer que vous voulez voire");
                                foreach (Employers emp in Emp)
                                {
                                    if (emp is not null){
                                        Console.WriteLine($"-{i} Matricule : {emp.Matricule} | Nom : {emp.Nom} | Prénom : {emp.Prenom} | Role : {emp.GetType().Name}");
                                    }
                                }
                                Uinput = Console.ReadKey().Key;

                            } while (Uinput != ConsoleKey.D0 && Uinput != ConsoleKey.NumPad0 && Uinput != ConsoleKey.D1 && Uinput != ConsoleKey.NumPad1 && Uinput != ConsoleKey.D2 && Uinput != ConsoleKey.NumPad2 && Uinput != ConsoleKey.D3 && Uinput != ConsoleKey.NumPad3 && Uinput != ConsoleKey.D4 && Uinput != ConsoleKey.NumPad4 && Uinput != ConsoleKey.D5 && Uinput != ConsoleKey.NumPad5 && Uinput != ConsoleKey.D6 && Uinput != ConsoleKey.NumPad6 && Uinput != ConsoleKey.D7 && Uinput != ConsoleKey.NumPad7 && Uinput != ConsoleKey.D8 && Uinput != ConsoleKey.NumPad8 && Uinput != ConsoleKey.D9 && Uinput != ConsoleKey.NumPad9);

                            Console.Clear();

                            //afficher les informations de l'employer choisi
                            if (Uinput == ConsoleKey.D0 || Uinput == ConsoleKey.NumPad0)
                            {
                                i = 0;
                            }
                            else if (Uinput == ConsoleKey.D1 || Uinput == ConsoleKey.NumPad1)
                            {
                                i = 1;
                            }
                            else if (Uinput == ConsoleKey.D2 || Uinput == ConsoleKey.NumPad2)
                            {
                                i = 2;
                            }
                            else if (Uinput == ConsoleKey.D3 || Uinput == ConsoleKey.NumPad3)
                            {
                                i = 3;
                            }
                            else if (Uinput == ConsoleKey.D4 || Uinput == ConsoleKey.NumPad4)
                            {
                                i = 4;
                            }
                            else if (Uinput == ConsoleKey.D5 || Uinput == ConsoleKey.NumPad5)
                            {
                                i = 5;
                            }
                            else if (Uinput == ConsoleKey.D6 || Uinput == ConsoleKey.NumPad6)
                            {
                                i = 6;
                            }
                            else if (Uinput == ConsoleKey.D7 || Uinput == ConsoleKey.NumPad7)
                            {
                                i = 7;
                            }
                            else if (Uinput == ConsoleKey.D8 || Uinput == ConsoleKey.NumPad8)
                            {
                                i = 8;
                            }
                            else if (Uinput == ConsoleKey.D9 || Uinput == ConsoleKey.NumPad9)
                            {
                                i = 9;
                            }

                            Console.WriteLine(Emp[i].Infos());

                        break;
                    case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                        break;
                    case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                        break;
                    case ConsoleKey.Escape:
                        restart = false;
                        break;
                }

            } while (restart);
        }

        private void AddEmployer(string role, string matricule, string nom, string prenom, DateOnly naissance, ushort salaire,DateOnly entreeSociete, ushort indice, ushort chiffreAffaires, double pourcentage)
        {
            if (role == "Ouvrier")
            {
                Ouvrier ouvrier = new Ouvrier(matricule, nom, prenom, naissance, salaire, entreeSociete);
            }
        }
    }
}
