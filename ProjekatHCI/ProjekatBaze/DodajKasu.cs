using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatBaze
{
    public partial class DodajKasu : Form
    {
        private PrikazKase otac;
       public string id, NacinPlacanja, Vrsta, idStanice;
        public DodajKasu(PrikazKase pOtac)
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
        private void DodajKasu_Load(object sender, EventArgs e)
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
            if (textBox1.Text.Trim().Length < 1 || textBox2.Text.Trim().Length < 3 || textBox3.Text.Trim().Length < 3 || comboBox1.SelectedValue == null)
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
                Kasa ra = new Kasa(textBox1.Text.Trim(), textBox2.Text.Trim(),
                    textBox3.Text.Trim(), comboBox1.SelectedValue.ToString());
                ObradaKase.izmjenaKase(ra, id);
                ocisti();
            }

            if (button2.Text == "dodaj" || button2.Text == "add")
            {
                Kasa ra = new Kasa(textBox1.Text.Trim(), textBox2.Text.Trim(),
                      textBox3.Text.Trim(), comboBox1.SelectedValue.ToString());
                ObradaKase.dodajKase(ra);
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

        public void ocisti()
        {
            textBox1.Text = textBox2.Text = textBox3.Text =  string.Empty;
            comboBox1.SelectedValue = -1;
            id = null;

        }


        public void IzmjenaInfo()
        {

            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "change of cash register";
                button2.Text = "update";
            }
            else
            {
                label1.Text = "izmjena kase";
                button2.Text = "izmjeni";
            }
            textBox1.Text = id;
            textBox2.Text = NacinPlacanja;
            textBox3.Text = Vrsta;
           
        }

        public void DodavanjeInfo()
        {
            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "adding cash register";
                button2.Text = "add";
            }
            else
            {

                label1.Text = "dodavanje kase";
                button2.Text = "dodaj";
            }
        }
    }
}
