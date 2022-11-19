using System;
using System.IO;
using System.Windows.Forms;

/*Создайте приложение размером до 720х480 пикселов и разместите 
на главной форме необходимые элементы управления для получения 
информации:
 ■ Фамилия
 ■ Имя
 ■ Отчество
 ■ Пол
 ■ Год и дата рождения
 ■ Семейный статус
 ■ Дополнительная информация
Добавьте кнопку Save и обработчик нажатия кнопки для сохране-
ния информации из элементов управления в файл.*/

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        // переменные для хранения информации
        string surname, name, patronymic, gender, dayOfBirth, familyStatus, additionalInformation;
        // файл для хранения информации
        string file;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// устанавливает значения по умолчанию
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            DefaultValuesVariable();
            DefaultValuesControls();
        }

        /// <summary>
        /// сохраняет и записывает данные в файл,
        /// если недостаточно данных выдается сообщение
        /// </summary>
        private void button_save_Click(object sender, EventArgs e)
        {
            Save();
            if (IsCorrect())
            {
                WritingToFile();
                MessageBox.Show("Данные записаны", "Успешная запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DefaultValuesVariable();
                DefaultValuesControls();
            }
            else
            {
                MessageBox.Show("Недостаточно данных", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// устанавливает переменным значения по умолчанию
        /// </summary>
        void DefaultValuesVariable()
        {
            surname = "";
            name = "";
            patronymic = "";
            gender = radioButton_genderMasculine.Text;
            familyStatus = "";
            additionalInformation = "";
            dayOfBirth = DateTime.Now.ToString();
            file = "";
        }

        /// <summary>
        /// устаналивает значения controls по умолчанию
        /// </summary>
        void DefaultValuesControls()
        {
            textBox_surname.Text = surname;
            textBox_name.Text = name;
            textBox_patronymic.Text = patronymic;
            radioButton_genderMasculine.Checked = true;
            dateTimePicker_dayOfBirth.Value = DateTime.Today;
            textBox_familyStatus.Text = familyStatus;
            textBox_additionalInformation.Text = additionalInformation;
        }

        /// <summary>
        /// сохраняем данные из формы в переменные
        /// </summary>
        void Save()
        {
            // имя сохраняемого файла
            file = $"{textBox_surname.Text.ToUpper()}_{textBox_name.Text.ToUpper()}_{textBox_patronymic.Text.ToUpper()}.txt";

            surname = textBox_surname.Text;
            name = textBox_name.Text;
            patronymic = textBox_patronymic.Text;
            if (radioButton_genderMasculine.Checked)
            {
                gender = radioButton_genderMasculine.Text;
            }
            else
            {
                gender = radioButton_genderFeminine.Text;
            }
            dayOfBirth = dateTimePicker_dayOfBirth.Text;
            familyStatus = textBox_familyStatus.Text;
            additionalInformation = textBox_additionalInformation.Text;
        }

        /// <summary>
        /// записывает данные в файл
        /// </summary>
        void WritingToFile()
        {
            using(StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(surname);
                sw.WriteLine(name);
                sw.WriteLine(patronymic);
                sw.WriteLine(gender);
                sw.WriteLine(dayOfBirth);
                sw.WriteLine(familyStatus);
                sw.WriteLine(additionalInformation);
            }
        }

        /// <summary>
        /// проверяет данные
        /// </summary>
        /// <returns>если имя или фамилия или отчество не пустые строки возвращает true иначе false</returns>
        bool IsCorrect()
        {
            if (surname != "" || name != "" || patronymic != "")
            {
                return true;
            }
            return false;
        }
    }
}
