using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Пользователь вводит дату своего рождения в элементы TextBox. 
Программа выделяет в элементе MonthCalendar и отображает указан-
ный день.*/

namespace Task_3
{
    public partial class Form1 : Form
    {
        int day, month, year;
        DateTime date;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ParseDay() == true && ParseMonth() == true && ParseYear() == true && ParseDate() == true)
            {
                SetDate();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (ParseDay() == true && ParseMonth() == true && ParseYear() == true && ParseDate() == true)
            {
                SetDate();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (ParseDay() == true && ParseMonth() == true && ParseYear() == true && ParseDate() == true)
            {
                SetDate();
            }
        }

        bool ParseDay()
        {
            if (int.TryParse(textBox1.Text, out int day))
            {
                this.day = day;
                return true;
            }
            return false;
        }

        bool ParseMonth()
        {
            if (int.TryParse(textBox2.Text, out int month))
            {
                this.month = month;
                return true;
            }
            return false;
        }

        bool ParseYear()
        {
            if (int.TryParse(textBox3.Text, out int year))
            {
                this.year = year;
                return true;
            }
            return false;
        }

        bool ParseDate()
        {
            if (DateTime.TryParse($"{day}.{month}.{year}", out DateTime date))
            {
                this.date = date;
                return true;
            }
            return false;
        }

        void SetDate()
        {
            monthCalendar1.SetDate(date);
        }
    }
}
