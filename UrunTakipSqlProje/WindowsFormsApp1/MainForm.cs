using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void urunİslemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUrun frmUrun = new FrmUrun();
            frmUrun.ShowDialog();
        }

        private void kategoriİslemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKategori frmKategori = new FrmKategori();
            frmKategori.ShowDialog();

        }

        private void istatistiklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmİstatistik frmİstatistik = new Frmİstatistik();
            frmİstatistik.ShowDialog();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu uygulama Selim Çınar tarafından yapılmıştır.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
