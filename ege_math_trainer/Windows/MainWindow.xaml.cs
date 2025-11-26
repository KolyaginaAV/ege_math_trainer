using ege_math_trainer.Models;
using ege_math_trainer.Windows;
using System.Windows;

namespace ege_math_trainer
{

    public partial class MainWindow : Window
    {
        private AppContext _context;
        public MainWindow(User user)
        {
            InitializeComponent();

            _context = new AppContext(); //создаем

            ListBoxTasks.ItemsSource = _context.PartOneTasks.Local.ToObservableCollection();

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