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
    public partial class FrmGrafikler2 : Form
    {
        public FrmGrafikler2()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        private void FrmGrafikler2_Load(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand komut = new SqlCommand("Select PerSehir, Count(*) From Tbl_Personel Group By PerSehir", connect);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            connect.Close();

            connect.Open();
            SqlCommand komut2 = new SqlCommand("Select PerMeslek, Avg(PerMaas) From Tbl_Personel Group By PerMeslek", connect);
            SqlDataReader dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            connect.Close();
        }
    }
}
