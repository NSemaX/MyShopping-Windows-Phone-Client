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
    public partial class ProductShowPages : PhoneApplicationPage
    {
        public int ıdvalue;
        public ProductShowPages()
        {
            InitializeComponent();
            this.DataContext = App.View;
        
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            int foo;
             int.TryParse( NavigationContext.QueryString["id1"],out foo);
             ıdvalue = foo;


             TProduct proc1=new TProduct();
                foreach (TProduct procxx in App.View.DBShop.Products)
                {
                    if (procxx.ProductId == ıdvalue)
                        proc1 = procxx;

                }
                nameTxt.Text = proc1.ProductName;
                priceTxt.Text = proc1.Price.ToString();
                storeTxt.Text = proc1.ProductStore;
        }

  
    }
}