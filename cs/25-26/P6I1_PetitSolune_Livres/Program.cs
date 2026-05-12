using _5T24_PetitSolune_enigma;

namespace P6I1_PetitSolune_Livres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //initialliser les classes
            ColorChanger c = new ColorChanger();
            Livre[] bouquins = new Livre[3];
            fonctions func = new fonctions();

            c.red();
            Console.WriteLine("Interro UML 1 : Livres");
            c.yellow();
            Console.WriteLine("un tableau de 3 livres se fait automatiquement remplir");

            string[,] temp = func.GenererTableau();

            bouquins[0] = new Livre(temp[0,0], temp[0,1], temp[0,2], temp[0,4], int.Parse(temp[0, 3]));
            bouquins[1] = new Livre(temp[1, 0], temp[1, 1], temp[1, 2], temp[1, 4], int.Parse(temp[1, 3]));
            bouquins[2] = new Livre(temp[2, 0], temp[2, 1], temp[2, 2], temp[2, 4], int.Parse(temp[2, 3]));

            Console.WriteLine("tableau généré.");
            Console.ReadKey();
            Console.Clear();
            c.blue();
            Console.WriteLine("Vous allez maintenant lire le livre 2 et le livre 3");
            Console.ReadKey();
            Console.Clear();
            c.green();
            Console.WriteLine($"Le livre {bouquins[1].Titre()} est {bouquins[1].CommencerLecture()}");
            Console.WriteLine($"Le livre {bouquins[2].Titre()} est {bouquins[2].CommencerLecture()}");
            Console.ReadKey();
            Console.Clear();
            c.blue();
            Console.WriteLine("Vous allez maintenant recevoir les informations des 3 livres");
            Console.ReadKey();
            Console.Clear();
            c.green();
            Console.WriteLine($"{bouquins[0].DonneInfos()}\n" +
                $"-----------------------------------------------\n");
            Console.WriteLine($"{bouquins[0].DonneInfos()}\n" +
                $"-----------------------------------------------\n"); Console.WriteLine($"{bouquins[2].DonneInfos()}\n\n");
            Console.WriteLine($"{bouquins[0].DonneInfos()}\n" +
                $"-----------------------------------------------\n");

            Console.ReadKey();
            Console.Clear();
            c.blue();
            Console.WriteLine("Vous allez maintenant finir de lire le livre 2");

            Console.ReadKey();
            Console.Clear();
            c.green();
            Console.WriteLine($"Le livre {bouquins[1].Titre()} est {bouquins[1].TerminerLecture()}");

            Console.ReadKey();
            Console.Clear();
            c.blue();
            Console.WriteLine("Vous allez maintenant recevoir les nouvelles informations du livre 2");

            Console.ReadKey();
            Console.Clear();
            c.green();
            Console.WriteLine(bouquins[1].DonneInfos());
            c.white();
        }
    }
}
