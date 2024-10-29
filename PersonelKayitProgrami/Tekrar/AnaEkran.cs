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

namespace Tekrar
{
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerDurum,PerMeslek) values (@p1,@p2,@p3,@p4,@p5,@p6)", connection);
            cmd.Parameters.AddWithValue("@p1", adtxt.Text);
            cmd.Parameters.AddWithValue("@p2", soyadtxt.Text);
            cmd.Parameters.AddWithValue("@p3", sehirtxt.Text);
            cmd.Parameters.AddWithValue("@p4", maastxt.Text);
            cmd.Parameters.AddWithValue("@p5", label8.Text);
            cmd.Parameters.AddWithValue("@p6", meslektxt.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıtlar Kaydedildi");
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand komut2 = new SqlCommand("Delete * from Tbl Personel Where Perid=@k1", connection);
            komut2.Parameters.AddWithValue("@k1", idtxt.Text);
            komut2.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıtlar Silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut3 = new SqlCommand("Update Tbl_Personel set @d1=PerAd, @d2=PerSoyad, @d3=PerSehir, @d4=PerMaas, @d5=PerDurum, @d6=PerMeslek where Perid ", connection);
            komut3.Parameters.AddWithValue("@d1", adtxt.Text);
            komut3.Parameters.AddWithValue("@d2", soyadtxt.Text);
            komut3.Parameters.AddWithValue("@d3", sehirtxt.Text);
            komut3.Parameters.AddWithValue("@d4", maastxt.Text);
            komut3.Parameters.AddWithValue("@d5", label8.Text);
            komut3.Parameters.AddWithValue("@d6", meslektxt.Text);
            komut3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıtlar Güncellendi");
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            idtxt.Text = " ";
            adtxt.Text = " ";
            soyadtxt.Text = " ";
            soyadtxt.Text = " ";
            sehirtxt.Text = " ";
            maastxt.Text = " ";
            radioButton1.Text = " ";
            radioButton2.Text = " ";
            meslektxt.Text = " ";

            adtxt.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int current = dataGridView1.SelectedCells[0].RowIndex;

            idtxt.Text = dataGridView1.Rows[current].Cells[0].Value.ToString();
            adtxt.Text = dataGridView1.Rows[current].Cells[1].Value.ToString();
            soyadtxt.Text = dataGridView1.Rows[current].Cells[2].Value.ToString();
            sehirtxt.Text = dataGridView1.Rows[current].Cells[3].Value.ToString();
            maastxt.Text = dataGridView1.Rows[current].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[current].Cells[5].Value.ToString();
            maastxt.Text = dataGridView1.Rows[current].Cells[6].Value.ToString();
        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            FrmStatistik fs = new FrmStatistik();
            fs.Show();
            this.Hide();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler fg = new FrmGrafikler();
            fg.Show();
            this.Hide();
        }
    }
}
