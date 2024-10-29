using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity2
{
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLKATEGORI.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBLKATEGORI ta = new TBLKATEGORI();
            ta.AD = textBox2.Text;
            db.TBLKATEGORI.Add(ta);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklenmiştir ");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            var bulunanid = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(bulunanid);
            db.SaveChanges();
            MessageBox.Show("Kategori Silinmiştir ");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            var bulunanid = db.TBLKATEGORI.Find(id);
            bulunanid.AD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori Güncellenmiştir ");
        }
    }
}
