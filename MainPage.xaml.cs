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
using System.Collections.ObjectModel;

using MyShopping.Model;

namespace MyShopping
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = App.View;
        }

       

        private void newListAddBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewListPage.xaml", UriKind.Relative));
        }



        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Save changes to the database.
            App.View.SaveChangesToDB();
        }

        private void BtnDeleteList_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (MessageBox.Show(string.Format("All products of this shop list will delete.Are you sure ?"), "Confirm Delete", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                if (button != null)
                {
                    TList ListForDelete = button.DataContext as TList;

                    //Eğer liste silinirse listeye ait tüm ürünleri de sil.
                    foreach (TProduct deleteProduct in App.View.DBShop.Products)
                    {
                        if (ListForDelete.Id == deleteProduct._PListId)
                            App.View.DeleteProduct(deleteProduct);
                    }

                    App.View.DeleteList(ListForDelete);
                }
            }
            this.Focus();
        }

        public void ShowMyListBarButton_Click(object sender, EventArgs e)
        {
           NavigationService.Navigate(new Uri("/PanoramaLists.xaml", UriKind.Relative));
        }

       
    }
}