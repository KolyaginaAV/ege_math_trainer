using System.Windows;
using ege_math_trainer.Models;
using ege_math_trainer.Windows;

namespace ege_math_trainer.Windows
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void ButtonAuth(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BoxLogin.Text) && !string.IsNullOrWhiteSpace(BoxPassword.Text))
            {
                User? autUser = AppContext.Users.FirstOrDefault(q => q.Login == BoxLogin.Text && q.Password == BoxPassword.Text);
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
            //registrationWindow.ShowDialog();
            if (registrationWindow.ShowDialog() == true)
            {
               MessageBox.Show("Вы успешно зарегистрированы!");
            }
        }
    }
}
