using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatBaze
{
    public partial class DodajBenzinske : Form
    {
        PrikazBenzinske otac;
        public string id, Adresa, Grad, Drzava, Telefon, email, BrojParkingMjesta, Naziv;

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim().Length < 1 || textBox2.Text.Trim().Length < 3 || textBox3.Text.Trim().Length < 3
                || textBox4.Text.Trim().Length < 3 || textBox5.Text.Trim().Length < 9 || textBox6.Text.Trim().Length < 6
                || textBox7.Text.Trim().Length < 1 || textBox8.Text.Trim().Length < 3 )
            {

                var currCulture = Thread.CurrentThread.CurrentCulture;
                if (currCulture.Name == "en")
                {
                    MessageBox.Show("You have not filled in all the fields correctly.");
                    return;
                }
                else
                {
                    MessageBox.Show("Niste ispravno popunili sva polja.");
                    return;
                }
            }


            if (button2.Text == "izmjeni" || button2.Text == "update")
            {
                BenzinskeStanice apg = new BenzinskeStanice(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim(), textBox7.Text.Trim(), textBox8.Text.Trim());
                ObradaBenzinske.izmjenaBenzinske(apg, id);
                ocisti();
            }

            if (button2.Text == "dodaj" || button2.Text == "add")
            {
                BenzinskeStanice apg = new BenzinskeStanice(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim(), textBox7.Text.Trim(), textBox8.Text.Trim());
                ObradaBenzinske.dodajBenzinske(apg);
                ocisti();
            }
            this.Close();
            otac.Display();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            ocisti();
                this.Close();
            

        }

        public DodajBenzinske(PrikazBenzinske pOtac)
        {
            InitializeComponent();
            otac = pOtac;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        public void ocisti()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
            textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = string.Empty;
            id = null;

        }

        public void IzmjenaInfo()
        {


            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "replacement of the petrol pump";
                button2.Text = "update";
            }
            else
            {
                label1.Text = "izmjena benzinske pumpe";
                button2.Text = "izmjeni";
            }
            textBox1.Text = id;
            textBox2.Text = Adresa;
            textBox3.Text = Grad;
            textBox4.Text = Drzava;
            textBox5.Text = Telefon;
            textBox6.Text = email;
            textBox7.Text = BrojParkingMjesta;
            textBox8.Text = Naziv;


        }

        public void DodavanjeInfo()
        {
            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "adding a gas station";
                button2.Text = "add";
            }
            else
            {

                label1.Text = "dodavanje benzinske pumpe";
                button2.Text = "dodaj";
            }
        }
    }
}
