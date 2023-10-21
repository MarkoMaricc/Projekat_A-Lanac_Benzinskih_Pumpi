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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatBaze
{
    public partial class DodajProizvod : Form
    {
        PrikazP otac;
       public String Vrsta,Cena,idSkladista;
        public DodajProizvod(PrikazP Potac)
        {
            InitializeComponent();
            otac = Potac;


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
        private void DodajProizvod_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM `benzinska_pumpa`.`skladiste`";
            DataTable dataTable = GetData(sql);

            comboBox1.DisplayMember = dataTable.Columns[4].ToString();
            comboBox1.ValueMember = dataTable.Columns[0].ToString();

            comboBox1.DataSource = dataTable;
            if (Vrsta != null)
            {
                comboBox1.SelectedValue = idSkladista;
            }
            else
                comboBox1.SelectedValue = -1;
        }
        public void ocisti() {

            textBox1.Text = textBox2.Text =  string.Empty;
            comboBox1.SelectedValue = -1;
            Vrsta = null;
        }

        public void IzmjenaInfo()
        {
            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "product modification";
                izmjeni.Text = "update";
            }
            else
            {

                label1.Text = "izmjena proizvoda";
                izmjeni.Text = "izmjeni";
            }
            textBox1.Text = Vrsta;
            textBox2.Text = Cena;
            

        }

        public void DodavanjeInfo()
        {
            var currCulture = Thread.CurrentThread.CurrentCulture;
            if (currCulture.Name == "en")
            {

                label1.Text = "adding products";
                izmjeni.Text = "add";
            }
            else
            {

                label1.Text = "dodavanje proizvoda";
                izmjeni.Text = "dodaj";
            }
        }

        private void IzmjenaProizvoda_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ocisti();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void izmjeni_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length < 3 || textBox2.Text.Trim().Length < 1 ||  comboBox1.SelectedValue == null)
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


            if (izmjeni.Text == "izmjeni" || izmjeni.Text == "update")
            {
                Proizvod ra = new Proizvod(textBox1.Text.Trim(), textBox2.Text.Trim(), comboBox1.SelectedValue.ToString());
                ObradaProizvoda.izmjenaProizvoda(ra, Vrsta);
                ocisti();
            }

            if (izmjeni.Text == "dodaj" || izmjeni.Text == "add")
            {
                Proizvod ra = new Proizvod(textBox1.Text.Trim(), textBox2.Text.Trim(), comboBox1.SelectedValue.ToString());
                ObradaProizvoda.dodavanjeProizvoda(ra);
                ocisti();
            }
            this.Close();
            otac.Display();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
