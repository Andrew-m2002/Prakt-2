using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib_4
{
    public class Class1
    {//класс Корень чисел>0
        public static void Sqr(DataGridView table, DataGridView resultTable)
        {
            int dop, i;
            for (i = 0; i < table.ColumnCount; i++)
            {//если в ячейке есть число
                if (Int32.TryParse(Convert.ToString(table[i, 0].Value), out dop))
                {
                    if (dop > 0)//если число больше нуля
                    {//Вычисляем корень
                        resultTable[i, 0].Value = Math.Round(Math.Sqrt(dop), 2);
                    }
                    else resultTable[i, 0].Value = 0;//иначе ответ 0

                }
                else//иначе выводим сообщение об ошибке
                {
                    MessageBox.Show("Ошибка!");
                    return;
                }
            }
        }
    }
}
