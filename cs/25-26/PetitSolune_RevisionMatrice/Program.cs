using _5T24_PetitSolune_enigma;

namespace PetitSolune_RevisionMatrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instanciation de la classe Fonctions
            Fonctions func = new Fonctions();

            //instanciation de la classe ColorChanger
            ColorChanger color = new ColorChanger();

            //déclaration des strings
            string text;

            //déclaration des ints
            int choice;

            //déclaration des bools
            bool validInput = false;


            //Menu
            do
            {
                Console.WriteLine("Encrypteur\n" +
                                    "-Pour utilliser la méthode"); color.magenta(); Console.Write("Vigenère"); color.white(); Console.Write(", tappez "); color.magenta(); Console.Write("1"); color.white();
                Console.WriteLine(  "-Pour utilliser la méthode"); color.yellow(); Console.Write("Affine"); color.white(); Console.Write(", tappez "); color.yellow(); Console.Write(" 2"); color.white();
                Console.Clear();
                //Lecture de la saisie utilisateur et vérification de la validité de la saisie (1 ou 2) grace à des KeyInfo
                if (Console.ReadKey().Key == ConsoleKey.D1 || Console.ReadKey().Key == ConsoleKey.NumPad1)
                {
                    choice = 1;
                }
                else if (Console.ReadKey().Key == ConsoleKey.D2 || Console.ReadKey().Key == ConsoleKey.NumPad2)
                {
                    choice = 2;
                }
                else
                {
                    color.red();
                    Console.WriteLine("Erreur de saisie, veuillez réessayer.");
                    color.white();
                    choice = 0;
                }
            } while (choice == 0);


            //Traitement du choix utilisateur
            if (choice == 1) //Vigenère
            {
                //récupération du texte à encrypter en vérifiant que le texte ne contient pas d'éspaces ni de chiffres
                do
                {
                    color.yellow();
                    Console.WriteLine("Vous avez choisi la méthode Vigenère.");
                    color.cyan();
                    Console.WriteLine("Veuillez entrer le texte à encrypter :");
                    text = Console.ReadLine().ToUpper();

                    for (int cursor = 0; cursor < text.Length; cursor++)
                    {
                        if (text[cursor] < 'A' || text[cursor] > 'Z')
                        {
                            validInput = false;
                            color.red();
                            Console.WriteLine("Le texte ne doit pas contenir d'espaces ni de chiffres, veuillez réessayer.");
                            color.white();
                            break;
                        }
                        else
                        {
                            validInput = true;
                        }
                    }
                } while (!validInput);

                Console.WriteLine("Veuillez entrer la clé d'encryption :");
                string key = Console.ReadLine().ToUpper();
                func.Vigenere(text, key);
            }
            else if (choice == 2) //Affine
            {
                
            }
        }
    }
}
