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
    public partial class FrmDoktorBilgiDuzenle2 : Form
    {
        public FrmDoktorBilgiDuzenle2()
        {
            InitializeComponent();
        }

        SqlBaglantisi1 bgl = new SqlBaglantisi1();

        public string TC;
        private void FrmDoktorBilgiDuzenle2_Load(object sender, EventArgs e)
        {
            msktc.Text = TC;

            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC=@p1", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                cmb_brans.Text = dr[3].ToString();
                sifretxt.Text = dr[4].ToString();
            }
            bgl.Connection().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1, DoktorSoyad=@p2, DoktorBrans=@p3, DoktorSifre=@p3 where DoktorTC=@p4", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmb_brans.Text);
            komut.Parameters.AddWithValue("@p4", sifretxt.Text);
            komut.ExecuteNonQuery();
            bgl.Connection().Close();
            MessageBox.Show("Veri Güncellenmiştir. ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
