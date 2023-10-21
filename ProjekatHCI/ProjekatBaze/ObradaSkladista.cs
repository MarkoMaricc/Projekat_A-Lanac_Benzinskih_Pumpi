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
    internal class ObradaSkladista
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




        public static void izmjenaSkladista(Skladiste apg, String id)
        {
            string sql = "UPDATE `benzinska_pumpa`.`skladiste` SET id = @id, BrojProizvoda = @BrojProizvoda,ProtivPozarniSistem=@ProtivPozarniSistem,Kapacitet=@Kapacitet,Vrsta = @Vrsta," +
                "Status = @Status,idStanice = @idStanice WHERE id =@Pid";
            
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.id);
            command.Parameters.Add("@BrojProizvoda", MySqlDbType.Int32).Value = Int32.Parse(apg.BrojProizvoda);
            command.Parameters.Add("@ProtivPozarniSistem", MySqlDbType.Byte).Value = byte.Parse(apg.ProtivPozarniSistem);
            command.Parameters.Add("@Kapacitet", MySqlDbType.Int32).Value = Int32.Parse(apg.Kapacitet);
            command.Parameters.Add("@Vrsta", MySqlDbType.VarChar).Value = apg.Vrsta;
            command.Parameters.Add("@Status", MySqlDbType.VarChar).Value = apg.Status;



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





        public static void dodavanjeSkladista(Skladiste apg)
        {
            string sql = "INSERT INTO `benzinska_pumpa`.`skladiste` VALUES (@id,@BrojProizvoda,@ProtivPozarniSistem" +
                ",@Kapacitet,@Vrsta,@Status,@idStanice)";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.id);
            command.Parameters.Add("@BrojProizvoda", MySqlDbType.Int32).Value = Int32.Parse(apg.BrojProizvoda);
            command.Parameters.Add("@ProtivPozarniSistem", MySqlDbType.Byte).Value = byte.Parse(apg.ProtivPozarniSistem);
            command.Parameters.Add("@Kapacitet", MySqlDbType.Int32).Value = Int32.Parse(apg.Kapacitet);
            command.Parameters.Add("@Vrsta", MySqlDbType.VarChar).Value = apg.Vrsta;
            command.Parameters.Add("@Status", MySqlDbType.VarChar).Value = apg.Status;



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
                MessageBox.Show("Doslo je do greske pri dodavanju. \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exception.StackTrace);
            }
            connection.Close();
        }

        public static void obrisiSkladiste(string id)
        {
            string sql = "DELETE FROM `benzinska_pumpa`.`skladiste` WHERE id = @id";
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
