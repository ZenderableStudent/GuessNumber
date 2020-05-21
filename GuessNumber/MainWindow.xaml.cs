using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuessNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int lives = 10;
        private int random = 0;
        public MainWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            random = rnd.Next() % 100;
        }
        private void txbGuessNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(lives == 0)
            {
                lblFrom.Content = "You";
                lblTo.Content = "lost!";
                return;
            }
            if(e.Key == Key.Enter)
            {
                lives--;
                int userGuessed = Int32.Parse(txbGuessNumber.Text);
                if(userGuessed == random)
                {
                    lblFrom.Content = "You";
                    lblTo.Content = "won!";
                    return;
                }
                if(userGuessed < random)
                {
                    lblFrom.Content = userGuessed.ToString();
                }
                else
                {
                    lblTo.Content = userGuessed;
                }
                lblLivesStatus.Content = $"Lives remaining: {lives}";
            }
            if(lives <= 3)
            {
                lblLivesStatus.Foreground = Brushes.Red;
            }
        }
    }
}
