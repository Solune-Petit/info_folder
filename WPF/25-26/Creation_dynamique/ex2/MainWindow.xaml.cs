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

namespace ex2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> animalEmoji = new List<string>()
            {
            "🐈","🐵","🐷","🐱","🐐","🐯","🦊","🐼","🐴","🦝","🦨","🐭","🦉","🐰","🐀","🦔"
            };


            //definition des colonnes
            ColumnDefinition[] colDef = new ColumnDefinition[4];
            for (int i = 0; i < 4; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
            }

            //definition des lignes
            RowDefinition[] rowDef = new RowDefinition[4];
            for (int i = 0; i < 4; i++)
            {
                rowDef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[i]);
            }

            //ajout des boutons
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button btn = new Button();
                    btn.Content = $"?";
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    grdMain.Children.Add(btn);
                    btn.Background = Brushes.Transparent;
                    btn.BorderBrush = Brushes.Transparent;
                }
            }

            //ajout des emojis de façon aléatoire aux boutons lors du click
            Random rand = new Random();
            foreach (Button btn in grdMain.Children)
            {
                int index = rand.Next(animalEmoji.Count);
                string selectedEmoji = animalEmoji[index];
                btn.Tag = selectedEmoji; // Stocke l'emoji dans la propriété Tag du bouton
                btn.Click += (s, e) =>
                {
                    Button clickedButton = s as Button;
                    clickedButton.Content = clickedButton.Tag; // Affiche l'emoji stocké
                };
            }
        }
    }
}