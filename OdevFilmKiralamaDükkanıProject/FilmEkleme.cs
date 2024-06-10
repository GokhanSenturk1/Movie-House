using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace OdevFilmKiralamaDükkanıProject
{
    public partial class FilmEkleme : Form
    {
        public FilmEkleme()
        {
            InitializeComponent();
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
        private void buttonFilmKayıt_Click(object sender, EventArgs e)
        {
            string path = @"D:\1Fırat Üni Ders Notlarım\2.Sınıf Bahar Dönemi\NTP\FilmDükkanıÖdevi\Filmler.txt";
            Film filmler = new Film(textBoxFilmAdi.Text,textBoxFilmTürü.Text,textBoxFilmSüresi.Text,textBoxIMDB.Text);
            string Filmler = $"{filmler.Ad},{filmler.Tür},{filmler.Süresi},{filmler.IMDB}";
            try
            {
                using (StreamWriter yazici = new StreamWriter(path, true))
                {
                    yazici.WriteLine(Filmler);
                }
                MessageBox.Show("Başarıyla kayıt yaptınız");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            AnaForm f =new AnaForm();
            f.Show();
            this.Hide();
        }


        private void FilmEkleme_Load(object sender, EventArgs e)
        {

            string dosyayolu = @"D:\1Fırat Üni Ders Notlarım\2.Sınıf Bahar Dönemi\NTP\FilmDükkanıÖdevi\Filmler.txt";
            try
            {
                StreamReader okuyucu = new StreamReader(dosyayolu);
                string satir;

                while ((satir = okuyucu.ReadLine()) != null)
                {
                    string[] veriDizisi = satir.Split(',');

                    dataGridView1.Rows.Add(veriDizisi);
                }

                okuyucu.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya yüklenemedi: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FilmEkleme ff=new FilmEkleme();
            ff.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 ff=new Form1();
            ff.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value is bool && (bool)row.Cells[4].Value)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }

        }
    }
    }
  
