namespace hra
{
    public partial class Kosticky : Form
    {
        public Kosticky()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utils.Instance.ChangeForm(this, new PlayerForm());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}