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
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace MyShopping.Model
{
    public class DBDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public DBDataContext(string connectionString)
            : base(connectionString)
        { }

        //Table for shopping products
        public Table<TProduct> Products;

        // List of shopping products'
        public Table<TList> PLists;

        // Table for shopping products' store
        public Table<TStore> Stores;


    }

    [Table]
    public class TProduct : INotifyPropertyChanged, INotifyPropertyChanging
    {

        private int _ProductId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
       
        
        public int ProductId
        {
            get { return _ProductId; }
            set
            {
                if (_ProductId != value)
                {
                    NotifyPropertyChanging("ProductId");
                    _ProductId = value;
                    NotifyPropertyChanged("ProductId");
                }
            }
        }

        private string _ProductName;

        [Column]
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                if (_ProductName != value)
                {
                    NotifyPropertyChanging("ProductName");
                    _ProductName = value;
                    NotifyPropertyChanged("ProductName");
                }
            }
        }



        private string _ProductStore;
        [Column]
        public string ProductStore
        {
            get { return _ProductStore; }
            set
            {
                if (_ProductStore != value)
                {
                    NotifyPropertyChanging("ProductStore");
                    _ProductStore = value;
                    NotifyPropertyChanged("ProductStore");
                }
            }
        }

        private decimal _Price;

        [Column (DbType="DECIMAL(10,2)")]
        public decimal Price
        {
            get { return _Price; }
            set
            {
                if (_Price != value)
                {
                    NotifyPropertyChanging("Price");
                    _Price = value;
                    NotifyPropertyChanged("Price");
                }
            }
        }

        //private bool _isBuy;

        //[Column]
        //public bool IsBuy
        //{
        //    get { return _isBuy; }
        //    set
        //    {
        //        if (_isBuy != value)
        //        {
        //            NotifyPropertyChanging("IsBuy");
        //            _isBuy = value;
        //            NotifyPropertyChanged("IsBuy");
        //        }
        //    }
        //}

        private bool _isChance;

        [Column]
        public bool IsChance
        {
            get { return _isChance; }
            set
            {
                if (_isChance != value)
                {
                    NotifyPropertyChanging("IsChance");
                    _isChance = value;
                    NotifyPropertyChanged("IsChance");
                }
            }
        }


        [Column]
        internal int _PListId;

        private EntityRef<TList> _tlists;

        [Association(Storage = "_tlists", ThisKey = "_PListId", OtherKey = "Id", IsForeignKey = true)]
        public TList TListx
        {
            get { return _tlists.Entity; }
            set
            {
                NotifyPropertyChanging("TListx");
                _tlists.Entity = value;

                if (value != null)
                {
                    _PListId = value.Id;
                }

                NotifyPropertyChanging("TListx");
            }
        }




        //[Column(IsVersion = true)]
        //private Binary _version;

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

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }



    [Table]
    public class TList : INotifyPropertyChanged, INotifyPropertyChanging
    {

        private int _id;

        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get { return _id; }
            set
            {
                NotifyPropertyChanging("Id");
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        private string _name;

        [Column]
        public string Name
        {
            get { return _name; }
            set
            {
                NotifyPropertyChanging("Name");
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }


        private bool _Checked;

        [Column]
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                if (_Checked != value)
                {
                    NotifyPropertyChanging("Checked");
                    _Checked = value;
                    NotifyPropertyChanged("Checked");
                }
            }
        }


        private EntitySet<TProduct> _plists;

        [Association(Storage = "_plists", OtherKey = "_PListId", ThisKey = "Id")]
        public EntitySet<TProduct> Mshop
        {
            get { return this._plists; }
            set { this._plists.Assign(value); }
        }


        // Assign handlers for the add and remove operations, respectively.
        public TList()
        {
            _plists = new EntitySet<TProduct>(
                new Action<TProduct>(this.attach_Mshop),
                new Action<TProduct>(this.detach_Mshop)
                );
        }

        // Called during an add operation
        private void attach_Mshop(TProduct Mshopx)
        {
            NotifyPropertyChanging("TProduct");
            Mshopx.TListx = this;
        }

        // Called during a remove operation
        private void detach_Mshop(TProduct Mshopx)
        {
            NotifyPropertyChanging("TProducts");
            Mshopx.TListx = null;
        }

        // Version column aids update performance.
        //[Column(IsVersion = true)]
        //private Binary _version;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }

        [Table]
        public class TStore : INotifyPropertyChanged, INotifyPropertyChanging
        {

            private int _sid;

            [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true)]
            public int SId
            {
                get { return _sid; }
                set
                {
                    NotifyPropertyChanging("SId");
                    _sid = value;
                    NotifyPropertyChanged("SId");
                }
            }

            private string _storename;

            [Column]
            public string StoreName
            {
                get { return _storename; }
                set
                {
                    NotifyPropertyChanging("StoreName");
                    _storename = value;
                    NotifyPropertyChanged("StoreName");
                }
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

            #region INotifyPropertyChanging Members

            public event PropertyChangingEventHandler PropertyChanging;

            private void NotifyPropertyChanging(string propertyName)
            {
                if (PropertyChanging != null)
                {
                    PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
                }
            }

            #endregion












        }



    }



