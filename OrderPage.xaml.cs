using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using MyShopping.Model;

namespace MyShopping
{
    public partial class OrderPage : PhoneApplicationPage
    {

        public int ıdvalue;
        public OrderPage()
        {
            InitializeComponent();
            this.DataContext = App.View;
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {

            
                TProduct proc=new TProduct();
                foreach (TProduct procxx in App.View.DBShop.Products)
                {
                    if (procxx.ProductId == ıdvalue)
                        proc = procxx;

                }
                if (textBox1.Text.Length > 0)
                {
                    try
                    {
                        proc.Price = Convert.ToDecimal(textBox1.Text);     
                    }
                    catch
                    {
                        MessageBox.Show("Invalid price,please enter a number!");
                    }
                                 
                }

                if (textBox2.Text.Length > 0)
                {
                    proc.ProductStore = textBox2.Text;
                }
                if (checkBox1.IsChecked == true)
                proc.IsChance = true;
           

            App.View.DBShop.SubmitChanges();
            // Return to the main page.
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            // Return to the main page.
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            int foo;
             int.TryParse( NavigationContext.QueryString["id"],out foo);
             ıdvalue = foo;
        }
    }
}