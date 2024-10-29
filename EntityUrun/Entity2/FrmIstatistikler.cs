using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity2
{
    public partial class FrmIstatistikler : Form
    {
        public FrmIstatistikler()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void FrmIstatistikler_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLKATEGORI.Count().ToString();
            label3.Text = db.TBLURUN.Count().ToString();
            label5.Text = db.TBLMUSTERI.Count(x => x.DURUM == true).ToString();
            label7.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            label15.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString();
            label13.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
            label11.Text = db.TBLURUN.Max(x => x.FIYAT).ToString();
            label9.Text = db.TBLURUN.Min(x => x.FIYAT).ToString();
            label23.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();
            label21.Text = db.TBLURUN.Sum(x => x.FIYAT).ToString();
            label19.Text = db.MARKAGETIR().FirstOrDefault();
            label17.Text = db.TBLURUN.Count(x => x.URUNAD == "BUZDOLABI").ToString();
        }
    }
}
