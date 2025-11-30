using System.Windows;
using ege_math_trainer.Models;

namespace ege_math_trainer.Windows
{
    public partial class RegistrationWindow : Window
    {
        private AppContext _context;
        public RegistrationWindow()
        {
            InitializeComponent();

            _context = new AppContext(); //создаем
        }

        private void ButtonRegCancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonReg(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(BoxRegLogin.Text) && !string.IsNullOrEmpty(BoxRegPassword.Text) &&
               !string.IsNullOrEmpty(BoxRegSurname.Text) && !string.IsNullOrEmpty(BoxRegName.Text) &&
               !string.IsNullOrEmpty(BoxRegPatronymic.Text) && !string.IsNullOrEmpty(BoxRegPhone.Text) &&
               !string.IsNullOrEmpty(BoxRegEmail.Text))
            {
                User? regUser = _context.Users.FirstOrDefault(q => q.Login == BoxRegLogin.Text);
                if (regUser == null)
                {
                    int roleId;
                    if (RadioButtonTeacher.IsChecked == true)
                    {
                        roleId = 1; 
                    }
                    else
                    {
                        roleId = 2;
                    }
                    User newUser = new User
                    {
                        Login = BoxRegLogin.Text,
                        Password = BoxRegPassword.Text,
                        Surname = BoxRegSurname.Text,
                        Name = BoxRegName.Text,
                        Patronymic = BoxRegPatronymic.Text,
                        Phone = BoxRegPhone.Text,
                        Email = BoxRegEmail.Text,
                        RoleId = roleId 
                    };

                    _context.Users.Add(newUser);
                    _context.SaveChanges();

                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже зарегистрирован./Введите другой логин или отмените регистрацию и попробуйте войти!");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }
    }
}
