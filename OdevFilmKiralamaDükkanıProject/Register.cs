using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OdevFilmKiralamaDükkanıProject
{


    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        class KisiAdmin
        {
            public string Ad { get; set; }
            public string password { get; set; }

            public KisiAdmin(string ad, string password)
            {
                this.Ad = ad;
                this.password = password;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string path = @"D:\1Fırat Üni Ders Notlarım\2.Sınıf Bahar Dönemi\NTP\FilmDükkanıÖdevi\AdminBilgileri.txt";

            KisiAdmin metin = new KisiAdmin(textBoxUserName.Text, textBoxPassword.Text);
            string kisiler = $"{metin.Ad},{metin.password}";

            try
            {
                using (StreamWriter yazici = new StreamWriter(path, true))
                {
                    yazici.WriteLine(kisiler);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Başarıyla kayıt yaptınız");



        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}

