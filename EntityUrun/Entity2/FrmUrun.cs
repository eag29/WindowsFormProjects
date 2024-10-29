using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity2
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLURUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.URUNMARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            x.TBLKATEGORI.AD,
                                            x.DURUM
                                        }).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBLURUN tu = new TBLURUN();
            tu.URUNAD = txtad.Text;
            tu.URUNMARKA = txtmarka.Text;
            tu.STOK = short.Parse(txtstok.Text);
            tu.FIYAT = int.Parse(txtfiyat.Text);
            db.TBLURUN.Add(tu);
            db.SaveChanges();
            MessageBox.Show("Ürün eklenmiştir ");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(textBox1.Text);
            var arananid = db.TBLURUN.Find(id);
            arananid.STOK = short.Parse(txtstok.Text);
            arananid.FIYAT = int.Parse(txtfiyat.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellenmiştir ");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string ad = txtad.Text;
            var arananad= db.TBLURUN.Find(ad);
            db.TBLURUN.Remove(arananad);
            db.SaveChanges();
            MessageBox.Show("Kategori Silinmiştir ");
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = " ";
            txtad.Text = " ";
            txtstok.Text = " ";
            txtfiyat.Text = " ";
            txtmarka.Text = " ";
            txtdurum.Text = " ";
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = ( from x in db.TBLKATEGORI 
                                select new
                                {
                                    x.ID,
                                    x.AD,
                                }).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = kategoriler;
        }
    }
}
