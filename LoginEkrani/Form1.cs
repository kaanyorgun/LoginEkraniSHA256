using Microsoft.Azure.Amqp.Framing;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace LoginEkrani
{
    public partial class Login : Form
    {

        SqlConnection baglanti = new SqlConnection(@"Data Source = DESKTOP - C6BJILK\SQLEXPRESS; Integrated Security = True");
        public Login()
        {
            InitializeComponent();
            textBoxSifre.PasswordChar = '*';

        }

        private string sha256KoduOlustur(string s)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }



        private void buttonKaydol_Click(object sender, EventArgs e)
        {
            {
                if (textBoxKullaniciAdi.Text.ToString().Length == 0
                   || textBoxSifre.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Alanlar boş bırakılamaz!");
                    return;
                }
            }
            string sorgu = "SELECT KullaniciAdi FROM Kullanici WHERE KullaniciAdi = @P1";
            try
            {
                baglanti.Open();
                SqlCommand sqlCommand = new SqlCommand(sorgu, baglanti);
                sqlCommand.Parameters.AddWithValue("@P1", textBoxKullaniciAdi.Text);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                bool yeniKullaniciEkle = false;

                if (reader.HasRows)
                {
                    MessageBox.Show(textBoxKullaniciAdi.Text + " isminde bir kullanıcı zaten mevcut");
                }
                else
                {
                    // Veritabanına yeni kullanıcıyı ekleme
                    yeniKullaniciEkle = true;

                }
                reader.Close();

                if (yeniKullaniciEkle)
                {
                    sqlCommand = new SqlCommand("INSERT INTO Kullanici (@P1,@P2)", baglanti);
                    sqlCommand.Parameters.AddWithValue("@P1", textBoxKullaniciAdi.Text);
                    sqlCommand.Parameters.AddWithValue("@P2", sha256KoduOlustur(textBoxSifre.Text));
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("VT Bağlantisinda Hata Oluştu Hata Kodu: H001/n" + Ex.Message);
            }
            finally
            {
                if (baglanti != null)
                    baglanti.Close();
            }
        }

        private void buttonGiris_Click(object sender, EventArgs e)
        {
            if (textBoxKullaniciAdi.Text.ToString().Length == 0
               || textBoxSifre.Text.ToString().Length == 0)
            {
                MessageBox.Show("Alanlar boş bırakılamaz!");
                return;
            }
            try
            {
                baglanti.Open();
                string sorgu = "SELECT KullaniciAdi, Sifre FROM Kullanici WHERE KullaniciAdi = @P1"+
                    "AND Sifre =@P2";
                SqlCommand sqlCommand = new SqlCommand(sorgu, baglanti);
                sqlCommand.Parameters.AddWithValue("@P1", textBoxKullaniciAdi.Text);
                sqlCommand.Parameters.AddWithValue("@P2", sha256KoduOlustur(textBoxSifre.Text));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    MessageBox.Show("Kullanıcı adı ve şifre doğru sisteme Hoş Geldiniz");
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("VT Bağlantisinda Hata Oluştu Hata Kodu: H002/n" + Ex.Message);
            }
        
            finally
            {
                if (baglanti != null)
                    baglanti.Close();
            }
        }
    }
}