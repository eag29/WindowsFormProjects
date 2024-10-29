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
    public partial class FrmSekreterDetay2 : Form
    {
        public FrmSekreterDetay2()
        {
            InitializeComponent();
        }

        SqlBaglantisi1 bgl = new SqlBaglantisi1();

        public string TC;

        private void FrmSekreterDetay2_Load(object sender, EventArgs e)
        {
            lblTC.Text = TC;

            SqlCommand cmd = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreterler where SekreterTC=@p1", bgl.Connection());
            cmd.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0].ToString();
            }
            bgl.Connection().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar", bgl.Connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) as 'Doktorlar' ,DoktorBrans From Tbl_Doktorlar", bgl.Connection());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            SqlCommand komut = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.Connection());
            SqlDataReader dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.Connection().Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Randevular (RandevuTarih, RandevuSaat, RandevuBrans, RandevuDoktor) values (@p1,@p2,@p3,@p4)", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", msktarih.Text);
            komut.Parameters.AddWithValue("@p2", msksaat.Text);
            komut.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", cmbDoktor.Text);
            komut.ExecuteNonQuery();
            bgl.Connection().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.Connection().Close();
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand ko = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@d1)", bgl.Connection());
            ko.Parameters.AddWithValue("@d1", richTextBox1.Text);
            ko.ExecuteNonQuery();
            bgl.Connection().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void btnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli fdp = new FrmDoktorPaneli();
            fdp.Show();
        }

        private void btnBransPaneli_Click(object sender, EventArgs e)
        {
            FrmBransPaneli fbp = new FrmBransPaneli();
            fbp.Show();
        }
        private void btnRandevuListesi_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi fdl = new FrmRandevuListesi();
            fdl.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete * from Tbl_Randevular where Randevu_id=@p1", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", idtxt.Text);
            komut.ExecuteNonQuery();
            bgl.Connection().Close();
            MessageBox.Show("Randevu silinmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular2 fd = new FrmDuyurular2();
            fd.Show();
        }
    }
}
