using Lab_4.Model;
using Lab_4.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int clickCount = 0;
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            clickCount++;

            if (clickCount % 2 == 0)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("Resources/DictionaryRus.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);

            var uri = new Uri("Theme/DarkTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            

            Product product = new Product()
            {
                Name = "LOL",
                Price = 0,
                Description = "Description",
                Url = "https://productimages.withfloats.com/actual/5c332b43e3193300014d59a2.jpg"
            };

            
            MyViewModel._productlist.Add(product);


            ItemsList.ItemsSource = MyViewModel._productlist;
            productListBox.ItemsSource = MyViewModel._filteredList;

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var myButton = sender as Button;
            var deletedproduct = myButton.DataContext as Product;
            
            MyViewModel.DeleteItem(deletedproduct);    
        }

        

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var myButton = sender as Button;
            var chosenproduct = myButton.DataContext as Product;

            ProductCard.product = chosenproduct;

            ProductCard productCard = new ProductCard();
            productCard.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("Resources/DictionaryEng.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("Resources/DictionaryRus.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            MyViewModel._filteredList.Clear();
            Regex regex = new Regex(SearchText.Text, RegexOptions.IgnoreCase);
            foreach(var items in MyViewModel._productlist)
            {
                Match match = regex.Match(items.Name);
                if(match.Success)
                {
                    var list = from p in MyViewModel._productlist
                               where p.Name == items.Name
                               select p;
                    foreach (var item in list)
                    {
                        MyViewModel._filteredList.Add(item);
                    }
                }
            }
        }

        private void productListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem as Product;
            ProductCard.product = selectedItem;
            ProductCard productCard = new ProductCard();
            productCard.Show();
        }

        private void Dark_button(object sender,  RoutedEventArgs e)
        {
            var uri = new Uri("Theme/DarkTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Light_button(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Theme/WhiteTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Product>));

            using (FileStream fs = new FileStream("NewFile.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, MyViewModel._productlist);
            }

            MessageBox.Show("OK");
        }
    }
}
