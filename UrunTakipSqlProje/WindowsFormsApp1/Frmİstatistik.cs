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

namespace WindowsFormsApp1
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Urunler1.mdf;Integrated Security=True");


        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Kategori Sayısı 
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) from Kategori", baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                LblToplamkategori.Text = dr[0].ToString();
            }
            baglanti.Close();


            // Toplam urun sayısı 
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) from Urunler", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblUrun.Text = dr2[0].ToString();
            }
            baglanti.Close();


            // Toplam satış tutarı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select sum(SatışFiyat) from Urunler", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                label5.Text = dr3[0].ToString();
            }
            baglanti.Close();

            // Toplam alış tutarı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select sum(AlışFiyat) from Urunler", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                label7.Text = dr4[0].ToString();
            }
            baglanti.Close();

            // Toplam stok sayısı
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select count(Stok) from Urunler", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                label9.Text = dr5[0].ToString();
            }
            baglanti.Close();









        }
    }
}
