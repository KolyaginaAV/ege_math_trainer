using System.Windows;
using ege_math_trainer.Models;

namespace ege_math_trainer.Windows
{
    public partial class SecondPartTasksWindow : Window
    {
        private AppContext _context;
        public User currentUser;
        public int currentTaskId;
        public int currentTaskPart = 1;
        public SecondPartTasksWindow(int taskId, User user)
        {
            InitializeComponent();

            _context = new AppContext();
            currentUser = user;

            SecondPartTaskTitle.Text = _context.Tasks.FirstOrDefault(q => q.Id == taskId).ToString();

            PartOneTask currentTask = _context.PartOneTasks.FirstOrDefault(q => q.TaskId == taskId && !q.Users.Any(u => u.Id == currentUser.Id));
            if (currentTask != null)
            {
                currentTaskId = currentTask.Id;
                //TextBlockConditionFirstPartTask.Text = currentTask.Condition;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уже решали все задания этого номера, хотите прорешать их снова?",
                    "Сообщение", MessageBoxButton.YesNo);
            }
        }

        private void ButtonSecondPartTasksCanselToMain(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(currentUser);
            mainWindow.Show();
            this.Close();
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
            DecisionTaskWindow decisionTaskWindow = new DecisionTaskWindow(currentTaskId, currentTaskPart);
            decisionTaskWindow.ShowDialog();
        }

        private void ButtonSecondPartTasksCriteria(object sender, RoutedEventArgs e)
        {
            TaskEvaluationCriteriaWindow taskEvaluationCriteriaWindow = new TaskEvaluationCriteriaWindow();
            taskEvaluationCriteriaWindow.ShowDialog();
        }
    }
}
