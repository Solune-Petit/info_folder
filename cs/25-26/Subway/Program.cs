namespace Subway
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool anotherSandwich = false;
            do
            {
                Console.WriteLine("Voulez vous un sandwich aléatoire");
                string Uinput = Console.ReadLine().ToLower();
                Console.Clear();
                if (Uinput == "oui" || Uinput == "y")
                {
                    SandwichMaker sandwichMaker = new SandwichMaker();
                    Console.WriteLine(sandwichMaker.composeSandwich());
                    anotherSandwich = true;
                }
                else
                {
                    Console.WriteLine("pourquoi avoir lancé le programme alors ?");
                    anotherSandwich = false;
                }
            } while (anotherSandwich);
        }
    }
}
