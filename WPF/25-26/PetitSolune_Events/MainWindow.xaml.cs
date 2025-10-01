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

namespace PetitSolune_Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Association des événements aux gestionnaires
            BtnSubmitbtn.Click += new RoutedEventHandler(btnSubmitBtn_Click); // Clic sur le bouton "Submit"
            BtnVbtn.MouseEnter += new MouseEventHandler(BtnVbtn_MouseEnter); // Survol du bouton "V"
            TxtA.PreviewTextInput += new TextCompositionEventHandler(VerfifTextInput); // Saisie dans le TextBox "A"
            TxtB.PreviewTextInput += new TextCompositionEventHandler(VerfifTextInput); // Saisie dans le TextBox "B"
            TxtC.PreviewTextInput += new TextCompositionEventHandler(VerfifTextInput); // Saisie dans le TextBox "C"


        }

        private void VerfifTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender.ToString().Contains(",") && e.Text == ",")
            {
                e.Handled = true; // Empêche la saisie si il y a déjà une virgule
            }
            // Vérifie si le texte saisi est un chiffre ou un point décimal
            if (!double.TryParse(e.Text, out double result) && e.Text != ",")
            {
                
                e.Handled = true; // Empêche la saisie si ce n'est pas un chiffre ou une virgule
            }
        }

        private void BtnVbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            MessageBox.Show("You found me !", "HELLO");
        }

        private void btnSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            double a = int.Parse(TxtA.Text);
            double b = int.Parse(TxtB.Text);
            double c = int.Parse(TxtC.Text);

            ResoudTrinome(a, b, c, out string message);

            MessageBox.Show(message);

            TxtA.Text = "";
            TxtB.Text = "";
            TxtC.Text = "";
        }

        static void ResoudTrinome(double a, double b, double c, out string message)
        {
            double delta = Math.Pow(b, 2) - 4 * a * c;
            if (delta < 0)
            {
                message = "Il n'y a pas de solution réelle";

            }
            else if (delta == 0)
            {
                double x1 = -b / (2 * a);
                message = "Il y a une solution " + x1;
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                message = "Il y a deux solutions " + x1 + " et " + x2;
            }
        }
    }
}