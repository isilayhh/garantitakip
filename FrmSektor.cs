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
    public partial class FrmSektor : Form
    {
        public FrmSektor()
        {
            InitializeComponent();
        }

        stajyerEntities3 db = new stajyerEntities3();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmSektor_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.tbl_sektor.Select(x => new { x.IND, x.FIRMANO, x.SEKTORADI }).ToList();
            
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            tbl_sektor sektor = new tbl_sektor();
            sektor.SEKTORADI = textBox1.Text;
            db.tbl_sektor.Add(sektor);
            db.SaveChanges();
            MessageBox.Show("Sektör Eklenmiştir");
            FrmSektor_Load(sender, e);
            




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1 != null)
                {
                    int a = int.Parse(textBox2.Text);
                    var sektoradi = db.tbl_sektor.Where(w => w.IND == a).FirstOrDefault();
                    db.tbl_sektor.Remove(sektoradi);
                    db.SaveChanges();
                    FrmSektor_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Hata");
                }
            }
            catch 
            {

                MessageBox.Show("Kullanıcı Bulunamadı");
            }
            
        }

       

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            

            try
            {
                int a = int.Parse(textBox2.Text);
                if (textBox1 != null)
                {
                    tbl_sektor guncelle = db.tbl_sektor.Where(x => x.IND == a).FirstOrDefault();
                    guncelle.SEKTORADI = textBox1.Text;
                    db.SaveChanges();
                    MessageBox.Show("Güncellendi");
                    FrmSektor_Load(sender, e);


                }

                else
                {
                    MessageBox.Show("Kullanıcı Bulunamadı");
                }

            }
            catch 
            {

                MessageBox.Show("Kullanıcı Bulunamadı");
            }
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            txtArama.Clear();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
          
        {

            dataGridView1.DataSource = db.tbl_sektor.Where(x => x.SEKTORADI.Contains(txtArama.Text) ).ToList();
        }

        private void txtArama_KeyUp(object sender, KeyEventArgs e)

           
        {
        }
    }
}
