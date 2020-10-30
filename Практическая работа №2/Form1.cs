//Практическая работа №2
//Монахов Андрей ИСП-31
// Ввести  n целых чисел. Вычислить для чисел > 0 функцию x . Результат обработки каждого числа вывести на экран. 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LibMas;
using Lib_4;

namespace Практическая_работа__2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Pаполнить
        private void button1_Click(object sender, EventArgs e)
        {
            //Используем функции для работы с таблицей
            Massiv.CleanMas(table);//Очищаем
            Massiv.CleanMas(resultTable);
            int randMin = Convert.ToInt32(min.Value);//получаем минимальное,
            int randMax = Convert.ToInt32(max.Value);//максимальное значение
            Massiv.InitMas(table, randMin, randMax);//Заполняем таблицу с помощью функции
        }
        //Рассчитать
        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Sqr(table, resultTable);//Используем функцию для вычислений
        }
        //Новый
        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table.ColumnCount = 5;//Столбцы
            table.RowCount = 1;//строки
            //Очищаем исходную таблицу
            for (int i = 0; i < table.ColumnCount; i++)
                for (int j = 0; j < table.RowCount; j++)
                {
                    table[i, j].Value = "";
                }
            resultTable.ColumnCount = 5;
            resultTable.RowCount = 1;
            //Очищаем таблицу с результатом
            for (int i = 0; i < resultTable.ColumnCount; i++)
                for (int j = 0; j < resultTable.RowCount; j++)
                {
                    resultTable[i, j].Value = "";
                }
        }
        //При загрузке формы устанавливаем размеры таблиц
        private void Form1_Load(object sender, EventArgs e)
        {
            table.ColumnCount = 5;
            table.RowCount = 1;
            resultTable.ColumnCount = 5;
            resultTable.RowCount = 1;
        }
        //Очистить
        private void button3_Click(object sender, EventArgs e)
        {
            Massiv.CleanMas(table);//очищаем исх. таблицу
            Massiv.CleanMas(resultTable);//очищаем табл. с результатом
        }
        //Сохранить
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Massiv.SaveFile(table);//сохраняем таблицу в файл с помощью функции
        }
        //открыть
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Massiv.OpenFile(table);//открываем файл с помощью функции
        }
        //изменить кол-во столбцов
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //устанавливаем новые значения количкества столбцов для двух таблиц
            table.ColumnCount = Convert.ToInt32(numericUpDown1.Value);
            resultTable.ColumnCount = Convert.ToInt32(numericUpDown1.Value);
        }
        //О программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Практическая работа №2\n" +//выводим сообщение о программе
                "Монахов Андрей ИСП-31\n" +
                "Ввести  n целых чисел. Вычислить для чисел > 0 функцию x . Результат обработки каждого числа вывести на экран.");
        }

        private void min_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
