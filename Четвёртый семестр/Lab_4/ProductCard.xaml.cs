using Lab_4.Model;
using Lab_4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab_4
{
    /// <summary>
    /// Логика взаимодействия для ProductCard.xaml
    /// </summary>
    public partial class ProductCard : Window
    {
        public static Product product;
        public ProductCard()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textName.Text = product.Name;
            textDescription.Text = product.Description;
            textPrice.Text = product.Price.ToString();
            textUrl.Text = product.Url; 
            string imagePath = product.Url;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            ImageSource imageSource = bitmap as ImageSource;

            TextUrl.Source = imageSource;   

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = product.Name;
            string description = product.Description;
            decimal price = product.Price;
            foreach(var items in MyViewModel._productlist)
            {
                if(items.Name == name && items.Description == description && items.Price == price)
                {
                    product.Name = textName.Text;
                    product.Description = textDescription.Text;
                    product.Price = Convert.ToDecimal(textPrice.Text);
                    product.Url = textUrl.Text;

                    /*
                     BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(textUrl.Text, UriKind.RelativeOrAbsolute);
                    bitmap.EndInit();

                    ImageSource imageSource = bitmap as ImageSource;

                    TextUrl.Source = imageSource;
                     */


                }
            }
            this.Close();
        }

        private void textUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            string imagePath = textUrl.Text;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            ImageSource imageSource = bitmap as ImageSource;

            TextUrl.Source = imageSource;
        }
    }
}
