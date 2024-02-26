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

namespace Gilmetdinova41size
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text;
            string password = PassTB.Text;
            if(login =="" || password =="")
            {
                MessageBox.Show("Введите данные для входа");
                return;
            }
            User user = Gilmetdinova41sizeEntities.GetContext().User.ToList().Find(p=>p.UserLogin == login && p.UserPassword==password);
            if(user!=null)
            {
                Manager.MainFrame.Navigate(new Page1(user));
                LoginTB.Text = "";
                PassTB.Text = "";
            }
            else
            {
                MessageBox.Show("Данные введены неверно");
                LoginBtn.IsEnabled = false;
                LoginTB.IsEnabled = true;   
            }
        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = null;
            Manager.MainFrame.Navigate(new Page1(user));
            LoginTB.Text = "";
            PassTB.Text = "";

        }
    }
}
