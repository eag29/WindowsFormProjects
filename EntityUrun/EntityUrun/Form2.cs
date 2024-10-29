using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityUrun
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            FrmKategori fk = new FrmKategori();
            fk.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmUrun fu = new FrmUrun();
            fu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmIstatıstık fi = new FrmIstatıstık();
            fi.Show();
            this.Hide();
        }
    }
}
