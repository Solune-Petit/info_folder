namespace PetitSolune_ExerciceChien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chien monChien = new Chien("Rex", "Berger Allemand", "Court", "12345", 5, 60, 30, 8, false);

            Console.WriteLine(monChien.Sauter());
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(monChien.Aboyer());
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(monChien.Manger());
            Console.ReadKey();
            Console.Clear();
        }
    }
}
