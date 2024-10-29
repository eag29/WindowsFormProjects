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
    public partial class FrmSekreterGiris2 : Form
    {
        public FrmSekreterGiris2()
        {
            InitializeComponent();
        }

        SqlBaglantisi1 bgl = new SqlBaglantisi1();

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Select * From Tbl_Sekreterler where SekreterTC=@p1 and SekreterSifre=@p2", bgl.Connection());
            sqlCommand.Parameters.AddWithValue("@p1", tcmsk.Text);
            sqlCommand.Parameters.AddWithValue("@p2", sifretxt.Text);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay2 fsd = new FrmSekreterDetay2();
                fsd.TC = tcmsk.Text;
                fsd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Girişi");
            }
            bgl.Connection().Close();
        }
    }
}
