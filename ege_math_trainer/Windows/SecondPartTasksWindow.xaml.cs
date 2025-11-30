using System.Windows;
using ege_math_trainer.Models;

namespace ege_math_trainer.Windows
{
    public partial class SecondPartTasksWindow : Window
    {
        private AppContext _context;
        public User currentUser;
        public int currentTaskId;
        public int currentTaskPart = 2;
        public SecondPartTasksWindow(int taskId, User user)
        {
            InitializeComponent();

            _context = new AppContext();
            currentUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);

            SecondPartTaskTitle.Text = _context.Tasks.FirstOrDefault(q => q.Id == taskId).ToString();

            PartTwoTask currentTask = _context.PartTwoTasks.FirstOrDefault(q => q.TaskId == taskId && !q.Users.Any(u => u.Id == currentUser.Id));
            if (currentTask != null)
            {
                currentTaskId = currentTask.Id;
                TextBlockConditionSecondPartTask.Text = currentTask.Condition;

                currentTask.Users.Add(currentUser);
                _context.SaveChanges();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уже решали все задания этого номера, хотите прорешать их снова?",
                    "Сообщение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    List<PartTwoTask> completedTasks = new();
                    completedTasks.Add(_context.PartTwoTasks.FirstOrDefault(q => q.TaskId == taskId));

                    foreach (PartTwoTask task in completedTasks)
                    {
                        task.Users.Remove(currentUser);
                    }
                    _context.SaveChanges();

                    SecondPartTasksWindow newWindow = new SecondPartTasksWindow(taskId, currentUser);
                    newWindow.Show();
                    this.Close();
                }
            }
        }

        private void ButtonSecondPartTasksCanselToMain(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Вы хотите выйти и вернуться к выбору заданию?",
                "Предупреждение",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow(currentUser);
                mainWindow.Show();
                this.Close();
            }
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
            TaskEvaluationCriteriaWindow taskEvaluationCriteriaWindow = new TaskEvaluationCriteriaWindow(currentTaskId, currentTaskPart);
            taskEvaluationCriteriaWindow.ShowDialog();
        }
    }
}
