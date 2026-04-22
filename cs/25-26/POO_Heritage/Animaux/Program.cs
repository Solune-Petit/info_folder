namespace Animaux
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!\n" +
                                "\n" +
                                "Bienvenue dans mon zoo.\n" +
                                "Pour le moment, nous n'avons aucuns animal.\n");

            ConsoleKey KeyInput;
            do
            {
                Console.WriteLine("Veuilez choisir quel type d'animal vous voulez ajouter :\n" +
                                    "1. Lapin\n" +
                                    "2. Chat\n" +
                                    "3. Chien\n");
                KeyInput = Console.ReadKey().Key;
                Console.Clear();
            } while (KeyInput != ConsoleKey.D1 && KeyInput != ConsoleKey.D2 && KeyInput != ConsoleKey.D3 && KeyInput != ConsoleKey.NumPad1 && KeyInput != ConsoleKey.NumPad2 && KeyInput != ConsoleKey.NumPad3);

            bool repeat = true;
            do
            {
                switch(KeyInput)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Lapin lapin = new Lapin("Lapinou", DateTime.Now, 12345, 50, false);
                        Console.WriteLine($"Vous avez ajouté un lapin nommé {lapin.Nom}.");
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Chat chat = new Chat("Minou", DateTime.Now, 54321, 30, false);
                        Console.WriteLine($"Vous avez ajouté un chat nommé {chat.Nom}.");
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Chien chien = new Chien("Rex", DateTime.Now, 67890, 60, false);
                        Console.WriteLine($"Vous avez ajouté un chien nommé {chien.Nom}.");
                        break;
                }

            }while (repeat);
        }
    }
}
