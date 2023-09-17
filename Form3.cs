using System;
using System.Windows.Forms;

namespace sqlite
{
    public partial class Form3 : Form
    {
        public string name;
        public string owner;
        public string rating;
        public string adress;
        public bool isOk = false;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(string name, string owner, string rating, string adress)
        {
            this.name = name;
            this.owner = owner;
            this.rating = rating;
            this.adress = adress;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = $"{name}";
            textBox2.Text = $"{owner}";
            textBox3.Text = $"{rating}";
            textBox4.Text = $"{adress}";
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
                rating = textBox3.Text;
                adress = textBox4.Text;
                isOk = true;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
