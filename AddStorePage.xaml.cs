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
    public partial class AddStorePage : PhoneApplicationPage
    {
        public AddStorePage()
        {
            InitializeComponent();
            this.DataContext = App.View;
        }

        private void newListAddBarButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                // Create a new shoplist
                TStore newStoreItem = new TStore
                {
                    StoreName = textBox1.Text,

                };

                App.View.AddStore(newStoreItem);

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

    }
}