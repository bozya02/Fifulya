using Fifulya.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fifulya.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            var login = tbLogin.Text;

            if (!DataAccess.IsUniqueLogin(login))
            {
                MessageBox.Show("Данный логин занят", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (pbPassword.Password != pbSecondPassword.Password)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbFirstName.Text == "" || tbLastName.Text == "" ||
                tbLogin.Text == "" || pbPassword.Password == "")
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Agent agent = new Agent
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                User = new User
                {
                    Login = tbLogin.Text,
                    Password = pbPassword.Password
                }
            };

            try
            {
                DataAccess.SaveAgent(agent);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Регистрация не удалась","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
