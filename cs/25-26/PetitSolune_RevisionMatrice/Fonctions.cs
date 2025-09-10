using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitSolune_RevisionMatrice
{
    internal class Fonctions
    {
        public string Vigenere(string text, string key)
        {
            string[,] encoder = new string[text.Length, 4];
            for (int cursor = 0; cursor < text.Length; cursor++)
            {
                encoder[cursor, 0] = text[cursor].ToString().ToUpper();
                if (cursor < key.Length)
                {
                    encoder[cursor, 1] = key[cursor].ToString().ToUpper();
                }
                else
                {
                    encoder[cursor, 1] = key[cursor % key.Length].ToString().ToUpper();
                }
                encoder[cursor, 2] = ((int)text[cursor] - 65).ToString();
                encoder[cursor, 3] = Convert.ToString((((int)text[cursor] - 65) + ((int)encoder[cursor, 2][0] - 65)) % 26 + 65);
            }
            return encoder.ToString();
        }
    }
}
