using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace garantiTakip
{
    public partial class FrmAra : Form
    {
        stajyerEntities3 db = new stajyerEntities3();
        AnasayfaFrm Form;
        public FrmAra(AnasayfaFrm frm)
        {
            InitializeComponent();
            Form = frm;
        }
       
        private void btnAra_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text !="" )
            {
               int firmano = Convert.ToInt32(textBox1.Text);

                tbl_cari CCari = db.tbl_cari.Find(firmano);


                Form.Getir(CCari, firmano);
            }
            else
            {
                MessageBox.Show("Firma No Boş Bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

     

        private void FrmAra_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
        }
    }
}
