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
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter numbers only.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox1.Select(textBox1.Text.Length, 0);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter numbers only.");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
                textBox3.Select(textBox3.Text.Length, 0);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter numbers only.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                textBox2.Select(textBox2.Text.Length, 0);
            }
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
