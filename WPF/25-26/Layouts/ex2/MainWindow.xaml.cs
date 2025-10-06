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
        public double FirstNumber, SecondNumber, result;
        public char Operation;
        public MainWindow()
        {
            InitializeComponent();
            TbxScreen.Text = "";
            TbxScreen.PreviewTextInput += new TextCompositionEventHandler(VerifyTextInput);
            Btn0.Click += new RoutedEventHandler(Btn0_Click);
            Btn1.Click += new RoutedEventHandler(Btn1_Click);
            Btn2.Click += new RoutedEventHandler(Btn2_Click);
            Btn3.Click += new RoutedEventHandler(Btn3_Click);
            Btn4.Click += new RoutedEventHandler(Btn4_Click);
            Btn5.Click += new RoutedEventHandler(Btn5_Click);
            Btn6.Click += new RoutedEventHandler(Btn6_Click);
            Btn7.Click += new RoutedEventHandler(Btn7_Click);
            Btn8.Click += new RoutedEventHandler(Btn8_Click);
            Btn9.Click += new RoutedEventHandler(Btn9_Click);
            BtnComma.Click += new RoutedEventHandler(BtnComma_Click);
            BtnClear.Click += new RoutedEventHandler(BtnClear_Click);
            BtnPlus.Click += new RoutedEventHandler(BtnPlus_Click);
            BtnEquals.Click += new RoutedEventHandler(BtnEquals_Click);
            BtnMinus.Click += new RoutedEventHandler(BtnMinus_Click);
            BtnMultiply.Click += new RoutedEventHandler(BtnMultiply_Click);
            BtnDivide.Click += new RoutedEventHandler(BtnDivide_Click);
        }

        private void VerifyTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only digits, comma, and basic arithmetic operators
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != "," && e.Text != "+" && e.Text != "-" && e.Text != "*" && e.Text != "/")
            {
                e.Handled = true;
            }

            //allow for dots to be used as commas
            if (e.Text == ".")
            {
                e.Handled = true;
                TbxScreen.Text += ",";

                // Prevent multiple commas in a number
                if ((e.Text == "," || e.Text == ".") && TbxScreen.Text.Contains(","))
                {
                    TbxScreen.Text = TbxScreen.Text.Remove(TbxScreen.Text.Length - 1);
                }
            }

            // Prevent leading comma
            if (e.Text == "," && TbxScreen.Text == "")
            {
                e.Handled = true;
                TbxScreen.Text = "0,";
            }

            // Prevent multiple commas in a number
            if ((e.Text == "," || e.Text == "." ) && TbxScreen.Text.Contains(","))
            {
                e.Handled = true;
            }

            // Handle operator input
            if (e.Text == "+" || e.Text == "-" || e.Text == "*" || e.Text == "/")
            {
                e.Handled = true; // Prevent the operator from being added to the TextBox
                if (TbxScreen.Text != "")
                {
                    if (FirstNumber == 0)
                    {
                        FirstNumber = double.Parse(TbxScreen.Text);
                    }
                    Operation = e.Text[0];
                    TbxScreen.Text = "";
                }
            }
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            if (TbxScreen.Text != "")
            {
                TbxScreen.Text += "0";
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            TbxScreen.Text += "1";
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            TbxScreen.Text += "2";
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            TbxScreen.Text += "3";
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            TbxScreen.Text += "4";
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            TbxScreen.Text += "5";
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            TbxScreen.Text += "6";
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            TbxScreen.Text += "7";
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            TbxScreen.Text += "8";
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            TbxScreen.Text += "9";
        }

        private void BtnComma_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TbxScreen.Text = "";
            FirstNumber = 0;
            SecondNumber = 0;
            Operation = '\0';
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (TbxScreen.Text != "")
            {
                if (FirstNumber == null)
                {
                    FirstNumber = double.Parse(TbxScreen.Text);
                }

                Operation = '+';
                TbxScreen.Text = "";
            }
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (TbxScreen.Text != "")
            {
                if (FirstNumber == null)
                {
                    FirstNumber = double.Parse(TbxScreen.Text);
                }

                Operation = '-';
                TbxScreen.Text = "";
            }
        }

        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            if (TbxScreen.Text != "")
            {
                if (FirstNumber == null)
                {
                    FirstNumber = double.Parse(TbxScreen.Text);
                }

                Operation = '*';
                TbxScreen.Text = "";
            }
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            if (TbxScreen.Text != "")
            {
                if (FirstNumber == null)
                {
                    FirstNumber = double.Parse(TbxScreen.Text);
                }

                Operation = '/';
                TbxScreen.Text = "";
            }
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (TbxScreen.Text == "")
            {
                MessageBox.Show("Please enter a number before calculating.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }else if (FirstNumber == null)
            {
                MessageBox.Show("Please enter an operation before calculating.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SecondNumber = double.Parse(TbxScreen.Text);

                Calculate();
            }
        }

        private void Calculate()
        {
            switch (Operation)
            {
                case '+':
                    result = FirstNumber + SecondNumber;
                    break;
                case '-':
                    result = FirstNumber - SecondNumber;
                    break;
                case '*':
                    result = FirstNumber * SecondNumber;
                    break;
                case '/':
                    if (SecondNumber == 0)
                    {
                        MessageBox.Show("Cannot divide by zero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    result = FirstNumber / SecondNumber;
                    break;
                default:
                    MessageBox.Show("Invalid operation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
            TbxScreen.Text = result.ToString();
            FirstNumber = result;
            SecondNumber = 0;
            Operation = '\0';
        }

    }
}