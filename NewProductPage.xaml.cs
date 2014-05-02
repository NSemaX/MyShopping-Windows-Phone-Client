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
    public partial class AddNewProductPage : PhoneApplicationPage
    {
        public TList item;
        public int ListID;
        public AddNewProductPage()
        {
            InitializeComponent();
            this.DataContext = App.View;
            this.Loaded += new RoutedEventHandler(AddNewProductPage_Loaded);
           
        }

        void AddNewProductPage_Loaded(object sender, RoutedEventArgs e)
        {
            int foo;
            int.TryParse(NavigationContext.QueryString["itemID"], out foo);
            ListID = foo;
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            if (addnewproductTextBox.Text.Length > 0)
            {

                // Create a new shop product.
                TProduct newProductItem = new TProduct
                {
                    ProductName = addnewproductTextBox.Text,
                    _PListId = ListID,
                };

                // Add the shop product to the View.
                App.View.AddProduct(newProductItem);

                // Return to the main page.
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
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

        }
    }
}