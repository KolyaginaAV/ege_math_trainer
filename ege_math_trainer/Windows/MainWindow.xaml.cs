using ege_math_trainer.Models;
using ege_math_trainer.Windows;
using System.Windows;

namespace ege_math_trainer
{

    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            InitializeComponent();
            TextUserName.Text = user.Name;
        }
        private void ButtonCanselMain(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }
    }
}