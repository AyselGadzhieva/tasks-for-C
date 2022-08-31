using System;
using System.Windows.Forms;

namespace _1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            //для координат первой точки
            textBox1.Text = "    Введите X";
            textBox2.Text = "    Введите Y";
            textBox3.Text = "    Введите Z";
            //для координат второй точки
            textBox4.Text = "    Введите X";
            textBox5.Text = "    Введите Y";
            textBox6.Text = "    Введите Z";
            //для координат третьей точки
            textBox7.Text = "    Введите X";
            textBox8.Text = "    Введите Y";
            textBox9.Text = "    Введите Z";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //для закрытия данного "окна"
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для x1; ограничения на ввод;
            //цифры, клавиша BackSpace, запятая и знак "минуса" в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для y1; ограничения на ввод;
            //цифры, клавиша BackSpace, запятая и знак "минуса" в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для z1; ограничения на ввод;
            //цифры, клавиша BackSpace, запятая и знак "минуса" в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для x2; ограничения на ввод;
            //цифры, клавиша BackSpace, запятая и знак "минуса" в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для y2; ограничения на ввод;
            //цифры, клавиша BackSpace, запятая и знак "минуса" в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для z2; ограничения на ввод;
            //цифры, клавиша BackSpace, запятая и знак "минуса" в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для x3; ограничения на ввод;
            //цифры, клавиша BackSpace, запятая и знак "минуса" в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для y3; ограничения на ввод;
            //цифры, клавиша BackSpace, запятая и знак "минуса" в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            //для z3; ограничения на ввод;
            //цифры, клавиша BackSpace, запятая и знак "минуса" в ASCII
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox1.Text == "    Введите X") { textBox1.Text = ""; }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox2.Text == "    Введите Y") { textBox2.Text = ""; }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox3.Text == "    Введите Z") { textBox3.Text = ""; }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox4.Text == "    Введите X") { textBox4.Text = ""; }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox5.Text == "    Введите Y") { textBox5.Text = ""; }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox6.Text == "    Введите Z") { textBox6.Text = ""; }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox7.Text == "    Введите X") { textBox7.Text = ""; }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox8.Text == "    Введите Y") { textBox8.Text = ""; }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            //после нажатия на поле, для ввода значения, текст-подсказка исчезает
            if (textBox9.Text == "    Введите Z") { textBox9.Text = ""; }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox1.Text == "") { textBox1.Text = "    Введите X"; }
            else
            {
                double b;
                string a = textBox1.Text;
                bool booly = double.TryParse(a, out b);
                if (booly == false) { textBox1.Text = ""; MessageBox.Show("Вы ввели не число!"); textBox1.Text = "    Введите X"; } else { textBox1.Text = Convert.ToString(b); }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox2.Text == "") { textBox2.Text = "    Введите Y"; }
            else
            {
                double b;
                string a = textBox2.Text;
                bool booly = double.TryParse(a, out b);
                if (booly == false) { textBox2.Text = ""; MessageBox.Show("Вы ввели не число!"); textBox2.Text = "    Введите Y"; } else { textBox2.Text = Convert.ToString(b); }
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox3.Text == "") { textBox3.Text = "    Введите Z"; }
            else
            {
                double b;
                string a = textBox3.Text;
                bool booly = double.TryParse(a, out b);
                if (booly == false) { textBox3.Text = ""; MessageBox.Show("Вы ввели не число!"); } else { textBox3.Text = Convert.ToString(b); }
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox4.Text == "") { textBox4.Text = "    Введите X"; }
            else
            {
                double b;
                string a = textBox4.Text;
                bool booly = double.TryParse(a, out b);
                if (booly == false) { textBox4.Text = ""; MessageBox.Show("Вы ввели не число!"); } else { textBox4.Text = Convert.ToString(b); }
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox5.Text == "") { textBox5.Text = "    Введите Y"; }
            else
            {
                double b;
                string a = textBox5.Text;
                bool booly = double.TryParse(a, out b);
                if (booly == false) { textBox5.Text = ""; MessageBox.Show("Вы ввели не число!"); } else { textBox5.Text = Convert.ToString(b); }
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox6.Text == "") { textBox6.Text = "    Введите Z"; }
            else
            {
                double b;
                string a = textBox6.Text;
                bool booly = double.TryParse(a, out b);
                if (booly == false) { textBox6.Text = ""; MessageBox.Show("Вы ввели не число!"); } else { textBox6.Text = Convert.ToString(b); }
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox7.Text == "") { textBox7.Text = "    Введите X"; }
            else
            {
                double b;
                string a = textBox7.Text;
                bool booly = double.TryParse(a, out b);
                if (booly == false) { textBox7.Text = ""; MessageBox.Show("Вы ввели не число!"); } else { textBox7.Text = Convert.ToString(b); }
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox8.Text == "") { textBox8.Text = "    Введите Y"; }
            else
            {
                double b;
                string a = textBox8.Text;
                bool booly = double.TryParse(a, out b);
                if (booly == false) { textBox8.Text = ""; MessageBox.Show("Вы ввели не число!"); } else { textBox8.Text = Convert.ToString(b); }
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            //вводимое значение проверяется на корректность и записывается в данное поле
            if (textBox9.Text == "") { textBox9.Text = "    Введите Z"; }
            else
            {
                double b;
                string a = textBox9.Text;
                bool booly = double.TryParse(a, out b);
                if (booly == false) { textBox9.Text = ""; MessageBox.Show("Вы ввели не число!"); } else { textBox9.Text = Convert.ToString(b); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // вывод данных.
            // здесь идёт инициализация переменных; ещё одна проверка для сущей безопасности;
            // расчёты по формулам, и вывод соответствующего значения
            double p, r, x1, y1, z1, x2, y2, z2, x3, y3, z3, a, b, c;
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "" & textBox6.Text != "" & textBox7.Text != "" & textBox8.Text != "" & textBox9.Text != "" & double.TryParse((textBox1.Text), out x1) & double.TryParse((textBox2.Text), out y1) & double.TryParse((textBox3.Text), out z1) &
            double.TryParse((textBox4.Text), out x2) & double.TryParse((textBox5.Text), out y2) & double.TryParse((textBox6.Text), out z2) & double.TryParse((textBox7.Text), out x3) & double.TryParse((textBox8.Text), out y3) & double.TryParse((textBox9.Text), out z3))
            {
                double.TryParse((textBox1.Text), out x1); double.TryParse((textBox2.Text), out y1); double.TryParse((textBox3.Text), out z1);
                double.TryParse((textBox4.Text), out x2); double.TryParse((textBox5.Text), out y2); double.TryParse((textBox6.Text), out z2);
                double.TryParse((textBox7.Text), out x3); double.TryParse((textBox8.Text), out y3); double.TryParse((textBox9.Text), out z3);
                a = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) + Math.Pow(z1 - z2, 2));
                b = Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2) + Math.Pow(z2 - z3, 2));
                c = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2) + Math.Pow(z1 - z3, 2));
                if (a + b > c & a + c > b & c + b > a)
                {
                    p = (a + b + c) / 2;
                    r = Math.Sqrt((p - a) * (p - b) * (p - c) / p);
                    Otv.Text = Convert.ToString(r);
                }
                else
                { MessageBox.Show("Такого треугольника не существует!"); }
            }
            else
            { MessageBox.Show("Такого треугольника не существует!"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //сброс данных.
            //поля очищаются от вводимых ранее данных
            //текст - подсказка возвращяется на своё место
            textBox1.Text = "    Введите X";
            textBox2.Text = "    Введите Y";
            textBox3.Text = "    Введите Z";
            textBox4.Text = "    Введите X";
            textBox5.Text = "    Введите Y";
            textBox6.Text = "    Введите Z";
            textBox7.Text = "    Введите X";
            textBox8.Text = "    Введите Y";
            textBox9.Text = "    Введите Z";
            Otv.Text = "0";
        }
    }
}
