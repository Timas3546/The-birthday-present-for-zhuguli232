using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace The_birthday_present_for_zhuguli232
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConsoleKeyInfo keypress = new ConsoleKeyInfo();
            PlayXM XM = new PlayXM("birthday_intro_thm.mod");
            XM.Play();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
