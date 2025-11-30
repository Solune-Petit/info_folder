using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PetitSolune_PremierDamierAvecImages
{
    class Fonctions
    {
        public Window wndMain = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault();

        //faire une grille de 8x8 avec des images
        public void Exercice1(Grid grdMain)
        {
            ColumnDefinition[] colDef = new ColumnDefinition[8];
            RowDefinition[] rowDef = new RowDefinition[8];
            for (int i = 0; i < 8; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
                rowDef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[i]);
            }

            int rows = 8;
            int columns = 8;
            //faire le damier avec des pions dans chaque cases avec la couleur faite avec le background
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("assets/p.png", UriKind.Relative));
                    Button btnPion = new Button();
                    if ((i + j) % 2 == 0)
                    {
                        btnPion.Background = Brushes.White;
                    }
                    else
                    {
                        btnPion.Background = Brushes.Black;
                    }
                    Grid.SetRow(btnPion, i);
                    Grid.SetColumn(btnPion, j);
                    btnPion.Content = img;
                    grdMain.Children.Add(btnPion);
                }
            }
        }


        //faire un échiquier de 8x8 avec des images des pièces d'échecs dans leurs positions de départ
        public void Exercice2(Grid grdMain)
        {
            //définir la taille de la grille
            int rows = 8;
            int columns = 8;
            ColumnDefinition[] colDef = new ColumnDefinition[8];
            RowDefinition[] rowDef = new RowDefinition[8];
            for (int i = 0; i < 8; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
                rowDef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[i]);
            }

            //faire le damier avec des pions dans chaque cases avec la couleur faite avec le background
            string[,] pieces = new string[8, 8]
            {
                { "t", "kn", "b", "q", "k", "b", "kn", "t" },
                { "p", "p", "p", "p", "p", "p", "p", "p" },
                { "", "", "", "", "", "", "", "" },
                { "", "", "", "", "", "", "", "" },
                { "", "", "", "", "", "", "", "" },
                { "", "", "", "", "", "", "", "" },
                { "p", "p", "p", "p", "p", "p", "p", "p" },
                { "t", "kn", "b", "q", "k", "b", "kn", "t" }
            };

            //placer les pièces
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button btnPiece = new Button();
                    Image img = new Image();
                    if (pieces[i, j] != "")
                    {
                        string color = (i < 2) ? "b" : "w";
                        img.Source = new BitmapImage(new Uri($"assets/{pieces[i, j]}.png", UriKind.Relative));
                        btnPiece.Content = img;
                    }
                    if ((i + j) % 2 == 0)
                    {
                        btnPiece.Background = Brushes.White;
                    }
                    else
                    {
                        btnPiece.Background = Brushes.Black;
                    }
                    Grid.SetRow(btnPiece, i);
                    Grid.SetColumn(btnPiece, j);
                    grdMain.Children.Add(btnPiece);
                }
            }
        }


        //créer un échéquier de 10x10 avec des chiffres en rouges et gras de 1 à 100 dans chaque case
        public void Exercice3(Grid grdMain)
        {
            //mettre les dimensions de la fenêtre à 660x660
            wndMain.Width = 660;
            wndMain.Height = 660;

            //définir la taille de la grille
            int rows = 10;
            int columns = 10;
            ColumnDefinition[] colDef = new ColumnDefinition[10];
            RowDefinition[] rowDef = new RowDefinition[10];
            for (int i = 0; i < 10; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
                rowDef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[i]);
            }
            //faire le damier avec des chiffres de 1 à 100 dans chaque case et les cases de dimensions 65X65
            int number = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button btnNumber = new Button();
                    btnNumber.Width = 65;
                    btnNumber.Height = 65;
                    btnNumber.FontSize = 25;
                    btnNumber.FontWeight = FontWeights.Bold;
                    btnNumber.Foreground = Brushes.Red;
                    btnNumber.Content = number.ToString();
                    if ((i + j) % 2 == 0)
                    {
                        btnNumber.Background = Brushes.White;
                    }
                    else
                    {
                        btnNumber.Background = Brushes.Black;
                    }
                    Grid.SetRow(btnNumber, i);
                    Grid.SetColumn(btnNumber, j);
                    grdMain.Children.Add(btnNumber);
                    number++;
                }
            }
        }


        //créer un échéquier de 10x10 avec des chiffres en rouges et gras de 1 à 100 en faisant serpenter les numéros dans les case 
        public void Exercice4(Grid grdMain)
        {
            //mettre les dimensions de la fenêtre à 660x660
            wndMain.Width = 660;
            wndMain.Height = 660;

            //définir la taille de la grille
            int rows = 10;
            int columns = 10;
            ColumnDefinition[] colDef = new ColumnDefinition[10];
            RowDefinition[] rowDef = new RowDefinition[10];
            for (int i = 0; i < 10; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
                rowDef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[i]);
            }


            //faire le damier avec des chiffres de 1 à 100 dans chaque case et les cases de dimensions 65X65 en faisant serpenter les numéros
            int number = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button btnNumber = new Button();
                    btnNumber.Width = 65;
                    btnNumber.Height = 65;
                    btnNumber.FontSize = 25;
                    btnNumber.FontWeight = FontWeights.Bold;
                    btnNumber.Foreground = Brushes.Red;
                    if (i % 2 == 0)
                    {
                        btnNumber.Content = number.ToString();
                    }
                    else
                    {
                        btnNumber.Content = (number + (columns - 1 - 2 * j)).ToString();
                    }
                    if ((i + j) % 2 == 0)
                    {
                        btnNumber.Background = Brushes.White;
                    }
                    else
                    {
                        btnNumber.Background = Brushes.Black;
                    }
                    Grid.SetRow(btnNumber, i);
                    Grid.SetColumn(btnNumber, j);
                    grdMain.Children.Add(btnNumber);
                    number++;
                }
            }
        }
    }
}
