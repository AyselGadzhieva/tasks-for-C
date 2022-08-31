using System;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //выбор кнопки помощь
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //выбор кнопки "длинами трех сторон"
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //выбор кнопки закрыть
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //выбор кнопки "координатами трех вершин на плоскости"
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //выбор кнопки "координатами трех вершин в пространстве"
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
