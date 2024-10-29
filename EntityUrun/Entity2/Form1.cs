using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity2
{
    public partial class FrmAnaPanel : Form
    {
        public FrmAnaPanel()
        {
            InitializeComponent();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            FrmKategori fk = new FrmKategori();
            fk.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmUrun fu = new FrmUrun();
            fu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmIstatistikler fi = new FrmIstatistikler();
            fi.Show();
        }
    }
}
