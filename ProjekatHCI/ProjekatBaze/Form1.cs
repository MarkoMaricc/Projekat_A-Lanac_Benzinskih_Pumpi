using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatBaze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var currCulture = Thread.CurrentThread.CurrentCulture;
            string culture;
           
                culture = "sr";
            
          

            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            Controls.Clear();

            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PrikazRadnika pr=new PrikazRadnika();
            pr.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PrikazAparataZaGorivo pr = new PrikazAparataZaGorivo();
            pr.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PrikazBenzinske pr=new PrikazBenzinske();
            pr.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PrikazKase pr = new PrikazKase();
            pr.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PrikazSkladista pr = new PrikazSkladista();
            pr.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PrikazR pr = new PrikazR();
            pr.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PrikazP pr = new PrikazP();
            pr.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var currCulture = Thread.CurrentThread.CurrentCulture;
            string culture;
            if (currCulture.Name == "en")
            {
                culture = "sr";
            }
            else
            {
                culture = "en";
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            Controls.Clear();
            InitializeComponent();
        }
    }
}
