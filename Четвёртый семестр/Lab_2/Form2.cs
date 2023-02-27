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
    
    public partial class Form2 : Form
    {
        public Organization component;
        public Organization? org = new Organization();
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            org.OrganizationName = textBox1.Text;
            org.OrganizationCountry = textBox2.Text;
            org.OrganizationAdress = textBox3.Text;
            org.OrganizationNumber = textBox4.Text;

            component = org;
            this.Close();
        }
    }
}
