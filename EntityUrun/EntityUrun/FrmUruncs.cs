using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityUrun
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities1 db = new DbEntityUrunEntities1();

        private void btnListele_Click(object sender, EventArgs e)
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
            tu.KATEGORI = int.Parse(comboBox1.SelectedValue.ToString());
            tu.FIYAT = decimal.Parse(txtfiyat.Text);
            tu.DURUM = true;
            db.TBLURUN.Add(tu);
            db.SaveChanges();
            MessageBox.Show("Ürün Eklenmiştir ");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txtid.Text);
            var urun = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silinmiştir ");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txtid.Text);
            var urun = db.TBLURUN.Find(id);
            urun.URUNAD = txtad.Text;
            urun.URUNMARKA = txtmarka.Text;
            urun.STOK = short.Parse(txtstok.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellenmiştir ");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBLKATEGORI
                               select new
                               {
                                   x.ID,
                                   x.AD
                               }
                               ).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = kategoriler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //txtad.Text = comboBox1.SelectedValue.ToString();
            txtid.Text = " ";
            txtad.Text = " ";

        }
    }
}
