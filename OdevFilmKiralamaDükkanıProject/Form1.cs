using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdevFilmKiralamaDükkanıProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AnaForm form = new AnaForm();
            form.Show();
            this.Hide();
        }

       

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FilmEkleme ff= new FilmEkleme();    
            ff.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
