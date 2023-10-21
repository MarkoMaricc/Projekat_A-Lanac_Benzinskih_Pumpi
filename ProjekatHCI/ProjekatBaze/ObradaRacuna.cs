using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;


namespace ProjekatBaze
{
    class ObradaRacuna
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



        public static void obrisiRacun(string idRacuna)
        {
            string sql = "DELETE FROM `benzinska_pumpa`.`racun` WHERE id = @id";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(idRacuna);

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
                MessageBox.Show("Racun nije obrisan. \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
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


        public static void izmjenaRacuna(Racun apg, String id)
        {
            string sql = "UPDATE `benzinska_pumpa`.`racun` SET id = @id, Datum = @Datum,Cena=@Cena,idKase = @idKase WHERE id =@Pid";
           
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.idRacune);
            command.Parameters.Add("@Datum", MySqlDbType.DateTime).Value = DateTime.Parse(apg.Datum);
            command.Parameters.Add("@Cena", MySqlDbType.Decimal).Value = Double.Parse(apg.Cena);
            command.Parameters.Add("@idKase", MySqlDbType.Int32).Value = Int32.Parse(apg.idKlase);


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



        public static void dodavanjeRacuna(Racun apg)
        {

            string sql = "INSERT INTO `benzinska_pumpa`.`racun` VALUES (@id,@Datum,@Cena,@idKase)";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.idRacune);
            command.Parameters.Add("@Datum", MySqlDbType.DateTime).Value = DateTime.Parse(apg.Datum);
            command.Parameters.Add("@Cena", MySqlDbType.Decimal).Value = Double.Parse(apg.Cena);
            command.Parameters.Add("@idKase", MySqlDbType.Int32).Value = Int32.Parse(apg.idKlase);





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

    }
}
