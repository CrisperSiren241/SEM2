using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_2
{
    public partial class Form3 : Form
    {
        public List<string> search = new List<string>();
        public List<Product> newlist = new List<Product>();
        public List<Product> updlist = new List<Product>();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool rd = false;
            string checktext;
            
            foreach(RadioButton radio in groupBox1.Controls)
            {
                if (radio.Checked) rd = true;
            }
            if(rd)
            {
                if(textBox2.Text != "" && textBox3.Text != "")
                {
                    resultWithRadioAndPrice();
                }
                else
                {
                    resultWithRadio();
                }
            }
            else
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    resultWithPrice();
                }
                else
                {
                    result();
                }
            }

        }

        public void resultWithRadio()
        {
            updlist.Clear();
            foreach (RadioButton radio in groupBox1.Controls)
            {
                if (radio.Checked)
                {
                    Form1 form = new Form1();
                    Regex regex = new Regex(textBox1.Text, RegexOptions.IgnoreCase);
                    foreach (var items in search)
                    {
                        Match match = regex.Match(items);
                        if (match.Success)
                        {
                            var Selected = from p in newlist 
                                           where p.Name == items
                                           where p.Type == radio.Text
                                           select p;
                            foreach(var element in Selected)
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
                        }                        
                    }
                }
            }
        }
        public void result()
        {
            updlist.Clear();
            Form1 form = new Form1();
            Regex regex = new Regex(textBox1.Text, RegexOptions.IgnoreCase);
            foreach (var items in search)
            {
                Match match = regex.Match(items);
                if (match.Success)
                {
                    var Selected = from p in newlist
                                   where p.Name == items
                                   select p;
                    foreach (var element in Selected)
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
                }
            }
        }
        public void resultWithRadioAndPrice()
        {
            updlist.Clear();
            foreach (RadioButton radio in groupBox1.Controls)
            {
                if (radio.Checked)
                {
                    Form1 form = new Form1();
                    Regex regex = new Regex(textBox1.Text, RegexOptions.IgnoreCase);
                    foreach (var items in search)
                    {
                        Match match = regex.Match(items);
                        if (match.Success)
                        {
                            var Selected = from p in newlist
                                           where p.Name == items
                                           where p.Type == radio.Text
                                           where p.Price > Convert.ToDouble(textBox2.Text)
                                           where p.Price < Convert.ToDouble(textBox3.Text)
                                           select p;
                            foreach (var element in Selected)
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
                        }
                    }
                }
            }
        }
        public void resultWithPrice()
        {
            updlist.Clear();
            Form1 form = new Form1();
            Regex regex = new Regex(textBox1.Text, RegexOptions.IgnoreCase);
            foreach (var items in search)
            {
                Match match = regex.Match(items);
                if (match.Success)
                {
                    var Selected = from p in newlist
                                   where p.Name == items
                                   where p.Price > Convert.ToDouble(textBox2.Text)
                                   where p.Price < Convert.ToDouble(textBox3.Text)
                                   select p;
                    foreach (var element in Selected)
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
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            foreach(RadioButton radio in groupBox1.Controls)
            {
                radio.Checked = false;  
            }
            updlist.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));

            using (FileStream fs = new FileStream("NewSearchFile.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, updlist);
            }

            MessageBox.Show("OK");
        }

    }
}
