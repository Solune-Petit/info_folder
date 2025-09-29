using _5T24_PetitSolune_enigma;

namespace PetitSolune_ExerciceChien
{
    internal class Program
    {
        static void Main(string[] args)
        {

            function func = new function();

            ColorChanger c = new ColorChanger();

            string[,] infosChiens = new string[5, 9]
            {
                { "Rex", "Berger Allemand", "Court", "1", "3", "60", "30", "8", "False" },
                { "Bella", "Labrador", "Long", "2", "5", "55", "25", "9", "False" },
                { "Max", "Bulldog", "Court", "3", "4", "40", "20", "6", "True" },
                { "Luna", "Beagle", "Court", "4", "2", "38", "18", "7", "False" },
                { "Charlie", "Poodle", "Bouclé", "5", "6", "45", "22", "9", "False" }
            };

            int dogCount;
            char dogChoice;
            char uInput;
            bool validInput, exit = false;

            do
            {
                Console.WriteLine("Combiens de chiens avez vous ?");
                uInput = Console.ReadKey().KeyChar;
                Console.Clear();
                if(!int.TryParse(uInput.ToString(), out dogCount) || dogCount < 0)
                {
                    c.Bgred();
                    c.white();
                    Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entier positif.");
                }
            }while(dogCount < 0);

            Chien[] monChien = new Chien[dogCount];

            for (int i = 0; i < dogCount; i++)
            {
                string[] temp = new string[9];
                for (int j = 0; j < infosChiens.GetLength(1); j++)
                {
                    temp[j] = infosChiens[i, j];
                }
                monChien[i] = new Chien(temp[0], temp[1], temp[2], temp[3], double.Parse(temp[4]), double.Parse(temp[5]), double.Parse(temp[6]), double.Parse(temp[7]), bool.Parse(temp[8]));
            }
            

            do
            {
                do
                {
                    validInput = true;
                    func.menu(c);
                    uInput = Console.ReadKey().KeyChar;
                    Console.Clear();
                    
                    if(int.TryParse(uInput.ToString(), out int choice))
                    {
                        if (choice >= 0 && choice <= 5)
                        {
                            validInput = false;
                        }
                        else
                        {
                            c.Bgred();
                            c.white();
                            Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entre 0 et 5 inclus.");
                        }
                    }
                    else
                    {
                        c.Bgred();
                        c.white();
                        Console.WriteLine("Entrée invalide. Veuillez entrer un nombre.");
                    }

                }while (validInput);

                do
                {
                    validInput = false;
                    Console.WriteLine($"Sur quel chien voulez vous faire cette action ?");
                    Console.WriteLine(func.dogTagTable(monChien, dogCount));
                    uInput = Console.ReadKey().KeyChar;
                    Console.Clear();
                    if (char.TryParse(uInput.ToString(), out dogChoice))
                    {
                        if(dogChoice >= 1 && dogChoice <= dogCount)
                        {
                            validInput = true;
                        }
                        else
                        {
                            c.Bgred();
                            c.white();
                            Console.WriteLine($"Entrée invalide. Veuillez entrer un nombre entre 1 et {dogCount} inclus.");
                        }
                    }
                    else
                    {
                        c.Bgred();
                        c.white();
                        Console.WriteLine("Entrée invalide. Veuillez entrer un nombre.");
                    }
                } while(!validInput);

                switch (uInput)
                {
                    case '0':

                        Console.WriteLine(monChien[dogChoice].infos());
                        break;
                    case '1':
                        Console.WriteLine(monChien[dogChoice].Sauter());
                        break;
                    case '2':
                        Console.WriteLine(monChien[dogChoice].Aboyer());
                        break;
                    case '3':
                        Console.WriteLine(monChien[dogChoice].Manger());
                        break;
                    case '4':
                        Console.WriteLine(monChien[dogChoice].age());
                        break;
                    case '5':
                        c.green();
                        Console.WriteLine("Merci d'avoir joué !");
                        c.white();
                        exit = true;
                        break;
                }
                c.yellow();
                Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                c.white();
                Console.ReadKey();
                Console.Clear();

            } while (!exit);
        }
    }
}
