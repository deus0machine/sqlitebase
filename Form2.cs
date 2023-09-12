using System;
using System.Windows.Forms;

namespace sqlite
{
    public partial class Form2 : Form
    {
        public string name;
        public string owner;
        public int rating;
        public string adress;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("The 'name' field is not filled in");
                Close();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("The 'owner' field is not filled in");
                Close();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("The 'rating' field is not filled in");
                Close();
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("The 'adress' field is not filled in");
                Close();
            }
            else
            {
                name = textBox1.Text;
                owner = textBox2.Text;
                rating = int.Parse(textBox3.Text);
                adress = textBox4.Text;
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
