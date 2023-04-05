using Lab_4.Model;
using Lab_4.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Product newproduct;

        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Name = TextName.Text;
            product.Price = Convert.ToDecimal(TextPrice.Text);
            product.Description = TextDescription.Text;
            product.Url = TextUrl.Text; 
            MyViewModel.AddItem(product);   
            this.Close();
        }
    }
}
