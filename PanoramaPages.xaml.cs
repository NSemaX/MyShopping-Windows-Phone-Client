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
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Controls;

using MyShopping.Model;
using MyShopping.View;
using System.Windows.Navigation;

namespace MyShopping
{
    public partial class PanaromaPages : UserControl
    {
        public TList kaynak;
        public int itemID;

        //public void LoadComponent() {

        //    this.Visibility = System.Windows.Visibility.Visible;
        //    PanaromaPages_Loaded(new object(), new RoutedEventArgs());
         

        //}


        public PanaromaPages(TList chlist, int chlistIndex)
        {

            InitializeComponent();
            this.DataContext = App.View;
            this.panoNewsItem1.Visibility = System.Windows.Visibility.Visible;
            this.Loaded += new RoutedEventHandler(PanaromaPages_Loaded);
            
        }

        
        void PanaromaPages_Loaded(object sender, RoutedEventArgs e)
        {

            foreach (TList ShopLists in App.View.DBShop.PLists)
            {
                if (ShopLists.Name == panoNewsItem1.Header.ToString())
                    kaynak = ShopLists;
            }
            var query = from TProduct product in App.View.DBShop.Products join TList listr in App.View.DBShop.PLists on product._PListId equals listr.Id where product._PListId == kaynak.Id select product;
            ProductPanoItemsListBox.ItemsSource = query;


        }


        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (MessageBox.Show(string.Format("This product will delete.Are you sure ?"), "Confirm Delete", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                
                    if (button != null)
                    {
                        TProduct ProductForDelete = button.DataContext as TProduct;

                        App.View.DeleteProduct(ProductForDelete);
                    }

                
            }
            PanaromaPages_Loaded(new object(), new RoutedEventArgs());
            this.Focus();
        }

        private void BtnOrderProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            TProduct ProductIdForSend = button.DataContext as TProduct;
            var idvalue = ProductIdForSend.ProductId.ToString();

                var frame = App.Current.RootVisual as PhoneApplicationFrame;
                frame.Navigate(new Uri(string.Format("/OrderPage.xaml?id={0}",idvalue), UriKind.Relative));
            
        }

        private void BtnShowProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            TProduct ProductIdForSend = button.DataContext as TProduct;
            var ıd1value = ProductIdForSend.ProductId.ToString();

            var frame1 = App.Current.RootVisual as PhoneApplicationFrame;
            frame1.Navigate(new Uri(string.Format("/ProductShowPages.xaml?id1={0}", ıd1value), UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            decimal sum = 0;
            foreach (TList ShopLists in App.View.DBShop.PLists)
            {
                if (ShopLists.Name == panoNewsItem1.Header.ToString())
                    kaynak = ShopLists;
               
            }
            //var kaynak=(TList)panoNewsItem1.Header;
            var query = from TProduct product in App.View.DBShop.Products join TList listr in App.View.DBShop.PLists on product._PListId equals listr.Id where product._PListId == kaynak.Id select product;
            foreach (TProduct proce in query)
            {
                sum += proce.Price;
            }

            MessageBox.Show(string.Format("Your shopping costs:{0}", sum));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            foreach (TList ShopLists in App.View.DBShop.PLists)
            {
                if (ShopLists.Name == panoNewsItem1.Header.ToString())
                    kaynak = ShopLists;
                itemID = kaynak.Id;
            }

            var frame2 = App.Current.RootVisual as PhoneApplicationFrame;
            frame2.Navigate(new Uri(string.Format("/NewProductPage.xaml?itemID={0}", itemID), UriKind.Relative));
         
        }

    }
}
