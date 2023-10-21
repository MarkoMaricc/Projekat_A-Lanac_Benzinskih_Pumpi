using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatBaze
{
    public partial class DodajRadnika : Form
    {
        private PrikazRadnika otac;
        public String id, jmbg, Prezime, Ime, Uloga, Plata, PutniTroskovi, BrojLicneKarte, DatumRodjenja, idStanice;

       

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim().Length < 1 || textBox2.Text.Trim().Length < 13 || textBox3.Text.Trim().Length < 3
               || textBox4.Text.Trim().Length < 3 || textBox5.Text.Trim().Length < 3 || textBox6.Text.Trim().Length < 1
               || textBox7.Text.Trim().Length < 1 || textBox8.Text.Trim().Length < 7 || textBox9.Text.Trim().Length < 1 || comboBox1.SelectedValue == null)
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


            if (button1.Text == "izmjeni" || button1.Text == "update")
            {
                Radnik ra = new Radnik(textBox1.Text.Trim(), textBox2.Text.Trim(),
                    textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim()
                    , textBox6.Text.Trim(), textBox7.Text.Trim(), textBox8.Text.Trim(), textBox9.Text.Trim(), comboBox1.SelectedValue.ToString());
                ObradaRadnika.izmjenaRadnika(ra, id);
                ocisti();
            }

            if (button1.Text == "dodaj" || button1.Text == "add")
            {
                Radnik ra = new Radnik(textBox1.Text.Trim(), textBox2.Text.Trim(),
                    textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim()
                    , textBox6.Text.Trim(), textBox7.Text.Trim(), textBox8.Text.Trim(), textBox9.Text.Trim(), comboBox1.SelectedValue.ToString());
                ObradaRadnika.dodavanjeRadnika(ra);
                ocisti();
            }
            this.Close();
            otac.Display();
        }

        private void DodajRadnika_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM `benzinska_pumpa`.`benzinske_stanice`";
            DataTable dataTable = GetData(sql);

            comboBox1.DisplayMember = dataTable.Columns[7].ToString();
            comboBox1.ValueMember = dataTable.Columns[0].ToString();


            comboBox1.DataSource = dataTable;
            if (id != null)
            {
                comboBox1.SelectedValue = idStanice;
            }
            else
                comboBox1.SelectedValue = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ocisti();
            this.Close();
        }

        public DodajRadnika(PrikazRadnika pOtac)
        {
            InitializeComponent();
            otac = pOtac;
        }
        public DataTable GetData(string sqla)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["benzinska_pumpa"].ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sqla, connection))
                {
                    DataTable dataTable = new DataTable();
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(command);
                    sqlDataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void ocisti()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
            textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = string.Empty;
            comboBox1.SelectedValue = -1;
            id = null;

        }

        public void IzmjenaInfo()
        {
            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "change of workers";
                button1.Text = "update";
            }
            else
            {


                label1.Text = "izmjena radnika";
                button1.Text = "izmjeni";
            }
            textBox1.Text = id;
            textBox2.Text = jmbg;
            textBox3.Text = Prezime;
            textBox4.Text = Ime;
            textBox5.Text = Uloga;

            textBox6.Text = Plata;
            textBox7.Text = PutniTroskovi;
            textBox8.Text = BrojLicneKarte;
            textBox9.Text = DatumRodjenja;
        }

        public void DodavanjeInfo()
        {

            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "adding workers";
                button1.Text = "add";
            }
            else
            {
                label1.Text = "dodavanje radnika";
                button1.Text = "dodaj";
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
