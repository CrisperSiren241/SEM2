using System.Xml.Serialization;
using System;
using System.Runtime.Serialization;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        public List<Product> list = new List<Product>();
        public List<Product> Serlist = new List<Product>();
        public List<Organization> listOrg = new List<Organization>();
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        ToolStripLabel changeLabel;
        ToolStripLabel amoubtLabel;
        System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();

            infoLabel = new ToolStripLabel();
            changeLabel = new ToolStripLabel();
            amoubtLabel = new ToolStripLabel();
            infoLabel.Text = "������� ���� � �����:";
            changeLabel.Text = "��������";
            amoubtLabel.Text = "������� ���������� ��������: 0";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            statusStrip1.Items.Add(changeLabel);
            statusStrip1.Items.Add(amoubtLabel);


            timer = new System.Windows.Forms.Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString(); 
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
                else if (radioButton3.Checked) product.Type = "���������������";
                else if (radioButton4.Checked) product.Type = "�������";

                foreach(var item in listOrg)
                {
                    if(item.OrganizationName == (string?)comboBox1.SelectedItem)
                    {
                        product.Organization = item;
                        break;
                    }
                }

                List<ValidationResult> results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(product, new ValidationContext(product), results, true))
                {
                    string err = "";
                    foreach (var item in results)
                    {
                        err += item.ErrorMessage + "\n";
                    }
                    throw new Exception(err);
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
                richTextBox1.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                richTextBox1.Clear();
            }

            richTextBox1.Text += "--------------------------------------" + "\n";
            richTextBox1.Text += "��������: "+ product.Name + "\n";
            richTextBox1.Text += "����������� �����: " + product.ID + "\n";
            richTextBox1.Text += "����������: " + product.Amount + "\n";
            richTextBox1.Text += "���: " + product.Type + "\n";
            richTextBox1.Text += "����: " + product.Price + "\n";
            richTextBox1.Text += "������: " + product.Size + "\n";
            richTextBox1.Text += "���� ��������: " + product.Date + "\n";
            richTextBox1.Text += "�������������: " + comboBox1.SelectedItem + "\n";
            richTextBox1.Text += "--------------------------------------" + "\n";

            list.Add(product);

            amoubtLabel.Text = "������� ���������� ��������: " + list.Count;
            changeLabel.Text = "�������� ������";     
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
            changeLabel.Text = "�������";
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
            changeLabel.Text = "������������";
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
                        list.Add(product);
                    }
                    amoubtLabel.Text = "������� ���������� ��������: " + list.Count;
                }

            }
            changeLabel.Text = "��������������";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            listOrg.Add(form2.component);
            comboBox1.Items.Add(listOrg.Last().OrganizationName);

            changeLabel.Text = "��������� �����������";
        }
        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            foreach (var items in list)
            {
                form3.search.Add(items.Name);
            }
            foreach (var items in list)
            {
                form3.newlist.Add(items);
            }
            form3.ShowDialog();
            changeLabel.Text = "�����";
        }
        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembly a = typeof(Program).Assembly;
            string FIO = "����� ���� ���" + "\n";
            MessageBox.Show("����� ���� ���" + "\n" + "������: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            changeLabel.Text = "��������";
        }
        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();

            foreach (var items in list)
            {
                form4.newlist.Add(items);
            }
            form4.ShowDialog();
            changeLabel.Text = "����������";
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            foreach(var items in form.updlist)
            {
                Serlist.Add(items);
            }
            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));

            using (FileStream fs = new FileStream("NewSortFile.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Serlist);
            }
            MessageBox.Show("OK");
            changeLabel.Text = "����������";
        }
    }


}
