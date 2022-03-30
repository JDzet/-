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

namespace Заказ
{
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
        }

        private void FormPrice_list_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form open = Application.OpenForms[0];

            open.StartPosition = FormStartPosition.Manual;
            open.Left = this.Left;
            open.Top = this.Top;

            open.Show();
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Вы действительно хотите вернуться на главную ?", "Выход", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
            else { }
           
        }
    }
}
