using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbUrunDataSet.TblKategori' table. You can move, or remove it, as needed.


        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Urunler1.mdf;Integrated Security=True");



        private void Btn_Listele_Click(object sender, EventArgs e)
        {
            //Listeleme
            SqlCommand komut = new SqlCommand("Select * from Kategori", baglanti); //sql komutu yazılırı

            
            SqlDataAdapter da = new SqlDataAdapter(komut); //adapter baglantısı 


            DataTable dt = new DataTable();  // tablo eklendi
    

            da.Fill(dt);      // adaptör ile tablo içi dolduruldu
      

            dataGridView1.DataSource = dt; // data gridview1 kaynağına tablo eklendi
 
            

            /*Bağlantı açıp kapatmaya gerek yok listeleme işleminde  */

        }

        private void Btn_Kaydet_Click(object sender, EventArgs e)
        {   //Kaydetme

            try
            {
                if (Text_KategoriAd.Text != "" && Text_KategoriAd.Text != String.Empty)
                {

                    baglanti.Open();  // baglantı açıldı 

                    SqlCommand komut = new SqlCommand("insert into  Kategori (KategoriAdı) values (@p1)", baglanti); // sql komutu çalıştırıldı

                    komut.Parameters.AddWithValue("@p1", Text_KategoriAd.Text);  // dışardan gelen değer eklendi


                    komut.ExecuteNonQuery(); // komutları uygula 

                    baglanti.Close();

                    MessageBox.Show("Kategoriniz başarılı bir şekilde eklendi.");
                }
                else
                {
                    MessageBox.Show("Hatalı işlem", "Hatalı işlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            finally {  }


        }

        private void Btn_Sil_Click(object sender , EventArgs  e)
        {
           //id'ye göre siler
            baglanti.Open();

            SqlCommand komut = new SqlCommand("delete from Kategori where Kategoriid=@p1 ",baglanti);
            
            komut.Parameters.AddWithValue("@p1",Text_Kategoriid.Text);
            
            komut.ExecuteNonQuery();
            
            baglanti.Close();
            
            MessageBox.Show("Hatalı işlem", "Hatalı işlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
            /*İlişkili tablolarda silme işlemi hata verir.*/
        
        }

        private void Btn_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if(Text_KategoriAd.Text != "" && Text_KategoriAd.Text!= String.Empty)
                {
                    // Güncelleme işlemi 
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand("update Kategori set KategoriAdı=@p1 where Kategoriid =@p2", baglanti);

                    komut.Parameters.AddWithValue("@p1", Text_KategoriAd.Text);

                    komut.Parameters.AddWithValue("@p2", Text_Kategoriid.Text);

                    komut.ExecuteNonQuery();

                    baglanti.Close();

                    MessageBox.Show("Kategori güncelleme işlemi başarılı bir şekilde gerçekleşti","Güncelleme işlemi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hatalı işlem", "Silme işlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              

            }
            finally
            {
               
            }




        }

        private void Tbl_Ara_Click(object sender, EventArgs e)
        {
            // ara işlemi 
            SqlCommand komut = new SqlCommand("Select * from Kategori where KategoriAdı=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", Text_KategoriAd.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;

        }
        // Crud --> Create Read(Search arama) Update Delete 

    }
}