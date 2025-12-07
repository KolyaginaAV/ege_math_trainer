using System.Windows;
using System.Windows.Controls;
using ege_math_trainer.Models;

namespace ege_math_trainer.Windows
{
    public partial class MainAddTaskWindow : Window
    {
        private AppContext _context;
        public User currentUser;
        public MainAddTaskWindow(User user)
        {
            InitializeComponent();

            _context = new AppContext(); //создаем

            currentUser = user;

            ListBoxTasks.ItemsSource = _context.Tasks.ToList();
        }

        private void ButtonCanseltoMain(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(currentUser);
            mainWindow.Show();
            this.Close();
        }

        private void ButtonMaiAddTask(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int taskId)
            {
                AddTaskWindow addTaskWindow = new AddTaskWindow(taskId);
                if (addTaskWindow.ShowDialog() == true)
                {
                    MessageBox.Show("Задание добавлено!");
                }
            }
        }
    }
}
