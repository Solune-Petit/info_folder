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

namespace ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //création de la grille
            ColumnDefinition[] colDef = new ColumnDefinition[3];
            for (int i = 0; i < 3; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
            }

            RowDefinition[] rowDef = new RowDefinition[3];
            for (int i = 0; i < 3; i++)
            {
                rowDef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[i]);
            }
            

            //création du titre
            TextBlock tblTitre = new TextBlock();
            tblTitre.Text = "Textblock créé dynamiquement";
            tblTitre.FontFamily = new FontFamily("Arial");
            tblTitre.FontSize = 24;
            tblTitre.FontWeight = FontWeights.UltraBold;
            tblTitre.Background = Brushes.Yellow;
            tblTitre.Foreground = Brushes.Red;
            tblTitre.Margin = new Thickness(0,50,0,50);
            Grid.SetColumn(tblTitre, 0);
            Grid.SetRow(tblTitre, 0);
            Grid.SetColumnSpan(tblTitre, 3);
            grdMain.Children.Add(tblTitre);

            //création des boutons centraux
            Button btn1 = new Button();
            Button btn2 = new Button();
            Button btn3 = new Button();
            btn1.Content = "bouton 1";
            btn2.Content = "bouton 2";
            btn3.Content = "bouton 3";
            btn1.Height = 150;
            btn2.Height = 150;
            btn3.Height = 150;
            btn1.Width = 150;
            btn2.Width = 150;
            btn3.Width = 150;
            Grid.SetColumn(btn1, 0);
            Grid.SetRow(btn1, 1);
            Grid.SetColumn(btn2, 1);
            Grid.SetRow(btn2, 1);
            Grid.SetColumn(btn3, 2);
            Grid.SetRow(btn3, 1);
            grdMain.Children.Add(btn1);
            grdMain.Children.Add(btn2);
            grdMain.Children.Add(btn3);

            //création du stackpannel d'en bas à gauche
            StackPanel sctk2_0 = new StackPanel();
            sctk2_0.Margin = new Thickness(0, 50, 0, 0);
            Grid.SetRow(sctk2_0, 2);
            Grid.SetColumn(sctk2_0, 0);
            Grid.SetColumnSpan(sctk2_0, 2);
            grdMain.Children.Add(sctk2_0);

            TextBlock tblInfos = new TextBlock();
            tblInfos.Text = "Informations :";
            tblInfos.FontFamily = new FontFamily("Arial");
            tblInfos.FontSize = 18;
            tblInfos.FontWeight = FontWeights.Bold;
            tblInfos.Height = 50;
            tblInfos.Background = Brushes.Yellow;
            sctk2_0.Children.Add(tblInfos);

            TextBox tbxInfos = new TextBox();
            tbxInfos.Text = "j'attends vos infos.";
            sctk2_0.Children.Add(tbxInfos);

            //création de la combobox
            ComboBox cmbbxListe = new ComboBox();
            cmbbxListe.Margin = new Thickness(0, 50, 0, 0);
            Grid.SetRow(cmbbxListe, 2);
            Grid.SetColumn(cmbbxListe, 2);
            grdMain.Children.Add(cmbbxListe);
            cmbbxListe.Items.Add("élément 1");
            cmbbxListe.Items.Add("élément 2");
        }
    }
}