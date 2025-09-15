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
            color.white();

            //déclaration des strings
            string text = "";
            string key = "";
            string methode = "";
            string UKeyinput;

            //déclaration des ints
            int choice;
            int keyA = 0;
            int keyB = 0;

            //déclaration des bools
            bool validInput = false;


            //Menu
            do
            {
                Console.WriteLine("Encrypteur :\n" +
                                    "-Pour utilliser la méthode "); color.magenta(); Console.Write("Vigenère"); color.white(); Console.Write(", tappez "); color.magenta(); Console.Write("1\n"); color.white();
                Console.WriteLine(  "-Pour utilliser la méthode "); color.yellow(); Console.Write("Affine"); color.white(); Console.Write(", tappez "); color.yellow(); Console.Write(" 2"); color.white();
                ConsoleKey Uinput = Console.ReadKey().Key;
                //Lecture de la saisie utilisateur et vérification de la validité de la saisie (1 ou 2) grace à des KeyInfo
                if (Uinput == ConsoleKey.D1 || Uinput == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    choice = 1;
                }
                else if (Uinput == ConsoleKey.D2 || Uinput == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    choice = 2;
                }
                else
                {
                    Console.Clear();
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
                    color.white();
                    text = Console.ReadLine().ToUpper();

                } while (!func.inputChecker(text, color));//vérification de la validité du texte

                //récupération de la d'encryptage en vérifiant que le clef ne contient pas d'éspaces ni de chiffres
                do
                {
                    color.cyan();
                    Console.WriteLine("Veuillez entrer la clé d'encryption :");
                    color.white();
                    key = Console.ReadLine().ToUpper();
                } while (!func.inputChecker(key, color));//vérification de la validité de la clé

                Console.Clear();

                string[,] result = func.Vigenere(text, key);

                func.displayMatrix(result, color);
            }
            else if (choice == 2) //Affine
            {
                methode = "Affine";

                //récupération du texte à encrypter en vérifiant que le texte ne contient pas d'éspaces ni de chiffres
                do
                {
                    color.yellow();
                    Console.WriteLine("Vous avez choisi la méthode " + methode + ".");
                    color.cyan();
                    Console.WriteLine("Veuillez entrer le texte à encrypter :");
                    color.white();
                    text = Console.ReadLine().ToUpper();

                } while (!func.inputChecker(text, color));//vérification de la validité du texte

                Console.Clear();

                do
                {
                    color.cyan();
                    Console.WriteLine("Veuillez entrer la valeur de 'A' de la fonction affine (Ax + B) :");
                    color.yellow();
                    UKeyinput = Console.ReadLine();
                    Console.Clear();
                } while (!func.affineChecker(UKeyinput, color, ref keyA));//vérification de la validité de la clé

                do
                {
                    color.cyan();
                    Console.WriteLine("Veuillez entrer la valeur de 'B' de la fonction affine (Ax + B) :");
                    color.yellow();
                    UKeyinput = Console.ReadLine();
                    Console.Clear();
                } while (!func.affineChecker(UKeyinput, color, ref keyB));//vérification de la validité de la clé


                string[,] result = func.Affine(text, key);

                func.displayMatrix(result, color);
            }
        }
    }
}
