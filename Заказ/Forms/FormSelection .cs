using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Заказ
{
    public partial class FormSelection : Form
    {
        public FormSelection()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Вы действительно хотите вернуться на страницу заказа ?", "Выход", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.Close();

            }
            else { }
        }

        private void FormPrice_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form open = Application.OpenForms["FormOrder"];

            // насторойка расположение формы
            open.StartPosition = FormStartPosition.Manual;
            open.Left = this.Left;
            open.Top = this.Top;

            open.Show();
        }

        private void FormSelection_Load(object sender, EventArgs e)
        {
           

            ClassTotal.excelSheet = (Excel.Worksheet)ClassTotal.excelBook.Worksheets.get_Item("Категории");
            ClassTotal.excelSheet = (Excel.Worksheet)ClassTotal.excelBook.Sheets.get_Item("Категории");
            ClassTotal.excelSheet = (Excel.Worksheet)ClassTotal.excelBook.Worksheets["Категории"];
            ClassTotal.excelSheet = (Excel.Worksheet)ClassTotal.excelBook.Sheets[1];




            //Получит все заполненные ячейки
            ClassTotal.excelCells = ClassTotal.excelSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
            //Количество=номеру последней заполненной ячейки
            int count = ClassTotal.excelCells.Row;
            //Перенос в список

            this.listBoxC.Items.Clear();
            for (int i = 1; i <= count; i++)
            {
                ClassTotal.excelCells = ClassTotal.excelSheet.Cells[i, 1];  //Ссылка на нужную ячейку
                if (ClassTotal.excelCells != null)
                {
                    this.listBoxC.Items.Add(ClassTotal.excelCells.Value2);  //Значение этой ячейки
                }
            }

        }

        private void listBoxC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            string category = listBoxC.SelectedItem.ToString();    //Выбранная категория
                                                                            //Связаться с нужным листом-категорией
            ClassTotal.excelSheet = (Excel.Worksheet)ClassTotal.excelBook.Worksheets.get_Item(category);
            //Ссылка на заполненные ячеки в листе

            ClassTotal.excelCells = ClassTotal.excelSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
            //Номер последней заполненной строки – это число строк

            int countFood = ClassTotal.excelCells.Row;
            //Настройки ListView для отображения картинок

            this.listView1.Items.Clear();        //Сначала список надо очистить
            this.listView1.CheckBoxes = true;    //Разрешить флажки возле картинок
            this.listView1.LabelWrap = false;    //Запретить перенос на новую строку
            this.listView1.MultiSelect = true;   //Разрешить выделять несколько
            this.listView1.FullRowSelect = true;
            this.listView1.RightToLeftLayout = false;
            this.listView1.Scrollable = true;    //Обеспечить наличие полос прокрутки
            this.listView1.View = View.LargeIcon;    //Вид компонента – большие картинки
                                                        //Создание списка картинок
            ImageList il = new ImageList();     //Динамический элемент – массив изображений
            il.ImageSize = new Size(250, 250);  //Размеры всех изображений одинаковы
            this.listView1.LargeImageList = il;  //Связать два списка между собой
            il.Images.Clear();              //Очистить список картинок
            string nameFood;                //Название железа
            string cat3;                    //Категория из 3 столбца
            string cat4;                    //Категория из 4 столбца
            double costFood;                //Цена железа 
            string fileFood;                //Файл картинки
            Bitmap bitmap;

            for (int i = 2; i <= countFood; i++)        //Выбор ячеек для из Excel
            {
                ClassTotal.excelCells = ClassTotal.excelSheet.Cells[i, 1];      //Ссылка на ячейку
                nameFood = ClassTotal.excelCells.Value2;        //Название железа

                ClassTotal.excelCells = ClassTotal.excelSheet.Cells[i, 2];      
                costFood = ClassTotal.excelCells.Value2;        //Цена железа

                ClassTotal.excelCells = ClassTotal.excelSheet.Cells[i, 3];
                cat3 = ClassTotal.excelCells.Value2;            //Категория из 3 столбца

               ClassTotal.excelCells = ClassTotal.excelSheet.Cells[i, 4];
               cat4 = ClassTotal.excelCells.Value2;             //Категория из 4 столбца



                ListViewItem lvi = new ListViewItem();      //Элемент списка
                lvi.Text = nameFood + " | " + cat3 + " | \n" + cat4 + " - " + costFood.ToString() + "₽";  // Выводимые строки под картинкой
                                                                  
                fileFood = path + @"\" + category + @"\" + nameFood + ".jpg";  //Абсолютный путь к файлу с изображением 
                if (File.Exists(fileFood))				//Проверка существования картинки
                {
                    bitmap = new Bitmap(fileFood);		
                }
                else
                {
                    bitmap = Properties.Resources.NotImage;		
                }
                il.Images.Add(bitmap);      //Добавить изображения в массив картинок

                lvi.ImageIndex = (i - 2);       //Для элемента списка задать индекс картинки

                listView1.Items.Add(lvi);        // добавляем элемент в ListView
            }
        }

    }
}
