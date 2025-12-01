using ege_math_trainer.Models;
using ege_math_trainer.Windows;
using System.Windows;
using System.Windows.Controls;

namespace ege_math_trainer
{

    public partial class MainWindow : Window
    {
        private AppContext _context;
        public User currentUser;
        public MainWindow(User user)
        {
            InitializeComponent();

            _context = new AppContext(); //создаем

            currentUser = user;

            ListBoxTasks.ItemsSource = _context.Tasks.ToList();

            if (user.RoleId == 1) 
            {
                TextBlockWelcome.Text = "Выберите задание, которое хотите порешать\nИли сделав двойной клик по заданию, добавьте новый пример этого задания";
                TextUserName.Text = user.Name + " " + user.Patronymic + "!";
                ButtonNameMainAddTask.Visibility = Visibility.Visible;
            }
            else
            {
                TextBlockWelcome.Text = "Выберите задание, над которым хотите позаниматься";
                TextUserName.Text = user.Name;
            }
        }
        private void ButtonCanselMain(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }

        private void ButtonMainTask(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int taskId) //pattern matching - проверяет, что у sender тип Button и создаёт
                                                                     //button; проверяет, что button.Tag это int и создет taskId
            {
                if (taskId > 0 && taskId < 13)
                {
                    FirstPartTasksWindow firstPartTasksWindow = new FirstPartTasksWindow(taskId, currentUser);
                    firstPartTasksWindow.Show();
                    this.Close();
                }
                else if (taskId > 12 && taskId < 20)
                {
                    SecondPartTasksWindow secondPartTasksWindow = new SecondPartTasksWindow(taskId, currentUser);
                    secondPartTasksWindow.Show();
                    this.Close();
                }
            }
        }

        private void ButtonMainAddTask(object sender, RoutedEventArgs e)
        {
            MainAddTaskWindow mainAddTaskWindow = new MainAddTaskWindow(currentUser);
            mainAddTaskWindow.ShowDialog();
        }
    }
}