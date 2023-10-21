using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatBaze
{
    public partial class DodajStavku : Form
    {
        private PrikazStavki otac;
        public string id, Kolicina, Cena, idRacuna, Proizvod_vrsta;

        public DodajStavku(PrikazStavki pOtac)
        {
            InitializeComponent();
            otac = pOtac;
            
        }


        public void ocisti() {
            idS.Text =string.Empty;
            kol.Text = string.Empty;
            idR.Text = string.Empty;
            cen.Text = string.Empty;

            comboBox1.SelectedValue = -1;
            id = null;
        }

        public void IzmjenaInfo()
        {

            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "item modification";
                button1.Text = "update";
            }
            else
            {

                label1.Text = "izmjena stavke";
                button1.Text = "izmjeni";
            }
            idS.Text = id;
            kol.Text = Kolicina;
            idR.Text = idRacuna;
            cen.Text = Cena;
          

        }

        public void DodavanjeInfo()
        {
            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "adding an item";
                button1.Text = "add";
            }
            else
            {

                label1.Text = "dodavanje stavke";
                button1.Text = "dodaj";
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (idS.Text.Trim().Length < 1 || kol.Text.Trim().Length < 1 || idR.Text.Trim().Length < 1 || cen.Text.Trim().Length < 1
            || comboBox1.SelectedValue == null)
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
                Stavka ra = new Stavka(idS.Text.Trim(), kol.Text.Trim(),
                     cen.Text.Trim(), idR.Text.Trim(), comboBox1.SelectedValue.ToString());
                ObradaStavki.izmjenaStavke(ra, id);
                ocisti();
            }

            if (button1.Text == "dodaj" || button1.Text == "add")
            {
                Stavka ra = new Stavka(idS.Text.Trim(), kol.Text.Trim(),
                      cen.Text.Trim(), idR.Text.Trim(), comboBox1.SelectedValue.ToString());
                ObradaStavki.dodavanjeStavke(ra);
                ocisti();
            }
            this.Close();
            otac.Display();
        }

        private void DodajStavku_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM `benzinska_pumpa`.`proizvod`";
            DataTable dataTable = GetData(sql);

            comboBox1.DisplayMember = dataTable.Columns[0].ToString();
            comboBox1.ValueMember = dataTable.Columns[0].ToString();


            comboBox1.DataSource = dataTable;
            if (id != null)
            {
                comboBox1.SelectedValue = Proizvod_vrsta;
            }
            else
                comboBox1.SelectedValue = -1;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ocisti();
            this.Close();
        }

       

      
    }
}
