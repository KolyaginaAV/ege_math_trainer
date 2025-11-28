using System.Windows;

namespace ege_math_trainer.Windows
{
    public partial class FirstPartTasksWindow : Window
    {
        public FirstPartTasksWindow(int taskId)
        {
            InitializeComponent();
        }

        private void ButtonFirstPartTasksDecision(object sender, RoutedEventArgs e)
        {
            DecisionTaskWindow decisionTaskWindow = new DecisionTaskWindow();
            decisionTaskWindow.ShowDialog();
        }

        private void ButtonFirstPartTasksCanselToMain(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow(autUser);
            //mainWindow.Show();
            //this.Close();
        }

        private void ButtonFirstPartTasksCansel(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Вы хотите выйти и вернуться к авторизации?",
                "Предупреждение",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
                this.Close();
            }
        }
    }
}
