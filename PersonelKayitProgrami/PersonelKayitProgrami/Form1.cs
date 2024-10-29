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

namespace PersonelKayitProgrami
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        void Clear()
        {
            idtxt.Text = " ";
            adtxt.Text = " ";
            soyadtxt.Text = " ";
            sehirtxt.Text = " ";
            maastxt.Text = " ";
            sehirtxt.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            adtxt.Focus();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            connect.Open();

            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerDurum,PerMeslek) values (@p1,@p2,@p3,@p4,@p5,@p6)", connect);
            komut.Parameters.AddWithValue("@p1", adtxt.Text);
            komut.Parameters.AddWithValue("@p2", soyadtxt.Text);
            komut.Parameters.AddWithValue("@p3", sehirtxt.Text);
            komut.Parameters.AddWithValue("@p4", maastxt.Text);
            komut.Parameters.AddWithValue("@p5", label8.Text);
            komut.Parameters.AddWithValue("@p6", meslektxt.Text);
            komut.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Personeller Kaydedildi");
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            connect.Open();

            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Personel Where Perid=@k1", connect);
            komutsil.Parameters.AddWithValue("@k1", idtxt.Text);
            komutsil.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Kayıtlar silindi");
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Clear();
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
            meslektxt.Text = dataGridView1.Rows[current].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            connect.Open();

            SqlCommand komutGuncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1, PerSoyad=@a2, PerSehir=@a3, PerMaas=@a4, PerDurum=@a5, PerMeslek=@a6 where Perid", connect);
            komutGuncelle.Parameters.AddWithValue("@a1", adtxt.Text);
            komutGuncelle.Parameters.AddWithValue("@a2", soyadtxt.Text);
            komutGuncelle.Parameters.AddWithValue("@a3", sehirtxt.Text);
            komutGuncelle.Parameters.AddWithValue("@a4", maastxt.Text);
            komutGuncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutGuncelle.Parameters.AddWithValue("@a6", meslektxt.Text);
            komutGuncelle.Parameters.AddWithValue("@a7", idtxt.Text);
            komutGuncelle.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Veriler Güncellendi");
        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            Frmİstatistik frmİstatistik = new Frmİstatistik();
            frmİstatistik.Show();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler2 frmGrafikler = new FrmGrafikler2();
            frmGrafikler.Show();
        }
    }
}
