using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Заказ
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        String password = "password";
     

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Tag) 
            {
                case "Order":
                    Open.OpenExel();
                    FormOrder order = new FormOrder();

                    // насторойка расположение формы
                    order.Left = this.Left;
                    order.Top = this.Top;
                    

                    order.Show();
                    this.Hide();
                    break;

                case "Exit":
                    DialogResult r = MessageBox.Show("Вы действительно хотите выйти ?","Выход", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else { }

                    break;



                case "Edit":     
                    string text = Interaction.InputBox("Введите парль", "Пароль");
                    if (text == password)
                    {
                        FormEdit edit = new FormEdit();

                        edit.Left = this.Left;
                        edit.Top = this.Top;

                        edit.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Пароль не верный", "Пароль");
                    }
                    
                    
                    break;

                case"Price":
                    ClassTotal.excelApp.Visible = true;
                    break;



            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClassTotal.excelApp.Quit();      //Выйти из Excel
                                             //Уничтожить все COM-объекты
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(ClassTotal.excelApp);
            //Заставляет сборщик мусора провести сборку мусора
            GC.Collect();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                ClassTotal.excelApp = new Excel.Application();
               // ClassTotal.excelApp.Visible = false;
                        Open.OpenExel();
            }

            catch 
            {
                MessageBox.Show("Нет MS Excel");
            }





        }
    }

}
