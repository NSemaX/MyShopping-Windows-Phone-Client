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
    public partial class NewListPage : PhoneApplicationPage
    {
        public NewListPage()
        {
            InitializeComponent();
            this.DataContext = App.View;
          
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            if (ListNameTextBox.Text.Length > 0)
            {
                // Create a new shoplist
                TList newListItem = new TList
                {
                    Name = ListNameTextBox.Text,
                   
                };

                // Add the new shoplist to the View.
                App.View.AddList(newListItem);

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