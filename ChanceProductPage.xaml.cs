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
    public partial class ChanceProductPage : PhoneApplicationPage
    {
        public ChanceProductPage()
        {
            InitializeComponent();
            this.DataContext = App.View;
        }

        private void ChanceItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            var query1 = from TProduct product in App.View.DBShop.Products where product.IsChance == true select product;
            ChanceItemsListBox.ItemsSource = query1;
        }

        private void BtnGoProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            TProduct ProductIdForSend = button.DataContext as TProduct;
            var ıd1value = ProductIdForSend.ProductId.ToString();

            var frame1 = App.Current.RootVisual as PhoneApplicationFrame;
            frame1.Navigate(new Uri(string.Format("/ProductShowPages.xaml?id1={0}", ıd1value), UriKind.Relative));
        }
    }
}