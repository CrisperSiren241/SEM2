using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    
    public partial class Form4 : Form
    {
        public List<Product> newlist = new List<Product>();
        public List<Product> updlist = new List<Product>();
        public Form4()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Страна":
                    updlist.Clear();
                    var SelectedCountry = from p in newlist
                                          orderby p.Organization.OrganizationName
                                          select p;
                    foreach (var element in SelectedCountry)
                    {
                        richTextBox1.Text += "--------------------------------------" + "\n";
                        richTextBox1.Text += "Название: " + element.Name + "\n";
                        richTextBox1.Text += "Инвентарный номер: " + element.ID + "\n";
                        richTextBox1.Text += "Количество: " + element.Amount + "\n";
                        richTextBox1.Text += "Цена: " + element.Price + "\n";
                        richTextBox1.Text += "Размер: " + element.Size + "\n";
                        richTextBox1.Text += "Дата поставки: " + element.Date + "\n";
                        richTextBox1.Text += "Производитель: " + element.Organization.OrganizationName + "\n";
                        richTextBox1.Text += "--------------------------------------" + "\n";
                        updlist.Add(element);
                    }
                    break;
                case "Дата":
                    updlist.Clear();
                    var SelectedDate = from p in newlist
                                       orderby p.Date
                                       select p;
                    foreach (var element in SelectedDate)
                    {
                        richTextBox1.Text += "--------------------------------------" + "\n";
                        richTextBox1.Text += "Название: " + element.Name + "\n";
                        richTextBox1.Text += "Инвентарный номер: " + element.ID + "\n";
                        richTextBox1.Text += "Количество: " + element.Amount + "\n";
                        richTextBox1.Text += "Цена: " + element.Price + "\n";
                        richTextBox1.Text += "Размер: " + element.Size + "\n";
                        richTextBox1.Text += "Дата поставки: " + element.Date + "\n";
                        richTextBox1.Text += "Производитель: " + element.Organization.OrganizationName + "\n";
                        richTextBox1.Text += "--------------------------------------" + "\n";
                        updlist.Add(element);
                    }
                    break;
                case "Название":
                    updlist.Clear();
                    var SelectedName = from p in newlist
                                       orderby p.Date
                                       select p;
                    foreach (var element in SelectedName)
                    {
                        richTextBox1.Text += "--------------------------------------" + "\n";
                        richTextBox1.Text += "Название: " + element.Name + "\n";
                        richTextBox1.Text += "Инвентарный номер: " + element.ID + "\n";
                        richTextBox1.Text += "Количество: " + element.Amount + "\n";
                        richTextBox1.Text += "Цена: " + element.Price + "\n";
                        richTextBox1.Text += "Размер: " + element.Size + "\n";
                        richTextBox1.Text += "Дата поставки: " + element.Date + "\n";
                        richTextBox1.Text += "Производитель: " + element.Organization.OrganizationName + "\n";
                        richTextBox1.Text += "--------------------------------------" + "\n";
                        updlist.Add(element);
                    }
                    break;
            }
        }
    }
}
