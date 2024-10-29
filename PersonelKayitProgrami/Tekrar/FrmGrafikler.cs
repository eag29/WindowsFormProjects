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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select PerSehir Count(*) from Tbl_Personel Group By PerSehir");
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Şehirler"].Points.AddXY(dr[0], dr[1]);
            }
            connection.Close();

            connection.Open();
            SqlCommand komut1 = new SqlCommand("Select PerMeslek Avg(PerMaaş) from Tbl_Personel Group By PerMeslek");
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Meslek-Maaş"].Points.AddXY(dr1[0], dr1[1]);
            }
            connection.Close();
        }
    }
}
