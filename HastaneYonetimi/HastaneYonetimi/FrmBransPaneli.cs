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
    public partial class FrmBransPaneli : Form
    {
        public FrmBransPaneli()
        {
            InitializeComponent();
        }

        SqlBaglantisi1 bgl = new SqlBaglantisi1();


        private void FrmBransPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.Connection());
            da.Fill(dt);
            dataGridView1.DataSource= dt;   
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@p1)", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", txtsoyad.Text);
            komut.ExecuteNonQuery();
            bgl.Connection().Close();
            MessageBox.Show("Branş Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Tbl_Branslar where Bransid=@p1", bgl.Connection());
            komut.Parameters.AddWithValue("@p1",txtad.Text);
            komut.ExecuteNonQuery();
            bgl.Connection().Close();
            MessageBox.Show("Branş Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Branslar set BransAd=@p1 where Bransid=@p2 ", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.ExecuteNonQuery();
            bgl.Connection().Close();
            MessageBox.Show("Branş Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int current = dataGridView1.SelectedCells[0].RowIndex;

            txtad.Text = dataGridView1.Rows[current].Cells[0].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[current].Cells[1].Value.ToString();
        }
    }
}
