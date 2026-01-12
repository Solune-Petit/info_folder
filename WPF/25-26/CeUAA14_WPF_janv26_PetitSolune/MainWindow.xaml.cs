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

namespace CeUAA14_WPF_janv26_PetitSolune
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Button btnCases;

        public MainWindow()
        {
            InitializeComponent();

            tbxTaille.PreviewTextInput += new TextCompositionEventHandler(VerifNbrCases);
            tbxSymbole.PreviewTextInput += new TextCompositionEventHandler(VerifTypeJoueur);
            btnAvancer.Click += new RoutedEventHandler(btnDes_Click);
            btnTaille.Click += new RoutedEventHandler(btnTaille_Click);


        }

        private void VerifNbrCases(object sender, TextCompositionEventArgs e)
        {
            if(!int.TryParse(e.Text, out int value))
            {
                e.Handled = true;
            }else if(int.Parse(e.Text) > 11)
            {
                e.Handled = true;
            }
        }

        private void VerifTypeJoueur(object sender, TextCompositionEventArgs e)
        {
            if ((e.Text != "h" && e.Text != "p"))
            {
                e.Handled = true;
            }
        }

        private void btnDes_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnTaille_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(tbxTaille.Text) < 11)
            {
                int taille = int.Parse(tbxTaille.Text);
                int[,] plateau = GenererplateauNumerique(taille);

                for (int i = 0; i < plateau.GetLength(0); i++)
                {
                    for (int j = 0; j < plateau.GetLength(1); j++)
                    {
                        btnCases = new Button();
                        btnCases.Width = (int)((10F / 13F) * 806F / int.Parse(tbxTaille.Text));
                        btnCases.Height = (int)((10F / 12F) * 732F / int.Parse(tbxTaille.Text));
                        btnCases.HorizontalAlignment = HorizontalAlignment.Left;
                        btnCases.VerticalAlignment = VerticalAlignment.Bottom;
                        Grid.SetColumn(btnCases, 0);
                        Grid.SetRow(btnCases, 1);
                        grdMain.Children.Add(btnCases);
                    }
                }
            }
        }

        /// <summary>
        /// Fabrique une matrice de même taille que la matrice de boutons.
        /// Elle contient les numéros dans le bon ordre à placer ensuite sur les boutons.
        /// </summary>
        /// <param name="taille">nombre de lignes et de colonnes dans la matrice de boutons</param>
        /// <returns>matrice carrée d'entiers comprenant 'taille' lignes, contenant des valeurs entières commençant à 1 en bas à gauche 
        /// et comptant en ajoutant 1 en serpentant dans la matrice </returns>
        static int[,] GenererplateauNumerique(int taille)
        {
            int[,] plateau = new int[taille, taille];
            int valeur = 1;

            // On part de la ligne du bas de la matrice et on remonte vers le haut
            for (int ligne = taille - 1; ligne >= 0; ligne--)
            {
                bool gaucheVersDroite = ((taille - 1 - ligne) % 2 == 0);    // permet de déterminer dans quel sens on compte. On aura une expression vraie quant on compte de gauche à droite

                if (gaucheVersDroite)
                {
                    //On rempli la ligne de gauche à droite en incrémentant le comptage
                    for (int colonne = 0; colonne < taille; colonne++)
                    {
                        plateau[ligne, colonne] = valeur++;
                    }
                }
                else
                {
                    //On rempli la ligne de droite à gauche en incrémentant le comptage
                    for (int colonne = taille - 1; colonne >= 0; colonne--)
                    {
                        plateau[ligne, colonne] = valeur++;
                    }
                }
            }

            return plateau;
        }

        /// <summary>
        /// Procédure permettant de lancer un dé, et faire avancer le pion du joueur
        /// </summary>
        /// <param name="symboleJoueur">Symbole marquant la position du joueur</param>
        /// <param name="numeroJoueur">numero du joueur (1 ou 2)</param>
        /// <param name="totalJoueur">Compte cumulé des dés sortis</param>
        /// <param name="positionPionJoueur">Première place = numéro de ligne, seconde place = numéro de colonne</param>
        /// <param name="ancienneValeur">valeur numérique de la case où se trouve le joueur</param>
        //public void TourJoueur(string symboleJoueur, int numeroJoueur, ref int totalJoueur, ref int[] positionPionJoueur, ref string ancienneValeur)
        //{
        //    Random alea = new Random();         // nombre aléatoire
        //    int taille = btnCases.GetLength(0); // nombre de lignes dans le plateau
        //    int maxCases = taille * taille;     // nombre de cases maximum

        //    // dé sorti
        //    int de = alea.Next(1, 7);

        //    // modification de l'interface pour l'affichage du numéro du joueur et du dé
        //    txtQuiJoue.Text = "Joueur " + numeroJoueur;
        //    txtDe.Text = "Dé : " + de;

        //    // calcul total déjà parcouru par le joueur
        //    totalJoueur += de;

        //    // Si on dépasse le nombre total de cases, on fixe à la dernière possible
        //    if (totalJoueur > maxCases)
        //    {
        //        totalJoueur = maxCases;
        //    }

        //    // Retirer le symbole du joueur à l'ancienne position et faire apparaître le numéro qu'il cachait
        //    btnCases[positionPionJoueur[0], positionPionJoueur[1]].Content = ancienneValeur;
        //    btnCases[positionPionJoueur[0], positionPionJoueur[1]].Foreground = Brushes.Black;

        //    // recherche de la nouvelle position du joueur
        //    int index = totalJoueur - 1;

        //    int ligneDepuisBas = index / taille;
        //    int colonneDansLigne = index % taille;

        //    positionPionJoueur[0] = taille - 1 - ligneDepuisBas;

        //    bool gaucheVersDroite = ligneDepuisBas % 2 == 0;

        //    positionPionJoueur[1] = gaucheVersDroite
        //        ? colonneDansLigne
        //        : taille - 1 - colonneDansLigne;

        //    // Fin de partie
        //    if (totalJoueur == maxCases)
        //    {
        //        txtQuiJoue.Text = "Fin !";
        //        btnAvancer.IsEnabled = false;
        //    }

        //    // mémorisation du numéro de la case sur laquelle on va placer le symbole du joueur
        //    // + affichage de ce symbole
        //    ancienneValeur = btnCases[positionPionJoueur[0], positionPionJoueur[1]].Content.ToString();
        //    btnCases[positionPionJoueur[0], positionPionJoueur[1]].Content = symboleJoueur;
        //    btnCases[positionPionJoueur[0], positionPionJoueur[1]].Foreground = Brushes.Gold;
        //}
    }
}