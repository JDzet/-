using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Заказ
{
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
        }
        
        private void FormOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form open = Application.OpenForms[0];

            // насторойка расположение формы
            open.StartPosition = FormStartPosition.Manual;
            open.Left = this.Left;
            open.Top = this.Top;

            open.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSelection price = new FormSelection();

            price.Left = this.Left;
            price.Top = this.Top;

            price.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Вы действительно хотите вернуться на главную ?", "Выход", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
            else { };
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
         int count = Money.RandomCount();
         labelАccount.Text = "На вашем счету: " + count;
        }
    }
}
