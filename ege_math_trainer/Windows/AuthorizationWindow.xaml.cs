using System.Windows;
using ege_math_trainer.Models;

namespace ege_math_trainer.Windows
{
    public partial class AuthorizationWindow : Window
    {
        private AppContext _context;

        public AuthorizationWindow()
        {
            InitializeComponent();

            _context = new AppContext();
        }

        private void ButtonAuth(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BoxLogin.Text) && !string.IsNullOrWhiteSpace(BoxPassword.Text))
            {
                User? autUser = _context.Users.FirstOrDefault(q => q.Login == BoxLogin.Text && q.Password == BoxPassword.Text);
                if (autUser != null) 
                {
                    MainWindow mainWindow = new MainWindow(autUser);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Логин или пароль неверные");
                }
            }
            else
            {
                MessageBox.Show("Заполниите логин и пароль или зарегистрируйтесь");
            }
        }

        private void ButtonAuthReg(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            if (registrationWindow.ShowDialog() == true)
            {
                MessageBox.Show("Вы зарегистрированы, войдите в аккаунт и приступайте к заданиям!", "Регистрация");
            }
        }
    }
}
