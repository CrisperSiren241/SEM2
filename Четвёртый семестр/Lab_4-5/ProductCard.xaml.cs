using Lab_4_5.Model;
using Lab_4_5.ModelView;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace Lab_4_5
{
    /// <summary>
    /// Логика взаимодействия для ProductCard.xaml
    /// </summary>
    public partial class ProductCard : Window
    {
        public static Products? products;
        public RelayCommand? RedactProductCommand { get; }
        public ProductCard()
        {
            InitializeComponent();

            RedactProductCommand = new RelayCommand(o =>RedactExecute());
            
            TextName.Text = products.Name;
            TextDesc.Text = products.Description;
            TextPrice.Text = Convert.ToString(products.Price);
            TextUrl.Text = products.Url;

            string imagePath = products.Url;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            ImageSource imageSource = bitmap as ImageSource;

            ProductImage.Source = imageSource;
        }

        void RedactExecute()
        {
            string Name = products.Name;
            string Description = products.Description;
            decimal price = products.Price;

            foreach(var item in MainWindow._productlist)
            {
                if(item.Name == Name && item.Description == Description && item.Price == price) 
                {
                    products.Name = TextName.Text;
                    products.Description = TextDesc.Text;
                    products.Price = Convert.ToDecimal(TextPrice.Text);
                    products.Url = TextUrl.Text;
                }
            }

            this.Close();
        }

        private void TextUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            string imagePath = TextUrl.Text;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            ImageSource imageSource = bitmap as ImageSource;

            ProductImage.Source = imageSource;
        }
    }
}
