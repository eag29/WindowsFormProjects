using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneYonetimi
{
    public partial class FrmDoktorGiriscs : Form
    {
        public FrmDoktorGiriscs()
        {
            InitializeComponent();
        }

        SqlBaglantisi1 bgl = new SqlBaglantisi1();

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2", bgl.Connection());
            komut.Parameters.AddWithValue("@p1", tcmsk.Text);
            komut.Parameters.AddWithValue("@p2", sifretxt.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay fdd = new FrmDoktorDetay();
                fdd.TC = tcmsk.Text;
                fdd.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı adı veya şifre");
            }
            bgl.Connection().Close();
        }
    }
}
