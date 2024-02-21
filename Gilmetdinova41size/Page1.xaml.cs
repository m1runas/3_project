using System;
using System.CodeDom;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
   
    public partial class Page1 : Page
    {
        
        public Page1(User user)
        {
            InitializeComponent();
            FIOTB.Text=user.UserSurname+" " +user.UserName+" " + user.UserPatronymic;
            switch (user.UserRole)
            {
                case 1:
                    RoleTB.Text = "Клиент";break;
                    case 2:
                    RoleTB.Text = "Менеджер"; break;
                    case 3:
                    RoleTB.Text = "Администратор"; break;
            }


            var currentProduct = Gilmetdinova41sizeEntities.GetContext().Product.ToList();
            SizeListView.ItemsSource = currentProduct;
        
            ComboType.SelectedIndex = 0;
        }
        private void UpdatePage()
        {

           
            var currentPage = Gilmetdinova41sizeEntities.GetContext().Product.ToList();
        currentPage=currentPage.Where(p=>p.ProductName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            int productCount = currentPage.Count;

            if (RBtnDown.IsChecked.Value)
            {
                currentPage=currentPage.OrderByDescending(p=>p.ProductCost).ToList();
            }

            if (RBtnUp.IsChecked.Value)
            {
                currentPage = currentPage.OrderBy(p => p.ProductCost).ToList();


            }

            if (ComboType.SelectedIndex == 0)
            {
                currentPage = currentPage.Where(p => (p.ProductDiscountCurrent >= 0 && p.ProductDiscountCurrent <= 100)).ToList();
            }

            if (ComboType.SelectedIndex == 1)
            {
                currentPage = currentPage.Where(p => (p.ProductDiscountCurrent >= 0 && p.ProductDiscountCurrent < 10)).ToList();
            }

            if (ComboType.SelectedIndex == 2)
            {
                currentPage = currentPage.Where(p =>(p.ProductDiscountCurrent >= 10 && p.ProductDiscountCurrent < 15)).ToList();
            }

            if (ComboType.SelectedIndex == 3)
            {
                currentPage = currentPage.Where(p =>( p.ProductDiscountCurrent >= 15 && p.ProductDiscountCurrent <= 100)).ToList();
            }

            TBCount.Text=currentPage.Count.ToString();
            TBALLRecords.Text= Gilmetdinova41sizeEntities.GetContext().Product.ToList().Count.ToString();
            SizeListView.ItemsSource = currentPage;

            
                }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePage();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdatePage();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            UpdatePage();
        }

        private void RBtnUp_Checked(object sender, RoutedEventArgs e)
        {
            UpdatePage();
        }

        private void RBtnDown_Checked(object sender, RoutedEventArgs e)
        {
            UpdatePage();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePage();
        }
    }
}
