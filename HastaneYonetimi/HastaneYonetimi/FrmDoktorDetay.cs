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

namespace HastaneYonetimi
{
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        SqlBaglantisi1 bgl = new SqlBaglantisi1();

        public string TC;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = TC;

            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTC=@P1", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.Connection().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuDoktor='" + lblAdSoyad.Text + "'", bgl.Connection());
            da.Fill(dt);
            dgwRandevuListesi.DataSource = dt;
        }

        private void btnBilgi_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle2 fdbd = new FrmDoktorBilgiDuzenle2();
            fdbd.TC = lblTC.Text;
            fdbd.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular2 fd = new FrmDuyurular2();
            fd.Show();
        }

        private void dgwRandevuListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgwRandevuListesi.SelectedCells[0].RowIndex;

            rchRandevu.Text = dgwRandevuListesi.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
