using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatBaze
{
    internal class ObradaAparataZaGorivo
    {
        public static MySqlConnection GetConnection()
        {
            

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["benzinska_pumpa"].ConnectionString);
           



            try
            {
                connection.Open();
            }
            catch (MySqlException exception)
            {
                MessageBox.Show("Problem sa MYSQL konekcijom! \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return connection;
        }

        public static void DisplayAndSearch(string query, DataGridView dataGridView)
        {
           
            string sql = query;
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView.DataSource = table;
            connection.Close();
        }


        public static void izmjenaAparata(AparatZaGorivo apg, String id)
        {
            string sql = "UPDATE `benzinska_pumpa`.`aparat_za_gorivo` SET id = @id, Vrsta = @Vrsta,Materijal=@Materijal,Proizvodjac=@Proizvodjac, idStanice = @idStanice WHERE id =@Pid";
           // Console.WriteLine("string: " + sql);
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(id);
            command.Parameters.Add("@Vrsta", MySqlDbType.VarChar).Value = apg.Vrsta;
            command.Parameters.Add("@Materijal", MySqlDbType.VarChar).Value = apg.Materijal;
            command.Parameters.Add("@Proizvodjac", MySqlDbType.VarChar).Value = apg.Proizvodjac;
            command.Parameters.Add("@idStanice", MySqlDbType.Int32).Value = Int32.Parse(apg.idStanice);

            
            command.Parameters.Add("@Pid", MySqlDbType.Int32).Value = Int32.Parse(id);



            try
            {
                command.ExecuteNonQuery();
                var currCulture = Thread.CurrentThread.CurrentCulture;
                if (currCulture.Name == "en")
                {
                    MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   
                    MessageBox.Show("Uspjesna izmjena.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException exception)
            {
                MessageBox.Show("Doslo je do greske pri izmjeni. \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exception.StackTrace);
            }
            connection.Close();
        }

        public static void dodajAparat(AparatZaGorivo apg)
        {
            string sql = "INSERT INTO `benzinska_pumpa`.`aparat_za_gorivo` VALUES (@id,@Vrsta,@Materijal,@Proizvodjac,@idStanice)";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.idTocilice);
            command.Parameters.Add("@Vrsta", MySqlDbType.VarChar).Value = apg.Vrsta;
            command.Parameters.Add("@Materijal", MySqlDbType.VarChar).Value = apg.Materijal;
            command.Parameters.Add("@Proizvodjac", MySqlDbType.VarChar).Value = apg.Proizvodjac;
            Console.WriteLine("Ovo je tekst na konzoli "+ apg.idStanice);
            command.Parameters.Add("@idStanice", MySqlDbType.Int32).Value = Int32.Parse(apg.idStanice);

            try
            {
                command.ExecuteNonQuery();
                var currCulture = Thread.CurrentThread.CurrentCulture;
                if (currCulture.Name == "en")
                {
                    MessageBox.Show("Adding successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Dodavanje uspješno.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException exception)
            {
                MessageBox.Show("Doslo je do greske! \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public static void obrisiAparat(string id)
        {
            string sql = "DELETE FROM `benzinska_pumpa`.`aparat_za_gorivo` WHERE id = @id";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(id);

            try
            {
                command.ExecuteNonQuery();
                var currCulture = Thread.CurrentThread.CurrentCulture;
                if (currCulture.Name == "en")
                {
                    MessageBox.Show("Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Uspjesno brisanje.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException exception)
            {
                MessageBox.Show("Brisanje nije uspjelo. \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
    }
}
