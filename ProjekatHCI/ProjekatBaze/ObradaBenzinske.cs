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
    internal class ObradaBenzinske
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

        public static void izmjenaBenzinske(BenzinskeStanice apg, String id)
        {
            string sql = "UPDATE `benzinska_pumpa`.`benzinske_stanice` SET id = @id, Adresa = @Adresa,Grad=@Grad,Drzava=@Drzava, Telefon = @Telefon, email = @email, BrojParkingMjesta = @BrojParkingMjesta, Naziv = @Naziv WHERE id =@Pid";
           
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.id);
            command.Parameters.Add("@Adresa", MySqlDbType.VarChar).Value = apg.Adresa;
            command.Parameters.Add("@Grad", MySqlDbType.VarChar).Value = apg.Grad;
            command.Parameters.Add("@Drzava", MySqlDbType.VarChar).Value = apg.Drzava;
            command.Parameters.Add("@Telefon", MySqlDbType.VarChar).Value = apg.Telefon;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = apg.email;
            command.Parameters.Add("@BrojParkingMjesta", MySqlDbType.Int32).Value = Int32.Parse(apg.brojParkingMjesta);

            command.Parameters.Add("@Naziv", MySqlDbType.VarChar).Value = apg.Naziv;
          


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



        public static void dodajBenzinske(BenzinskeStanice apg)
        {
            string sql = "INSERT INTO `benzinska_pumpa`.`benzinske_stanice` VALUES (@id,@Adresa,@Grad,@Drzava,@Telefon,@email,@BrojParkingMjesta,@Naziv)";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.id);
            command.Parameters.Add("@Adresa", MySqlDbType.VarChar).Value = apg.Adresa;
            command.Parameters.Add("@Grad", MySqlDbType.VarChar).Value = apg.Grad;
            command.Parameters.Add("@Drzava", MySqlDbType.VarChar).Value = apg.Drzava;
            command.Parameters.Add("@Telefon", MySqlDbType.VarChar).Value = apg.Telefon;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = apg.email;
            command.Parameters.Add("@BrojParkingMjesta", MySqlDbType.Int32).Value = Int32.Parse(apg.brojParkingMjesta);

            command.Parameters.Add("@Naziv", MySqlDbType.VarChar).Value = apg.Naziv;





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
                MessageBox.Show("Doslo je do greske pri dodavanju. \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exception.StackTrace);
            }
            connection.Close();
        }


        public static void obrisiBenzinske(string id)
        {
            string sql = "DELETE FROM `benzinska_pumpa`.`benzinske_stanice` WHERE id = @id";
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
