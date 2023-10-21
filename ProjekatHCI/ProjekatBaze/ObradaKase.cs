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
    internal class ObradaKase
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


        public static void izmjenaKase(Kasa apg, String id)
        {
            string sql = "UPDATE `benzinska_pumpa`.`kasa` SET id = @id, NacinPlacanja = @NacinPlacanja,Vrsta=@Vrsta,idStanice=@idStanice WHERE id =@Pid";
            
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.id);
            command.Parameters.Add("@NacinPlacanja", MySqlDbType.VarChar).Value = apg.NacinPlacanja;
            command.Parameters.Add("@Vrsta", MySqlDbType.VarChar).Value = apg.Vrsta;
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


        public static void dodajKase(Kasa apg)
        {
            string sql = "INSERT INTO `benzinska_pumpa`.`kasa` VALUES (@id,@NacinPlacanja,@Vrsta,@idStanice)";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.id);
            command.Parameters.Add("@NacinPlacanja", MySqlDbType.VarChar).Value = apg.NacinPlacanja;
            command.Parameters.Add("@Vrsta", MySqlDbType.VarChar).Value = apg.Vrsta;
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
                    MessageBox.Show("Uspjesno dodavanje.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException exception)
            {
                MessageBox.Show("Doslo je do greske pri izmjeni. \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exception.StackTrace);
            }
            connection.Close();
        }

        public static void obrisiKasu(string id)
        {
            string sql = "DELETE FROM `benzinska_pumpa`.`kasa` WHERE id = @id";
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
