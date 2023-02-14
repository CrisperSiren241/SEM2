using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
            textBox2.Text = "1";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                double Value = Convert.ToDouble(textBox1.Text);
                textBox1.Text = Convert.ToString(Math.Atan(Math.Tan(Value) * (180 / Math.PI)));
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введено значение!");
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            char i = '0';
            textBox1.Text += i;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            char i = '1';
            textBox1.Text += i;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            char i = '2';
            textBox1.Text += i;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            char i = '3';
            textBox1.Text += i;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            char i = '.';
            textBox1.Text += i;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            char i = '4';
            textBox1.Text += i;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            char i = '5';
            textBox1.Text += i;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            char i = '6';
            textBox1.Text += i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char i = '7';
            textBox1.Text += i;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char i = '8';
            textBox1.Text += i;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char i = '9';
            textBox1.Text += i;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                double Value = Convert.ToDouble(textBox1.Text);
                textBox1.Text = Convert.ToString(Math.Sin(Value * (Math.PI / 180)));
            } 
            catch(FormatException)
            {
                MessageBox.Show("Неверно введено значение!");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                double Value = Convert.ToDouble(textBox1.Text);
                textBox1.Text = Convert.ToString(Math.Cos(Value * (Math.PI / 180)));
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введено исключение!");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                double Value = Convert.ToDouble(textBox1.Text);
                textBox1.Text = Convert.ToString(Math.Tan(Value * (Math.PI / 180)));
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введено исключение!");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                double Value = Convert.ToDouble(textBox1.Text);
                textBox1.Text = Convert.ToString(Math.Tan(1/(Value * (Math.PI / 180))));
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введено исключение!");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                double Value = Convert.ToDouble(textBox1.Text);
                textBox1.Text = Convert.ToString(Math.Asin(Math.Sin(Value) * (180 / Math.PI)));
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введено исключение!");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                double Value = Convert.ToDouble(textBox1.Text);
                textBox1.Text = Convert.ToString(Math.Acos(Math.Cos(Value) * (180 / Math.PI)));
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введено исключение!");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                double Value = Convert.ToDouble(textBox1.Text);
                textBox1.Text = Convert.ToString(1/Math.Atan(Math.Tan(Value) * (180 / Math.PI)));
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введено значение!");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                double FirstValue = Convert.ToDouble(textBox1.Text);
                double SecondValue = Convert.ToDouble(textBox2.Text);
                textBox1.Text = Convert.ToString(Math.Pow(FirstValue, SecondValue));
            }
            catch(FormatException)
            {
                MessageBox.Show("Неверно введены значения!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                double FirstValue = Convert.ToDouble(textBox1.Text);
                Controls.Add(label1);
                Controls.Add(textBox2);
                double SecondValue = Convert.ToDouble(textBox2.Text);
                textBox1.Text = "";
                textBox1.Text = Convert.ToString(Math.Pow(FirstValue, 1 / SecondValue));
            }
            catch(FormatException)
            {
                MessageBox.Show("Неверно введены данные!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox3.Text;
                Convert.ToDouble(textBox1.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Error");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Пусто!");
            }
            else
            {
                textBox3.Text = textBox1.Text;
            }
        }
    }
}
