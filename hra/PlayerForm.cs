using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hra
{
    public partial class PlayerForm : Form
    {
        private static PlayerForm _instance;

        public static PlayerForm Insance { get { return _instance; } }
        public PlayerForm()
        {
            InitializeComponent();
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utils.Instance.ChangeForm(this, new GameForm(new Player(textBox1.Text)));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            else if (textBox1.Text.Length >= 6)
            {
                button1.Enabled = true;
                return;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
