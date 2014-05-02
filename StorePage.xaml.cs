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
    public partial class StorePage : PhoneApplicationPage
    {
        public StorePage()
        {
            InitializeComponent();
            this.DataContext = App.View;
        }

        private void newListAddBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddStorePage.xaml", UriKind.Relative));
        }

        private void BtnDeleteStore_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
           
                if (button != null)
                {
                    TStore StoreForDelete = button.DataContext as TStore;

                    App.View.DeleteStore(StoreForDelete);
                }
           
            this.Focus();
        }



        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Save changes to the database.
            App.View.SaveChangesToDB();
        }

    }
}