using GalaSoft.MvvmLight.Command;
using Lab_4.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab_4.ViewModel
{
    public class MyViewModel: INotifyPropertyChanged
    {
        public static ObservableCollection<Product> _productlist = new ObservableCollection<Product>();
        
        public static ObservableCollection<Product> _filteredList = new ObservableCollection<Product>();
        public RelayCommand<Product> AddItemCommand { get; set; }
        public RelayCommand<Product> DeleteItemCommand { get; set; }

        public MyViewModel()
        {
            AddItemCommand = new RelayCommand<Product>(AddItem);
            DeleteItemCommand = new RelayCommand<Product>(DeleteItem);
        }

        public static void AddItem(Product item)
        {
            _productlist.Add(item); 
        }
       
        public static void DeleteItem(Product item)
        {
            _productlist.Remove(item);  
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedProduct)));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
