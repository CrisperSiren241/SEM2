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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Class1> classes = new ObservableCollection<Class1>();
        public MainWindow()
        {
            Class1 class1 = new Class1()
            { 
                Name = "Test",
                Description = "Test",
            };
            Class1 class2 = new Class1()
            {
                Name = "Test2",
                Description = "Test2",
            };

            classes.Add(class1);
            classes.Add(class2);

            InitializeComponent();
            this.DataContext = class1;  
        }


    }
}
