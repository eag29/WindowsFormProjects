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
    public partial class FrmStatistik : Form
    {
        public FrmStatistik()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        private void FrmStatistik_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Count(*) from Tbl_Personel", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbltoplamPersonel.Text = dr[0].ToString();
            }
            connection.Close();

            connection.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) from Tbl_Personel where PerDurum=1", connection);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblevliPersonel.Text = dr1[0].ToString();
            }
            connection.Close();

            connection.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) from Tbl_Personel where PerDurum=0", connection);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblbekarPersonel.Text = dr2[0].ToString();
            }
            connection.Close();

            connection.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(distinct(PerSehir)) from Tbl_Personel", connection);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblsehir.Text = dr3[0].ToString();
            }
            connection.Close();

            connection.Open();
            SqlCommand komut4 = new SqlCommand("Select Sum(PerMaas) from Tbl_Personel", connection);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblToplamMaas.Text = dr4[0].ToString();
            }
            connection.Close();

            connection.Open();
            SqlCommand komut5 = new SqlCommand("Select Avg(PerMaas) from Tbl_Personel", connection);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblOrtalamaMaas.Text = dr5[0].ToString();
            }
            connection.Close();
        }
    }
}
