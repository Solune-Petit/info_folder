namespace Parallelepipede
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenu.\n");
            ConsoleKey KeyInput;

            do
            {
                Console.Clear();
                do
                {
                    Console.WriteLine("choisissez une forme géométrique :\n" +
                                      "1. Carré\n" +
                                      "2. Rectangle\n\n" +
                                      "Pour sortir, appuiez sur escape");
                    KeyInput = Console.ReadKey().Key;
                } while (KeyInput != ConsoleKey.D1 && KeyInput != ConsoleKey.D2 && KeyInput != ConsoleKey.NumPad1 && KeyInput != ConsoleKey.NumPad2 && KeyInput != ConsoleKey.Escape);

                Console.Clear();
                string Uinput;
                switch (KeyInput)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Vous avez choisi le carré.\n\n");

                        double cote;
                        do
                        {
                            Console.WriteLine("Entrez la longueur du côté du carré :\n");
                            Uinput = Console.ReadLine();
                        } while (!double.TryParse(Uinput, out cote) || cote <= 0);
                        Console.Clear();
                        Console.WriteLine("Entrez la couleur du carré :\n");
                        string couleur = Console.ReadLine();
                        Carre carre = new Carre(cote, couleur);
                        Console.Clear();
                        Console.WriteLine($"{carre.Infos()}\n\n" +
                                    $"le périmètre du carré est de {carre.CalculerPerimetre()}\n\n" +
                                    $"la surface du carré est de {carre.CalculerSurface()}\n\n" +
                                    $"pour sortir de ce menu, appuiez sur une touche");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("Vous avez choisi le rectangle.\n\n");
                        double longueur, largeur;
                        do
                        {
                            Console.WriteLine("Entrez la longueur du rectangle :\n");
                            Uinput = Console.ReadLine();
                        } while (!double.TryParse(Uinput, out longueur) || longueur <= 0);
                        Console.Clear();
                        do
                        {
                            Console.WriteLine("Entrez la largeur du rectangle :\n");
                            Uinput = Console.ReadLine();
                        } while (!double.TryParse(Uinput, out largeur) || largeur <= 0);
                        Console.Clear();
                        Console.WriteLine("Entrez la couleur du rectangle :\n");
                        couleur = Console.ReadLine();
                        Rectangle rectangle = new Rectangle(longueur, largeur, couleur);

                        Console.Clear();
                        Console.WriteLine($"{rectangle.Infos()}\n\n" +
                                    $"le périmètre du rectangle est de {rectangle.CalculerPerimetre()}\n\n" +
                                    $"la surface du rectangle est de {rectangle.CalculerSurface()}\n\n" +
                                    $"pour sortir de ce menu, appuiez sur une touche");
                        Console.ReadKey();
                        break;

                }
            } while (KeyInput != ConsoleKey.Escape);
        }
    }
}
