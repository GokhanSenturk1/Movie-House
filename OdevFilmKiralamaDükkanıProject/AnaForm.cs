using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OdevFilmKiralamaDükkanıProject
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }
        class kisi
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Telefon { get; set; }
            public string FilmAdı { get; set; }
            public string GünSayısı { get; set; }


            public kisi(string ad, string soyad, string telefon, string FilmAdı, string GünSayısı)
            {
                this.Ad = ad;
                this.Soyad = soyad;
                this.Telefon = telefon;
                this.FilmAdı = FilmAdı;
                this.GünSayısı = GünSayısı;
            }
            public class Film
            {
                public string Ad { get; set; }
                public string Tür { get; set; }
                public string Süresi { get; set; }
                public string IMDB { get; set; }

                
                public Film(string ad, string tür, string sure, string ımdb)
                {
                    this.Ad = ad;
                    this.Tür = tür;
                    this.Süresi = sure;
                    this.IMDB = ımdb;
                }
            }
            public class FilmDükkanı
            {
                public kisi Kişi { get; set; }
                public Film filmler { get; set; }

                public FilmDükkanı(kisi kisi, Film filmler)
                {
                    this.Kişi = kisi;
                    this.filmler = filmler;
                }
            }
            public class KiralananFilmler
            {
                public kisi ücret { get; set; }
                public Film film { get; set; }
                public FilmDükkanı kisi { get; set; }

                public KiralananFilmler(kisi filmtutarı, Film filmadi, FilmDükkanı kiralayankisi)
                {
                    this.ücret = filmtutarı;
                    this.film = filmadi;
                    this.kisi = kiralayankisi;
                }
            }   

        }

        ////********************************************************

        private void Form1_Load(object sender, EventArgs e)
        {
            //Bu filmler için

            string dosyaYolu = @"D:\1Fırat Üni Ders Notlarım\2.Sınıf Bahar Dönemi\NTP\FilmDükkanıÖdevi\Filmler.txt";
            using (StreamReader dosya = new StreamReader(dosyaYolu, true))
            {
              
                string satir;
                while ((satir = dosya.ReadLine()) != null)
                {
                    string[] bilgiler = satir.Split(',');

                    DataGridViewRow yeniSatir = new DataGridViewRow();

                    for (int i = 0; i < bilgiler.Length; i++)
                    {
                        yeniSatir.Cells.Add(new DataGridViewTextBoxCell());
                        yeniSatir.Cells[i].Value = bilgiler[i];
                    }

                    dataGridView1.Rows.Add(yeniSatir);
                }
            }
            // Bu kiralayan kayıt için
            string dosyayolu = @"D:\1Fırat Üni Ders Notlarım\2.Sınıf Bahar Dönemi\NTP\FilmDükkanıÖdevi\KiralayanBilgileri.txt";

            using (StreamReader okuyucu = new StreamReader(dosyayolu, true))
            {
                string satir;
                while ((satir = okuyucu.ReadLine()) != null)
                {
                    string[] bilgiler = satir.Split(',');

                    DataGridViewRow yeniSatir = new DataGridViewRow();

                    for (int i = 0; i < bilgiler.Length; i++)
                    {
                        yeniSatir.Cells.Add(new DataGridViewTextBoxCell());
                        yeniSatir.Cells[i].Value = bilgiler[i];
                    }

                    dataGridView2.Rows.Add(yeniSatir);
                    dataGridView2.Show();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string path = @"D:\1Fırat Üni Ders Notlarım\2.Sınıf Bahar Dönemi\NTP\FilmDükkanıÖdevi\KiralayanBilgileri.txt";

            kisi metin = new kisi(textBoxad.Text, textBoxSoyad.Text, maskedTextBox1.Text, textBoxFilmAdı.Text, maskedTextBox2.Text);
            string kisiler = $"{metin.Ad},{metin.Soyad},{metin.Telefon},{metin.FilmAdı},{metin.GünSayısı}";

            try
            {
                using (StreamWriter yazici = new StreamWriter(path, true))
                {
                    yazici.WriteLine(kisiler);
                }
                MessageBox.Show("Başarıyla kayıt yaptınız");
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        public void buttonYenile_Click(object sender, EventArgs e)
        {
            AnaForm af=new AnaForm();
            af.Show();
            this.Hide();
        }

       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 ff = new Form1();
            ff.Show();
            this.Hide();
        }

        private void buttonHesapla_Click(object sender, EventArgs e)
        {
            if (textBoxGünSayısı.Text !=null && textBoxGünSayısı.Text !="" && textBoxGünSayısı.Text !="0" && textBoxGünSayısı.Text != " ")
            {
                double hesapla;
                double günsayisi = Convert.ToDouble(textBoxGünSayısı.Text);
                hesapla = günsayisi * 50;
                labelUcret.Text = hesapla.ToString() + " TL";
            }
            else
            {
                labelUcret.Text = "Hatalı değer girdiniz";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Finish ff= new Finish();
            ff.Show();
            this.Hide();
        }
    }
}
