using System.Windows;
using System.Windows.Media.Imaging;
using ege_math_trainer.Models;

namespace ege_math_trainer.Windows
{
    public partial class FirstPartTasksWindow : Window
    {
        private AppContext _context;
        public User currentUser;
        public int currentTaskId;
        public int currentTaskPart = 1;
        public FirstPartTasksWindow(int taskId, User user)
        {
            InitializeComponent();

            _context = new AppContext();
            FirstPartTaskTitle.Text = _context.Tasks.FirstOrDefault(q => q.Id == taskId).ToString();
            currentUser = user;

            PartOneTask currentTask = _context.PartOneTasks.FirstOrDefault(q => q.TaskId == taskId && !q.Users.Any(u => u.Id == currentUser.Id));
            if (currentTask != null)
            {
                currentTaskId = currentTask.Id;
                TextBlockConditionFirstPartTask.Text = currentTask.Condition;
                if (!string.IsNullOrEmpty(currentTask.ConditionImage))
                {
                    ImageConditionFirstPartTask.Source = new BitmapImage(new Uri(currentTask.ConditionImage, UriKind.Relative));
                    //BitmapImage - класс WPF для работы с изображениями (принимает Uri и загружает изображение по этому пути)
                    //Uri - адрес; UriKind.Relative - относительный путь (не полный); UriKind.Absolute - абсолютный адрес
                }

            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уже решили все задания этого номера, хотите прорешать их снова?",
                    "Сообщение", MessageBoxButton.YesNo);
                // добавить удаление юзера из задания этого типа заданий
            }
        }

        private void ButtonFirstPartTasksDecision(object sender, RoutedEventArgs e)
        {
            DecisionTaskWindow decisionTaskWindow = new DecisionTaskWindow(currentTaskId, currentTaskPart);
            decisionTaskWindow.ShowDialog();
        }

        private void ButtonFirstPartTasksCanselToMain(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(currentUser);
            mainWindow.Show();
            this.Close();
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
