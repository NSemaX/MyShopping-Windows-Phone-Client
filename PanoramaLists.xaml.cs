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
    public partial class PanoramaLists : PhoneApplicationPage
    {
        public bool flag = false;
        public PanoramaLists()
        {
            InitializeComponent();
            this.DataContext = App.View;
            //panorama.SelectionChanged += new EventHandler<SelectionChangedEventArgs>(panorama_SelectionChanged);///??? burda olmalı mı? bu ne?

        }

        //void panorama_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    (e.AddedItems[0] as PanaromaPages).LoadComponent();
        //}

        private void showlistpanoramaview_Click(object sender, RoutedEventArgs e)
        {
            panorama.Visibility = System.Windows.Visibility.Visible;
            allListItemsListBox1.Visibility = System.Windows.Visibility.Collapsed;
            showlistpanoramaview.Visibility = System.Windows.Visibility.Collapsed;
            flag = true;
            var selectedLists = (allListItemsListBox1.ItemsSource as ObservableCollection<TList>).Where(chan => chan.Checked == true).ToList();
                    for (var index = 0; index < selectedLists.Count; index++)
                   {
                       PanaromaPages chan = new PanaromaPages(selectedLists[index], index);
                       chan.panoNewsItem1.Header = selectedLists[index].Name;
                       panorama.Items.Add(chan);
                   }   
        }

    

        private void allListItemsListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //if (flag == true)
            //    panorama.Visibility = System.Windows.Visibility.Visible;
        }




    }
}