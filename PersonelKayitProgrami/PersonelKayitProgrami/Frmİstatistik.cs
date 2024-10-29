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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) from Tbl_Personel", connect);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbltoplamPersonel.Text = dr1[0].ToString();
            }
            connect.Close();

            connect.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) from Tbl_Personel where PerDurum=1", connect);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevliPersonel.Text = dr2[0].ToString();
            }
            connect.Close();

            connect.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) from Tbl_Personel where PerDurum=0", connect);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblbekarPersonel.Text = dr3[0].ToString();
            }
            connect.Close();

            connect.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(PerSehir)) from Tbl_Personel", connect);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblsehir.Text = dr4[0].ToString();
            }
            connect.Close();

            connect.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) from Tbl_Personel ", connect);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamMaas.Text = dr5[0].ToString();
            }
            connect.Close();


            connect.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) from Tbl_Personel ", connect);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtalamaMaas.Text = dr6[0].ToString();
            }
            connect.Close();
        }
    }
}
