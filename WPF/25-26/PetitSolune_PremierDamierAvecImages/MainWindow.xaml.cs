using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PetitSolune_PremierDamierAvecImages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Fonctions func = new Fonctions();
            //définir la taille de la grille

            for (int i = 0; i <= 3; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef);
            }

            //faire les boutons
            Button btnEx1 = new Button();
            btnEx1.Content = "Exercice 1";
            Grid.SetColumn(btnEx1, 0);
            Grid.SetRow(btnEx1, 0);
            grdMain.Children.Add(btnEx1);

            Button btnEx2 = new Button();
            btnEx2.Content = "Exercice 2 (en création)";
            Grid.SetColumn(btnEx2, 1);
            Grid.SetRow(btnEx2, 0);
            grdMain.Children.Add(btnEx2);

            Button btnEx3 = new Button();
            btnEx3.Content = "Exercice 3 (pas commencé)";
            Grid.SetColumn(btnEx3, 2);
            Grid.SetRow(btnEx3, 0);
            grdMain.Children.Add(btnEx3);


            btnEx1.Click += (s, e) =>
            {
                grdMain.Children.Clear();
                grdMain.ColumnDefinitions.Clear();
                grdMain.RowDefinitions.Clear();
                func.Exercice1(grdMain);
            };

            btnEx2.Click += (s, e) =>
            {
                grdMain.Children.Clear();
                grdMain.ColumnDefinitions.Clear();
                grdMain.RowDefinitions.Clear();
                func.Exercice2(grdMain);
            };

            btnEx3.Click += (s, e) =>
            {
                grdMain.Children.Clear();
                grdMain.ColumnDefinitions.Clear();
                grdMain.RowDefinitions.Clear();
                func.Exercice3(grdMain);
            };



        }
    }
}