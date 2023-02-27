using System.Xml.Serialization;
using System;
using System.Runtime.Serialization;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        List<Product> list = new List<Product>();
        List<Organization> listOrg = new List<Organization>();
        Product product = new Product();
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = String.Format("Размер: Текущее значение - {0} кг", trackBar1.Value);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                product.Name = textBox1.Text;
                product.ID = maskedTextBox1.Text;
                product.Amount = Convert.ToInt32(numericUpDown1.Value);
                product.Price = Convert.ToInt32(textBox2.Text);
                product.Size = trackBar1.Value;
                product.Date = dateTimePicker1.Text;

                if (radioButton1.Checked) product.Type = "Хрупкое";
                else if (radioButton2.Checked) product.Type = "Прочное";
                else if (radioButton3.Checked) product.Type = "Оптовое";
                else if (radioButton4.Checked) product.Type = "Потребительское";

                foreach(var item in listOrg)
                {
                    if(item.OrganizationName == (string?)comboBox1.SelectedItem)
                    {
                        product.Organization = item;
                        break;
                    }
                }

                
            }
            catch(FormatException)
            {
                MessageBox.Show("ERROR");
                richTextBox1.Clear();
            }
            catch
            {
                MessageBox.Show("ERROR");
                richTextBox1.Clear();
            }

            richTextBox1.Text += "Название: "+ product.Name + "\n";
            richTextBox1.Text += "Инвентарный номер: " + product.ID + "\n";
            richTextBox1.Text += "Количество: " + product.Amount + "\n";
            richTextBox1.Text += "Цена: " + product.Price + "\n";
            richTextBox1.Text += "Размер: " + product.Size + "\n";
            richTextBox1.Text += "Дата поставки: " + product.Date + "\n";
            richTextBox1.Text += "Производитель: " + comboBox1.SelectedItem + "\n";
        }   

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            foreach(RadioButton radio in groupBox1.Controls)
            {
                radio.Checked = false;
            }
            numericUpDown1.Value = 0;
            trackBar1.Value = 0;
            richTextBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();  
            XmlSerializer formatter = new XmlSerializer(typeof(Product));
            XmlSerializer formatter2 = new XmlSerializer(typeof(Organization));

            using (FileStream fs = new FileStream("product.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, product);
                formatter2.Serialize(fs, form2.org);
            }

            MessageBox.Show("OK");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));

            using (FileStream fs = new FileStream("product.xml", FileMode.OpenOrCreate))
            {
                Product newproduct = formatter.Deserialize(fs) as Product;

                if (newproduct != null)
                {
                    richTextBox1.Text += "Название: " + newproduct.Name + "\n";
                    richTextBox1.Text += "Инвентарный номер: " + newproduct.ID + "\n";
                    richTextBox1.Text += "Количество: " + newproduct.Amount + "\n";
                    richTextBox1.Text += "Цена: " + newproduct.Price + "\n";
                    richTextBox1.Text += "Размер: " + newproduct.Size + "\n";
                    richTextBox1.Text += "Дата поставки: " + newproduct.Date + "\n";
                    richTextBox1.Text += "Организация: " + newproduct.organization.OrganizationName + "\n";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            listOrg.Add(form2.component);
            comboBox1.Items.Add(listOrg.Last().OrganizationName);
        }
    }
}