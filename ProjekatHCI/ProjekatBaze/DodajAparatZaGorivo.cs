using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatBaze
{
    public partial class DodajAparatZaGorivo : Form
    {
        private PrikazAparataZaGorivo otac;
        public String id, Vrsta, Materijal, Proizvodjac,idStanice;
   
        public DodajAparatZaGorivo(PrikazAparataZaGorivo pOtac)
        {
            InitializeComponent();
            otac = pOtac;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void ocisti()
        {
            textBox1.Text=textBox2.Text=textBox3.Text=textBox4.Text= string.Empty;
            comboBox1.SelectedValue = -1;
            id = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ocisti();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim().Length < 1 || textBox2.Text.Trim().Length < 3 || textBox3.Text.Trim().Length < 3
              || textBox4.Text.Trim().Length < 3 || comboBox1.SelectedValue==null)
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
                AparatZaGorivo apg = new AparatZaGorivo(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), comboBox1.SelectedValue.ToString());
                ObradaAparataZaGorivo.izmjenaAparata(apg,id);
               ocisti();
            }

            if (button2.Text == "dodaj" || button2.Text == "add")
            {
                AparatZaGorivo apg = new AparatZaGorivo(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), comboBox1.SelectedValue.ToString());
                ObradaAparataZaGorivo.dodajAparat(apg);
                ocisti();
            }
            this.Close();
            otac.Display();
        }

        private void DodajAparatZaGorivo_Load(object sender, EventArgs e)
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

        public void IzmjenaInfo()
        {

            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "replacement of the fuel apparatus";
                button2.Text = "update";
            }
            else
            {
                label1.Text = "izmjena aparata za gorivo";
                button2.Text = "izmjeni";
            }
            textBox1.Text = id;
            textBox2.Text = Vrsta;
            textBox3.Text = Materijal;
                textBox4.Text =Proizvodjac;
            

        }

        public void DodavanjeInfo()
        {
            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "adding fuel apparatus";
                button2.Text = "add";
            }
            else
            {

                label1.Text = "dodavanje aparata za gorivo";
                button2.Text = "dodaj";
            }
        }
    }
}
