using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//Библиотека для работы с массивом
namespace LibMas
{
    public class Massiv
    { 
        //Сохранить файл
        public static void SaveFile(DataGridView table)
        {//создаем и настраиваем элемент SaveFileDialog
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) |*.*|Текстовые файлы |*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            //открываем диалоговое окно и при успехе работаем с файлом
            if (save.ShowDialog()==DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(save.FileName);

                file.WriteLine(table.ColumnCount);
                file.WriteLine(table.RowCount);

                for (int i = 0; i < table.ColumnCount; i++)
                    for (int j = 0; j < table.RowCount; j++)
                        file.WriteLine(table[i, j].Value);
                file.Close();
            }
        }
        //Открыть файл
        public static void OpenFile(DataGridView table)
        {////создаем и настраиваем элемент OpenFileDialog 
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter= "Все файлы (*.*) |*.*|Текстовые файлы |*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            int columns = 0,
                rows = 0;
            //открываем диалоговое окно и при успехе работаем с файлом
            if (open.ShowDialog()==DialogResult.OK)
            {
                StreamReader file = new StreamReader(open.FileName);

                if (Int32.TryParse(file.ReadLine(), out columns))
                {
                    if (Int32.TryParse(file.ReadLine(), out rows))
                    {
                        table.ColumnCount = columns;
                        table.RowCount = rows;
                            }
                    else//иначе выводим сообщение об ошибке
                    {
                        MessageBox.Show("Ошибка!");
                        return;//прерываем цикл
                    }
                }
                else//иначе выводим сообщение об ошибке
                {
                    MessageBox.Show("Ошибка!");
                    return;//прерываем цикл
                }

                for (int i=0;i<columns; i++)
                {
                    for (int j=0; j<rows; j++)
                    {
                        table[i, j].Value = file.ReadLine();
                    }
                }
            }
        }
        //Заполнить
        public static void InitMas(DataGridView table, int randMin, int randMax)
        {
            Random rnd = new Random();
            for (int i = 0; i < table.ColumnCount; i++)
                for (int j = 0; j < table.RowCount; j++)
                {//заполняем таблицу случайными значениями в указанном диапазоне
                    table[i, j].Value = rnd.Next(randMin, randMax);
                }
        }
        //Очистить
        public static void CleanMas(DataGridView table)
        {
            for (int i = 0; i < table.ColumnCount; i++)
                for (int j = 0; j < table.RowCount; j++)
                {//Очищаем ячейки таблицы
                    table[i, j].Value = "";
                }
        }

    }
}
