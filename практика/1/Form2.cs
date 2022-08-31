using System;
using System.Windows.Forms;

namespace _1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //подсказка для длины первой стороны
            textBox1.Text = "    Введите А";
            //подсказка для длины второй стороны
            textBox2.Text = "    Введите B";
            //подсказка для длины третьей стороны
            textBox3.Text = "    Введите C";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //для закрытия данного "окна"
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для а; ограничения на ввод;
            //цифры, клавиша BackSpace и запятая в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для b; ограничения на ввод;
            //цифры, клавиша BackSpace и запятая в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для c; ограничения на ввод;
            //цифры, клавиша BackSpace и запятая в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox1.Text == "    Введите А") {textBox1.Text = "";}

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox2.Text == "    Введите B") { textBox2.Text = ""; }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox3.Text == "    Введите C") { textBox3.Text = ""; }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox3.Text == "") { textBox3.Text = "    Введите C"; }
            else
            {
                double b;
                string a = textBox1.Text;
                double.TryParse(a, out b);
                if (b == 0) { MessageBox.Show("Длина не может быть равна 0!"); } else { textBox1.Text = Convert.ToString(b); }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox2.Text == "") { textBox2.Text = "    Введите B"; }
            else
            {
                double b;
                string a = textBox1.Text;
                double.TryParse(a, out b);
                if (b == 0) { MessageBox.Show("Длина не может быть равна 0!"); } else { textBox1.Text = Convert.ToString(b); }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox1.Text == "") { textBox1.Text = "    Введите А"; }
            else
            {
                double b;
                string a = textBox1.Text;
                double.TryParse(a, out b);
                if (b == 0) { MessageBox.Show("Длина не может быть равна 0!"); } else { textBox1.Text = Convert.ToString(b); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // вывод данных.
            // здесь идёт инициализация переменных; ещё одна проверка для сущей безопасности;
            // расчёты по формулам, и вывод соответствующего значения
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "")
            {
                double p;
                double r;
                double a;
                double b;
                double c;
                double.TryParse((textBox1.Text), out a); double.TryParse((textBox2.Text), out b); double.TryParse((textBox3.Text), out c);
                if (a + b > c & a + c > b & c + b > a)
                {
                    p = (a + b + c) / 2;
                    r = Math.Sqrt((p - a) * (p - b) * (p - c) / p);
                    Otv.Text = Convert.ToString(r);}
                else
                { MessageBox.Show("Такого треугольника не существует!"); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //сброс данных.
            //поля очищаются от вводимых ранее данных
            //текст - подсказка возвращяется на своё место
            textBox1.Text = "    Введите А";
            textBox2.Text = "    Введите B";
            textBox3.Text = "    Введите C";
            Otv.Text = "0";
        }
    }
}
