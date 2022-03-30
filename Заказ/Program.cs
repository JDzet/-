using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Заказ
{
    public class Money
    {
        static int money = 0;
        public static int RandomCount()
        {
            if (money <= 0)
            {
                Random random = new Random();
                money = random.Next(50000, 500000);
            }

            return money;   
        }
    }

    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
    public class ClassTotal
    {
        public static Excel.Application excelApp; // Сервер Excel
        public static Excel.Workbook excelBook; // Отдельная книга
        public static Excel.Worksheet excelSheet; //Один лист
        public static Excel.Range excelCells; //Ячейки
        


    }

    public class Open
    {
        public static void OpenExel()
        {
            try
            {
                
                ClassTotal.excelApp.Visible = false;

                string path = Application.StartupPath;
                string fileName = path + @"\data.xlsx"; // Абсолютный путь к файлу
                if (File.Exists(fileName)) // Проверка существует ли  файл
                {
                    // Открытие книги Excel
                    ClassTotal.excelBook = ClassTotal.excelApp.Workbooks.Open(fileName);
                }
                else
                {
                    MessageBox.Show("Файл с товаром отсутствует");

                }

            }
            catch
            {
                MessageBox.Show("Скачай MS Excel");


            }

        }
    }

}
