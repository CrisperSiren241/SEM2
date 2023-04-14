using Lab_4_5.Model;
using Lab_4_5.ModelView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Lab_4_5
{
    public partial class MainWindow : Window
    {
        private readonly Stack<IMemento> _undoMementos = new Stack<IMemento>();
        private readonly Stack<IMemento> _redoMementos = new Stack<IMemento>();
        public RelayCommand AddProductCommand { get; }
        public RelayCommand DeleteProductCommand { get; }
        public RelayCommand SortByPriceCommand { get; }
        public RelayCommand ClearFilterCommand { get; }
        public RelayCommand SortByNameCommand { get; }
        public RelayCommand SaveFileCommand { get; }
        public RelayCommand ViewProductCommand { get; }
        public RelayCommand DarkThemeCommand { get; }
        public RelayCommand LightThemeCommand { get; }
        public RelayCommand RedoCommand { get; }
        public RelayCommand UndoCommand { get; }
        public static ObservableCollection<Products> _productlist = new ObservableCollection<Products>();
        public MainWindow()
        {
            InitializeComponent();
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("Resource/DictionaryRus.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);

            AddProductCommand = new RelayCommand(o => AddProductExecute());
            DeleteProductCommand = new RelayCommand(o => DeleteProductExecute(o));
            SortByPriceCommand = new RelayCommand(o => SortByPriceExecute());
            ClearFilterCommand = new RelayCommand(o => ClearFilterExecute());
            SortByNameCommand = new RelayCommand(o => SortByNameExecute());
            SaveFileCommand = new RelayCommand(o => SaveFileExecute());
            ViewProductCommand = new RelayCommand(o => ViewProductExecute(o));
            DarkThemeCommand = new RelayCommand(o => DarkThemeExecute());
            LightThemeCommand = new RelayCommand(o => LightThemeExecute());
            RedoCommand = new RelayCommand(o => Redo());
            UndoCommand = new RelayCommand(o=>Undo());
        }

        void DarkThemeExecute()
        {
            var uri = new Uri("Resource/DarkTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        void LightThemeExecute()
        {
            var uri = new Uri("Resource/LightTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        void ViewProductExecute(object parametr)
        {
            var product = (Products)parametr;
            ProductCard.products = product;
            ProductCard card = new();
            card.ShowDialog();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _productlist.Add(new Products("Шахматы", "Images/Image.jpg", 24, "Desc"));
            _productlist.Add(new Products("Яблоко", "Images/Image.jpg", 14, "Desc"));
            _productlist.Add(new Products("Сок", "Images/Image.jpg", 244, "Desc"));
            _productlist.Add(new Products("Меч", "Images/Image.jpg", 23, "Desc"));
            ProductControl.ItemsSource = _productlist;
        }

        void AddProductExecute()
        {
            Products product = new Products("Name", "Images/Image.jpg", 0, "Description");  
            _productlist.Add(product);
            _undoMementos.Push(product.CreateMemento());
            //_redoMementos.Clear();
        }

        void DeleteProductExecute(object parametr)
        {
            var product = (Products)parametr;
            _productlist.Remove(product);
            _undoMementos.Push(product.CreateMemento());
            _redoMementos.Clear();
        }

        void SaveFileExecute()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Products>));

            using (FileStream fs = new FileStream("NewFile.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _productlist);
            }

            MessageBox.Show("OK");
        }

        void SortByPriceExecute()
        {
            var _filteredlist = from p in _productlist
                                orderby p.Price
                                select p;
            ProductControl.ItemsSource= _filteredlist;
        }

        void ClearFilterExecute()
        {
            ProductControl.ItemsSource = _productlist;
        }

        void SortByNameExecute()
        {
            var _filteredlist = from p in _productlist
                                orderby p.Name
                                select p;
            ProductControl.ItemsSource = _filteredlist;
        }

        private void ProductItem_DoubleClick(object parametr)
        {
            var product = (Products)parametr;
            ProductCard.products = product;
            ProductCard card = new();
            card.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Search.Text != "")
            {
                var list = from p in _productlist
                           where p.Name.ToLower().Contains(Search.Text.ToLower())
                                   select p;
                ProductControl.ItemsSource = list;
            }
            else
            {
                ProductControl.ItemsSource = _productlist;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("Resource/DictionaryRus.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("Resource/DictionaryEng.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        public void Undo()
        {
            if (_undoMementos.Count > 0)
            {
                var memento = _undoMementos.Pop();
                memento.Restore();
                _redoMementos.Push(memento);
                _productlist.RemoveAt(_productlist.Count - 1);
            }
        }

        public void Redo()
        {
            if (_redoMementos.Count > 0)
            {
                var memento = _redoMementos.Pop();
                memento.Restore();
                _undoMementos.Push(memento);
                //_productlist.Add(memento.Product);
            }
        }
    }
}
