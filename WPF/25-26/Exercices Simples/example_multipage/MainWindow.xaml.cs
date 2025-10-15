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

namespace example_multipage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnPage1.Click += new RoutedEventHandler(BtnPage1_Click);
            btnPage2.Click += new RoutedEventHandler(BtnPage2_Click);
            MainFrame.Content = new Acceuil();
        }

        private void BtnPage1_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page1();
        }

        private void BtnPage2_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page2();
        }
    }
}