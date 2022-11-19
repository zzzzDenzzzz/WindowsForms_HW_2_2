using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

/*Подсчитайте количество дней между выбранными датами с помо-
щью DateTimePicker и выведите результат на форму с использование 
элемента Label. Форму главного окна сделайте в виде круга.*/

namespace Task_2
{
    public partial class Form1 : Form
    {
        // точка для перемещения
        Point moveStart; 
        // разница между датами
        TimeSpan timeSpan;

        public Form1()
        {
            InitializeComponent();
            button_close.Click += button_close_Click;
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
        }

        /// <summary>
        /// закрытие формы
        /// </summary>
        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphicsPath myPath = new GraphicsPath();
            // создаем эллипс с высотой и шириной формы
            myPath.AddEllipse(0, 0, Width, Height);
            // создаем с помощью элипса ту область формы, которую мы хотим видеть
            Region myRegion = new Region(myPath);
            // устанавливаем видимую область
            Region = myRegion;
            timeSpan = new TimeSpan();
            label_result.Visible = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if ((e.Button & MouseButtons.Left) != 0)
            {
                // получаем новую точку положения формы
                Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                // устанавливаем положение формы
                Location = new Point(Location.X + deltaPos.X, Location.Y + deltaPos.Y);
            }
        }

        /// <summary>
        /// вычисляет разницу в днях между датами
        /// </summary>
        void TimeSpanDay()
        {
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;
            DateTime min, max;
            min = (date1 < date2) ? date1 : date2;
            max = (date1 > date2) ? date1 : date2;
            timeSpan = max.Subtract(min);
            label_result.Text = $"{timeSpan.Days} days";
            label_result.Visible = true;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            TimeSpanDay();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TimeSpanDay();
        }
    }
}
