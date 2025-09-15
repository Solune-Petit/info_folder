using _5T24_PetitSolune_enigma;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PetitSolune_RevisionMatrice
{
    internal class Fonctions
    {

        //Méthode d'encryption de vigenère. Voire analyse pour fonctionnement
        public string[,] Vigenere(string text, string key)
        {
            string[,] encoder = new string[text.Length, 4];
            int keyCursor = 0;
            int cAscii;
            for (int cursor = 0; cursor < text.Length; cursor++)
            {
                encoder[cursor, 0] = text[cursor].ToString();
                if (keyCursor == key.Length)
                {
                    keyCursor = 0;
                }
                
                encoder[cursor, 1] = key[keyCursor].ToString();
                encoder[cursor, 2] = ((int)key[keyCursor] - 65).ToString();

                if ((int)text[cursor] + int.Parse(encoder[cursor, 2]) <= 90)
                {
                    cAscii = (int)text[cursor] + int.Parse(encoder[cursor, 2]);
                }
                else
                {
                    cAscii = (int)text[cursor] + int.Parse(encoder[cursor, 2]) - 26;
                }

                encoder[cursor, 3] = ((char)cAscii).ToString();
                keyCursor++;
            }
            return encoder;
        }

        //Méthode d'encryption affine. Voire analyse pour fonctionnement


        public bool affineChecker(string Uinput, ColorChanger color, ref int key)
        {
            if (int.TryParse(Uinput, out int number))
            {
                // L'entrée est un nombre entier valide
                key = number;
            }
            else
            {
                // L'entrée n'est pas un nombre entier valide
                color.red();
                Console.WriteLine("Erreur de saisie, veuillez réessayer.");
                color.white();
            }
        }

        //fonction booléenne pour vérifier si un texte à encrypter ne contient ni de chiffres ni d'espaces
        public bool inputChecker(string text, ColorChanger color)
        {
            bool validInput = false;
            
            for (int cursor = 0; cursor < text.Length; cursor++)
            {
                if (text[cursor] < 'A' || text[cursor] > 'Z')
                {
                    Console.Clear();
                    validInput = false;
                    color.red();
                    Console.WriteLine("Le texte ne doit pas contenir d'espaces ni de chiffres, veuillez réessayer.");
                    color.white();
                    return validInput;
                }
                else
                {
                    validInput = true;
                }
            }
            return validInput;
        }

        //Méthode d'affichage de la matrice
        public void displayMatrix(string[,] matrix, ColorChanger color)
        {
            color.darkcyan();
            Console.WriteLine("┌─────┬─────┬─────┬─────┐");
            Console.WriteLine("│ T   │ K   │ Ti  │ E   │");
            Console.WriteLine("├─────┼─────┼─────┼─────┤");
            color.white();
            for (int cursor = 0; cursor < matrix.GetLength(0) - 1; cursor++)
            {
                Console.Write("│ " + matrix[cursor, 0] + "   │ " + matrix[cursor, 1] + "   │ ");
                if (int.Parse(matrix[cursor, 2]) <= 10)
                {
                    Console.Write(matrix[cursor, 2] + "   │ " + matrix[cursor, 3] + "   │\n");
                }
                else
                {
                    Console.Write(matrix[cursor, 2] + "  │ " + matrix[cursor, 3] + "   │\n");
                }
                color.darkcyan();
                Console.WriteLine("├─────┼─────┼─────┼─────┤");
                color.white();
            }
            color.darkcyan();
            Console.WriteLine("└─────┴─────┴─────┴─────┘");
            color.white();
        }
    }
}
