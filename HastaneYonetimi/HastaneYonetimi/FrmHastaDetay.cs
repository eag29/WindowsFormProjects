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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        public string TC;

        SqlBaglantisi1 bgl = new SqlBaglantisi1();

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = TC;

            SqlCommand komut = new SqlCommand("Select Hasta_Ad,HastaSoyad From Tbl_Hastalar Where HastaTC=@p1", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.Connection().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where HastaTC=" + TC, bgl.Connection());
            da.Fill(dt);
            dgwRandevuGeçmişi.DataSource = dt;

            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.Connection());
            SqlDataReader dr1 = komut2.ExecuteReader();
            while (dr1.Read())
            {
                cmb_brans.Items.Add(dr1[0]);
            }
            bgl.Connection().Close();
        }

        private void cmb_brans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", cmb_brans.Text);
            SqlDataReader dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                cmbDoktor.Items.Add(dr2[0] + " " + dr2[1]);
            }
            bgl.Connection().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular Where RandevuBrans='" + cmb_brans.Text + "'" + " and RandevuDoktor='" + cmbDoktor.Text + "' and RandevuDurum=0", bgl.Connection());
            da.Fill(dt);
            dgwAkifRandevular.DataSource = dt;
        }

        private void lnkDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fbd = new FrmBilgiDuzenle();
            fbd.TC = lbltc.Text;
            fbd.Show();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Randevular Set RandevuDurum=1, Where HastaTC=@p1,HastaSikayet=@p2 where Randevu_id=@p3", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            komut.Parameters.AddWithValue("@p2", rchRandevu.Text);
            komut.Parameters.AddWithValue("@p3", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.Connection().Close();
            MessageBox.Show("Randevu Alınmıştır", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgwAkifRandevular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int current = dgwAkifRandevular.SelectedCells[0].RowIndex;
            txtid.Text = dgwAkifRandevular.Rows[current].Cells[0].Value.ToString();
        }
    }
}
