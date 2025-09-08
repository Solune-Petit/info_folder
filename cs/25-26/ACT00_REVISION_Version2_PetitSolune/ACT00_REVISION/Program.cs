using _5T24_PetitSolune_enigma;
using System;

namespace ACT00_REVISION
{
    class Program
    {
        static void Main(string[] args)
        {
            //déclaration des variables

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            string rep;
            string infos;
            double c1 = 0;
            double c2 = 0;
            double c3 = 0;
            bool ok = false;
            bool tester;
            // instanciation de la structure MethodesDuProjet
            MethodesDuProjet func = new MethodesDuProjet();
            
            string fgroundColor;
            string bkgroundColor;


                Console.WriteLine("Testez les polygones !\n" +
                    "Nous allons commencer par personnaliser votre console.\nDe quelle couleur voulez-vous que le fond du texte soit ?");
                bkgroundColor = Console.ReadLine();

            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), bkgroundColor, true);

                Console.WriteLine("De quelle couleur voulez vous que le texte soit ?");
                fgroundColor = Console.ReadLine();
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), fgroundColor, true);


            //On recommence tant que désiré
            do
            {
                //lecture des 3 côtés => A FAIRE
                c1 = func.Parser(1);
                c2 = func.Parser(2);
                c3 = func.Parser(3);

                func.OrdonneCotes(ref c1, ref c2, ref c3);
                
                // série de test (voir consignes)
                if (func.Triangle(c1, c2, c3))
                {
                    // préparation et affichage du résultat du test 'triangle' avec la procédure 'Affiche'
                    func.PreparaAffichge(true, "triangle", out infos);
                    Console.WriteLine(infos);

                    // vérification équilatéral
                    if (func.Equi(c1, c2, c3))
                    {
                        // préparation et affichage du résultat du test 'equilateral' avec la procédure 'Affiche'
                        func.PreparaAffichge(true, "equilatéral", out infos);
                        Console.WriteLine(infos);
                    }
                    else
                    {
                        // vérification triangle rectangle
                        if (func.TriangleRectangle(c1, c2, c3))
                        {
                            // préparation et affichage du résultat positif du test 'rectangle' avec la procédure 'Affiche'
                            func.PreparaAffichge(true, "rectangle", out infos);
                            Console.WriteLine(infos);
                        }
                        else
                        {
                            // préparation et affichage du résultat négatif du test 'rectangle' avec la procédure 'Affiche'
                            func.PreparaAffichge(false, "rectangle", out infos);
                            Console.WriteLine(infos);
                        }
                        // vérification du cas isocèle et affichage dans le cas positif
                        if (func.Isocele(ref c1, ref c2, ref c3))
                        {
                            func.PreparaAffichge(true, "isocèle", out infos);
                            Console.WriteLine(infos);
                        }                        
                        
                    }
                }
                else // si ce n'est pas un triangle
                {
                    // préparation et affichage du résultat négataif du test 'triangle' avec la procédure 'Affiche'
                    func.PreparaAffichge(false, "ce n'est pas un triangle", out infos);
                    Console.WriteLine(infos);
                }
                // reprise ?
                Console.WriteLine("Voulez-vous tester un autre polygône ? (Tapez espace)");
                rep = Console.ReadLine();
            } while (rep == " ");
        }
    }
}
