using problem_plecakowy;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int liczbaPrzedmiotow = int.Parse(textBox1.Text);
            int seed = int.Parse(textBox2.Text);
            int pojemnoscPlecaka = int.Parse(textBox3.Text);

            ProblemPlecakowy problem = new ProblemPlecakowy(liczbaPrzedmiotow, seed);

            var wynik = problem.Solve(pojemnoscPlecaka);
            textBox5.Text = problem.ToString();
            textBox4.Text = wynik.ToString(); // Aktualizacja textBox4
            textBox4.AppendText(Environment.NewLine);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
