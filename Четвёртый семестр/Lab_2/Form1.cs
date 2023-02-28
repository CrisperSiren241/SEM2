using System.Xml.Serialization;
using System;
using System.Runtime.Serialization;
using System.Linq;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        List<Product> list = new List<Product>();
        List<Organization> listOrg = new List<Organization>();
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = String.Format("������: ������� �������� - {0} ��", trackBar1.Value);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            try
            {
                product.Name = textBox1.Text;
                product.ID = maskedTextBox1.Text;
                product.Amount = Convert.ToInt32(numericUpDown1.Value);
                product.Price = Convert.ToInt32(textBox2.Text);
                product.Size = trackBar1.Value;
                product.Date = dateTimePicker1.Text;

                if (radioButton1.Checked) product.Type = "�������";
                else if (radioButton2.Checked) product.Type = "�������";
                else if (radioButton3.Checked) product.Type = "�������";
                else if (radioButton4.Checked) product.Type = "���������������";

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

            richTextBox1.Text += "--------------------------------------" + "\n";
            richTextBox1.Text += "��������: "+ product.Name + "\n";
            richTextBox1.Text += "����������� �����: " + product.ID + "\n";
            richTextBox1.Text += "����������: " + product.Amount + "\n";
            richTextBox1.Text += "����: " + product.Price + "\n";
            richTextBox1.Text += "������: " + product.Size + "\n";
            richTextBox1.Text += "���� ��������: " + product.Date + "\n";
            richTextBox1.Text += "�������������: " + comboBox1.SelectedItem + "\n";
            richTextBox1.Text += "--------------------------------------" + "\n";

            list.Add(product);
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
            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));

            using (FileStream fs = new FileStream("NewFile.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);
            }

            MessageBox.Show("OK");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));

            using (FileStream fs = new FileStream("NewFile.xml", FileMode.OpenOrCreate))
            {
                List<Product>? newproduct = formatter.Deserialize(fs) as List<Product>;

                if(newproduct != null)
                {
                    foreach(Product product in newproduct)
                    {
                        richTextBox1.Text += "��������: " + product.Name + "\n";
                        richTextBox1.Text += "����������� �����: " + product.ID + "\n";
                        richTextBox1.Text += "����������: " + product.Amount + "\n";
                        richTextBox1.Text += "����: " + product.Price + "\n";
                        richTextBox1.Text += "������: " + product.Size + "\n";
                        richTextBox1.Text += "���� ��������: " + product.Date + "\n";
                        richTextBox1.Text += "�����������: " + product.Organization.OrganizationName + "\n";
                    }
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
