using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using MyShopping.Model;

namespace MyShopping.View
{
    public class DBView : INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        public DBDataContext DBShop;

        // Class constructor, create the data context object.
        public DBView(string DBConnectionString)
        {
            DBShop = new DBDataContext(DBConnectionString);
        }

        private ObservableCollection<TProduct> _AllProductItems;
        public ObservableCollection<TProduct> AllProductItems
        {
            get { return _AllProductItems; }
            set
            {
                _AllProductItems = value;
                NotifyPropertyChanged("AllProductItems");
            }
        }


        private ObservableCollection<TList> _ProductLists;
        public ObservableCollection<TList> ProductLists
        {
            get { return _ProductLists; }
            set
            {
                _ProductLists = value;
                NotifyPropertyChanged("ProductLists");
            }
        }


        //private List<TList> _ListofShopList;
        //public List<TList> ListofShopList
        //{
        //    get { return _ListofShopList; }
        //    set
        //    {
        //        _ListofShopList = value;
        //        NotifyPropertyChanged("ListofShopList");
        //    }
        //}

        private ObservableCollection<TStore> _StoreLists;
        public ObservableCollection<TStore> StoreLists
        {
            get { return _StoreLists; }
            set
            {
                _StoreLists = value;
                NotifyPropertyChanged("StoreLists");
            }
        }


        private List<TStore> _StoreListx;
        public List<TStore> StoreListx
        {
            get { return _StoreListx; }
            set
            {
                _StoreListx = value;
                NotifyPropertyChanged("StoreListx");
            }
        }


        // Queries
        public void LoadCollectionsFromDatabase()
        {


            var ListsInDB = from TList list in DBShop.PLists
                            select list;

            var ProducsInDB = from TProduct product in DBShop.Products join TList listr in DBShop.PLists on product._PListId equals listr.Id select product;

            var StoresInDB = from TStore store in DBShop.Stores
                             select store;

            AllProductItems = new ObservableCollection<TProduct>(ProducsInDB);
          
            ProductLists = new ObservableCollection<TList>(ListsInDB);


            StoreLists = new ObservableCollection<TStore>(StoresInDB);

             // list of shopping list 
            StoreListx = DBShop.Stores.ToList();
         
        }


        public void AddList(TList newList)
        {
            // Add new shop list to the data context.
            DBShop.PLists.InsertOnSubmit(newList);

            // Save changes to the database.
            DBShop.SubmitChanges();

            // Add new shop list to  observable collection.
            ProductLists.Add(newList);

        }

        public void DeleteList(TList ListDelete)
        {

            // Remove shop list from the observable collection.
            ProductLists.Remove(ListDelete);

            // Remove shop list from the data context.
            DBShop.PLists.DeleteOnSubmit(ListDelete);

            // Save changes to the database.
            DBShop.SubmitChanges();
        }



        public void AddProduct(TProduct newProduct)
        {
            DBShop.Products.InsertOnSubmit(newProduct);

            DBShop.SubmitChanges();

            AllProductItems.Add(newProduct);

        }

        public void DeleteProduct(TProduct ProductsDelete)
        {

            AllProductItems.Remove(ProductsDelete);

            DBShop.Products.DeleteOnSubmit(ProductsDelete);

            DBShop.SubmitChanges();
        }

        public void AddStore(TStore newStore)
        {
            DBShop.Stores.InsertOnSubmit(newStore);

            DBShop.SubmitChanges();

            StoreLists.Add(newStore);

        }

        public void DeleteStore(TStore StoreForDelete)
        {

            StoreLists.Remove(StoreForDelete);

            DBShop.Stores.DeleteOnSubmit(StoreForDelete);

            DBShop.SubmitChanges();
        }


        public void SaveChangesToDB()
        {
            DBShop.SubmitChanges();
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
