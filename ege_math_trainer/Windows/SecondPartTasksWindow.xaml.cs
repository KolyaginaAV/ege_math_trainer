using System.Windows;

namespace ege_math_trainer.Windows
{
    public partial class SecondPartTasksWindow : Window
    {
        public SecondPartTasksWindow()
        {
            InitializeComponent();
        }

        private void ButtonSecondPartTasksCanselToMain(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSecondPartTasksCansel(object sender, RoutedEventArgs e)
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

        private void ButtonSecondPartTasksDecision(object sender, RoutedEventArgs e)
        {
            DecisionTaskWindow decisionTaskWindow = new DecisionTaskWindow();
            decisionTaskWindow.ShowDialog();
        }

        private void ButtonSecondPartTasksCriteria(object sender, RoutedEventArgs e)
        {
            TaskEvaluationCriteriaWindow taskEvaluationCriteriaWindow = new TaskEvaluationCriteriaWindow();
            taskEvaluationCriteriaWindow.ShowDialog();
        }
    }
}
