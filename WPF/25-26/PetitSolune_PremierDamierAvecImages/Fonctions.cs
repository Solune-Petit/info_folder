using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PetitSolune_PremierDamierAvecImages
{
    class Fonctions
    {
        public void Exercice1(Grid grdMain)
        {
            //faire une grille de 8x8 avec des images
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

        public void Exercice2(Grid grdMain)
        {

        }

        public void Exercice3(Grid grdMain)
        {

        }
    }
}
