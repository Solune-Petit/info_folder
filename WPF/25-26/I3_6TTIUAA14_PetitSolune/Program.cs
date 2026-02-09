namespace I3_6TTIUAA14_PetitSolune
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string temp;
            Console.WriteLine("Bienvenu sur mon paintball !");
            Console.WriteLine("Quel est votre Pseudo ?");
            temp = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Création du joueur");
            PaintBallGun gun = new PaintBallGun(16, 0);
            Joueur player = new Joueur(temp, 30, gun);
            Console.Clear();

            bool restart = true;

            do
            {
                Console.WriteLine(  "Vous démarez avec 30 balles.\n" +
                                    "=======================================================");
                if (player.MyPaintBallGun.ChargeurEstVide())
                {
                    Console.WriteLine("Attention votre chargeur est vide");
                }
                Console.WriteLine(  "\n\nAppuiez sur :\n" +
                                    "Espace pour tirer\n" +
                                    "R pour recharger\n" +
                                    "V pour voir combien de munitions il reste en poche et dans le chargeur\n" +
                                    "+ pour prendre des munitions\n" +
                                    "Q pour quitter\n" +
                                    "--->");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        player.MyPaintBallGun.Tirer();
                        break;

                    case ConsoleKey.R:
                        Console.Clear();
                        temp = player.MyPaintBallGun.NbBallesChargeur.ToString();
                        temp = (16 - int.Parse(temp)).ToString();
                        if(player.NbCartouchesEnPoche >= int.Parse(temp))
                        {
                            player.NbCartouchesEnPoche -= byte.Parse(temp);
                            player.MyPaintBallGun.Recharge();
                        }
                        else
                        {
                            temp = player.NbCartouchesEnPoche.ToString();
                            player.MyPaintBallGun.NbBallesChargeur = byte.Parse(temp);
                        }
                        break;
                    case ConsoleKey.V:
                        Console.Clear();
                        Console.WriteLine($"Il vous restes {player.MyPaintBallGun.NbBallesChargeur} balles dans votre chargeur et {player.NbCartouchesEnPoche} balles dans votre poche\n" +
                            $"Appuiez sur une touche pour sortir");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.OemPlus:
                    case ConsoleKey.Add:
                        Console.Clear();
                        Console.WriteLine($"{player.ReprendreLesCartouches()}\nAppuiez sur une touche pour sortir");
                        break;
                    case ConsoleKey.Q:
                        Console.Clear();
                        restart = false;
                        break;
                }
                Console.Clear();
            } while (restart);
        }
    }
}
