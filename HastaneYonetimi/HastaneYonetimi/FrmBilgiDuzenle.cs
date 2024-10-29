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
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantisi1 bgl = new SqlBaglantisi1();

        public string TC;

        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = TC;
            SqlCommand command = new SqlCommand("Select * From Tbl_Hastalar where HastaTC=@p1", bgl.Connection());
            command.Parameters.AddWithValue("@p1", msktc.Text);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                txtad.Text = reader[1].ToString();
                txtsoyad.Text = reader[2].ToString();
                msktc.Text = reader[3].ToString();
                msktel.Text = reader[4].ToString();
                sifretxt.Text = reader[5].ToString();
                cmbcinsiyet.Text = reader[6].ToString();
            }

            bgl.Connection().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("update Tbl_Hastalar set Hasta_Ad=@p1, HastaSoyad=@p2, HastaTelefon=@p3, HastaSifre=@p4, HastaCinsiyet=@p5 where HastaTC=@P6",bgl.Connection());
            command.Parameters.AddWithValue("@p1", txtad.Text);
            command.Parameters.AddWithValue("@p2", txtsoyad.Text);
            command.Parameters.AddWithValue("@p3", msktel.Text);
            command.Parameters.AddWithValue("@p4", sifretxt.Text);
            command.Parameters.AddWithValue("@p5", cmbcinsiyet.Text);
            command.Parameters.AddWithValue("@p6", msktc.Text);
            command.ExecuteNonQuery();
            bgl.Connection().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
