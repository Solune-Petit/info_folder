using _5T24_PetitSolune_enigma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitSolune_ExerciceChien
{
    internal class function
    {
        public void menu(ColorChanger c)
        {
            c.darkblue();
            Console.WriteLine("Bienvenue sur mon jeu du chien\n\n");
            c.white();
            Console.Write("voici vos options :\n\n\n\n");
            c.green();
            Console.Write("0. ");
            c.white();
            Console.Write("Voire les infos du chien\n\n");
            c.green();
            Console.Write("1. ");
            c.white();
            Console.Write("Faire sauter le chien\n\n");
            c.green();
            Console.Write("2. ");
            c.white();
            Console.Write("Faire aboyer le chien\n\n");
            c.green();
            Console.Write("3. ");
            c.white();
            Console.Write("Faire manger le chien\n\n");
            c.green();
            Console.Write("4. ");
            c.white();
            Console.Write("Faire vieillir le chien\n\n");
            c.green();
            Console.Write("5. ");
            c.white();
            Console.Write("Quitter le programme\n\n");
        }

        public string dogTagTable(Chien[] monChien, int dogCount, ColorChanger c)
        {
            string message = "+----------+---------------------------------------\n|  ";
            c.Bgblue();                
            message += "Chiens";
            c.Bgblack();
            message += "  |";

            for (int i = 0; i < dogCount; i++)
            {
                message += $"  {monChien[i].nom()}  |  ";
            }

            message +=        "\n+----------+---------------------------------------";

            return message;
        }
    }
}
