using ege_math_trainer.Models;
using ege_math_trainer.Windows;
using System.Windows;
using System.Windows.Controls;

namespace ege_math_trainer
{

    public partial class MainWindow : Window
    {
        private AppContext _context;
        public MainWindow(User user)
        {
            InitializeComponent();

            _context = new AppContext(); //создаем

            ListBoxTasks.ItemsSource = _context.Tasks.ToList();

            if (user.RoleId == 1) 
            {
                TextBlockWelcome.Text = "Выберите задание, которое хотите порешать\nИли сделав двойной клик по заданию, добавьте новый пример этого задания";
                TextUserName.Text = user.Name + " " + user.Patronymic + "!";
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
            if (sender is Button button && button.Tag is int taskId)
            {
                if (taskId > 0 && taskId < 13)
                {
                    FirstPartTasksWindow firstPartTasksWindow = new FirstPartTasksWindow(taskId);
                    firstPartTasksWindow.Show();
                    this.Close();
                }
                else if (taskId > 12 && taskId < 20)
                {
                    SecondPartTasksWindow secondPartTasksWindow = new SecondPartTasksWindow(taskId);
                    secondPartTasksWindow.Show();
                    this.Close();
                }
            }
        }
    }
}