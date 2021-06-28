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
    public partial class GarantiDurumFrm : Form
    {
        public GarantiDurumFrm()
        {
            InitializeComponent();
        }
        stajyerEntities3 db = new stajyerEntities3();
        private void GarantiDurumFrm_Load(object sender, EventArgs e)
        {
            btnGarantiBaslat.Visible = false;

       var datacari = db.tbl_cari.Select(a=>new { a.SOYAD}).ToList();

            dataGridView1.DataSource = datacari;

        }


        private void btnGarantiBaslat_Click(object sender, EventArgs e)
        {
            GarantiBaşlatForm frm = new GarantiBaşlatForm();
            frm.Show();
        }

        private void txtBit_ValueChanged(object sender, EventArgs e)
        {

            TimeSpan fark;
            DateTime kücükTarih = Convert.ToDateTime(txtBas.Text);
            DateTime büyükTarih = Convert.ToDateTime(txtBit.Text);
            fark = (büyükTarih - kücükTarih);
            txtFark.Text = fark.TotalDays.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            return;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int icari = Convert.ToInt32(row.Cells[0].Value);

                tbl_cari tblcari = db.tbl_cari.Find(icari);

                //MessageBox.Show(tblcari.tbl_firmaTipi.FIRMATİPİ);
                //MessageBox.Show(tblcari.tbl_hizmetturu.HIZMETTURU);
                //foreach (var item in tblcari.tbl_marka)
                //{
                //    MessageBox.Show("Marka : " + item.MARKAADI);
                //}
                //MessageBox.Show(tblcari.tbl_status.STATUS.Value.ToString());





                DateTime bastar = tblcari.tbl_baslangicBitisTarih.BASLANGICTARİH ?? DateTime.Now.Date;
                DateTime bittar = tblcari.tbl_baslangicBitisTarih.BİTİSTARİH ?? DateTime.Now.Date;
                DateTime vartar = new DateTime(1900, 1, 1);
                if (bastar < vartar)
                {
                    MessageBox.Show("Tarih Yok");
                    return;
                }
                if (bittar < vartar)
                {
                    MessageBox.Show("Tarih Yok");
                    return;
                }


                txtFirmaAd.Text = tblcari.FIRMAADI;
                txtHizmet.Text = tblcari.tbl_hizmetturu.HIZMETTURU;


                //aktarılan bitiş tarihi verilerin garanti durumunu form üzerinden gösterilmesi
                if (bittar != null)
                {
                    btnGarantiBaslat.Visible = false;
                    txtBit.Visible = true;

                    txtBit.Text = bittar.ToString();
                }
                else
                {
                    btnGarantiBaslat.Visible = false;
                    txtBit.Visible = false;

                }
                //aktarılan Başlangıç tarihi verilerin garanti durumunu form üzerinden gösterilmesi
                if (bastar != null)
                {
                    btnGarantiBaslat.Visible = false;
                    txtBasGrantiKontrol.Visible = false;
                    txtBas.Visible = true;
                    txtBas.Text = bastar.ToString();
                }
                else
                {
                    txtFark.Visible = false;
                    txtBasGrantiKontrol.Visible = true;

                    txtBas.Visible = false;
                }
                //garantisi başlamamışsa garanti başlat butonu görünür olur diğer if bloklarında ise bu botunu görünür yaptım
                if (txtBasGrantiKontrol.Visible == true)
                {
                    btnGarantiBaslat.Visible = true;

                }



                TimeSpan fark, bittimi;
                DateTime kücükTarih = bastar;
                DateTime büyükTarih = bittar;
                DateTime bugunTarih = txtbugun.Value;
                fark = (büyükTarih - kücükTarih);
                bittimi = (bugunTarih - büyükTarih);
                if (fark.TotalDays > 0)
                {
                    txtFark.Visible = true;
                    txtFark.Text = "Garanti Bitimine Kalan Gün Sayısı: " + fark.TotalDays.ToString();
                }

                if (bittimi.TotalDays > 0)
                {

                    txtFark.Text = "Garantisi Bitmiştir";
                }
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    List<tbl_status> statuslar = db.tbl_status.ToList();
        //    foreach (var item in statuslar)
        //    {
        //        MessageBox.Show(item.STATUS.Value.ToString());
        //        foreach (var ccari in item.tbl_cari)
        //        {
        //            MessageBox.Show(ccari.FIRMAADI);
        //        }
        //    }
        //}
    }
}