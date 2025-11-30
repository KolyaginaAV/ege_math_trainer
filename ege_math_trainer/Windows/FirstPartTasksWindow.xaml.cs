using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using ege_math_trainer.Models;
using Microsoft.EntityFrameworkCore;

namespace ege_math_trainer.Windows
{
    public partial class FirstPartTasksWindow : Window
    {
        private AppContext _context;
        public User currentUser;
        public int currentTaskFirstPartId;
        public int currentTaskPart = 1;
        public int currenttaskId;
        public FirstPartTasksWindow(int taskId, User user)
        {
            InitializeComponent();

            _context = new AppContext();
            FirstPartTaskTitle.Text = _context.Tasks.FirstOrDefault(q => q.Id == taskId).ToString();

            currentUser = _context.Users.FirstOrDefault(u => u.Id == user.Id); ;
            currenttaskId = taskId;

            PartOneTask currentTask = _context.PartOneTasks.FirstOrDefault(q => q.TaskId == taskId && !q.Users.Any(u => u.Id == currentUser.Id));
            if (currentTask != null)
            {
                currentTaskFirstPartId = currentTask.Id;
                TextBlockConditionFirstPartTask.Text = currentTask.Condition;
                if (!string.IsNullOrEmpty(currentTask.ConditionImage))
                {
                    ImageConditionFirstPartTask.Source = new BitmapImage(new Uri(currentTask.ConditionImage, UriKind.Relative));
                    //BitmapImage - класс WPF для работы с изображениями (принимает Uri и загружает изображение по этому пути)
                    //Uri - адрес; UriKind.Relative - относительный путь (не полный); UriKind.Absolute - абсолютный адрес
                }
                currentTask.Users.Add(currentUser);
                _context.SaveChanges();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уже решили все задания этого номера, хотите прорешать их снова?",
                    "Сообщение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    List<PartOneTask> completedTasks = new();
                    completedTasks.Add(_context.PartOneTasks.FirstOrDefault(q => q.TaskId == taskId));

                    foreach (PartOneTask task in completedTasks)
                    {
                        task.Users.Remove(currentUser);
                    }
                    _context.SaveChanges();
                    FirstPartTasksWindow newWindow = new FirstPartTasksWindow(taskId, currentUser);
                    newWindow.Show();
                    this.Close();
                }
            }
        }

        private void ButtonFirstPartTasksDecision(object sender, RoutedEventArgs e)
        {
            DecisionTaskWindow decisionTaskWindow = new DecisionTaskWindow(currentTaskFirstPartId, currentTaskPart);
            decisionTaskWindow.ShowDialog();
        }

        private void ButtonFirstPartTasksCanselToMain(object sender, RoutedEventArgs e)
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

        private void ButtonFirstPartTasksNextTask(object sender, RoutedEventArgs e)
        {
            FirstPartTasksWindow nextFirstPartTasksWindow = new FirstPartTasksWindow(currenttaskId, currentUser);
            nextFirstPartTasksWindow.Show();
            this.Close();
        }
    }
}
