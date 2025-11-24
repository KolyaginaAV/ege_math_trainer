using System.Windows;
using ege_math_trainer.Models;

namespace ege_math_trainer.Windows
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
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
                //
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }
    }
}
