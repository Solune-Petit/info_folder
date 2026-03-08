namespace Entreprise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool restart = true;
            int nbrEmployers = 0;

            Console.WriteLine("Bienvenu");
            do
            {
                ConsoleKey Uinput;
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

                string role, matricule, nom, prenom;
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
                            }while (!validInput);

                            do {                                 Console.WriteLine("Veuillez entrer le salaire de l'employé :");
                                input = Console.ReadLine();
                                if (ushort.TryParse(input, out salaire))
                                {
                                    validInput = true;
                                }
                                else
                                {
                                    Console.WriteLine("Entrée invalide, veuillez réessayer.");
                                }
                            } while (!validInput);

                            Ouvrier ouvrier = new Ouvrier(matricule, nom, prenom, naissance, salaire, DateOnly.FromDateTime(DateTime.Now));
                        }

                        break;
                    case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                        
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
