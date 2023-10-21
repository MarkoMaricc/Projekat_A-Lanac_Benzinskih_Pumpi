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
    internal class ObradaRadnika
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
        public static void izmjenaRadnika(Radnik apg, String id)
        {
            string sql = "UPDATE `benzinska_pumpa`.`radnik` SET id = @id, JMBG = @JMBG,Prezime=@Prezime,Ime=@Ime,Uloga = @Uloga," +
                "Plata = @Plata,PutniTroskovi = @PutniTroskovi,BrojLicneKarte = @BrojLicneKarte,DatumRodjenja = @DatumRodjenja,idStanice = @idStanice WHERE id =@Pid";
           
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.id);
            command.Parameters.Add("@JMBG", MySqlDbType.VarChar).Value = apg.JMBG;
            command.Parameters.Add("@Prezime", MySqlDbType.VarChar).Value = apg.Prezime;
            command.Parameters.Add("@Ime", MySqlDbType.VarChar).Value = apg.Ime;
            command.Parameters.Add("@Uloga", MySqlDbType.VarChar).Value = apg.Uloga;
            command.Parameters.Add("@Plata", MySqlDbType.Decimal).Value = Double.Parse(apg.Plata);
            command.Parameters.Add("@PutniTroskovi", MySqlDbType.Decimal).Value = Double.Parse(apg.PlatniTroskovi);
            command.Parameters.Add("@BrojLicneKarte", MySqlDbType.VarChar).Value = apg.BrojLicneKarte;
            command.Parameters.Add("@DatumRodjenja", MySqlDbType.DateTime).Value = DateTime.Parse(apg.DatumRodjenja);
            command.Parameters.Add("@idStanice", MySqlDbType.Int32).Value = Int32.Parse(apg.idStanice);


            command.Parameters.Add("@Pid", MySqlDbType.Int32).Value = Int32.Parse(id);

            Console.WriteLine("string: " + DateTime.Parse(apg.DatumRodjenja));

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





        public static void dodavanjeRadnika(Radnik apg)
        {
            string sql = "INSERT INTO `benzinska_pumpa`.`radnik` VALUES (@id,@JMBG,@Prezime,@Ime,@Uloga,@Plata,@PutniTroskovi,@" +
                "BrojLicneKarte,@DatumRodjenja,@idStanice)";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.id);
            command.Parameters.Add("@JMBG", MySqlDbType.VarChar).Value = apg.JMBG;
            command.Parameters.Add("@Prezime", MySqlDbType.VarChar).Value = apg.Prezime;
            command.Parameters.Add("@Ime", MySqlDbType.VarChar).Value = apg.Ime;
            command.Parameters.Add("@Uloga", MySqlDbType.VarChar).Value = apg.Uloga;
            command.Parameters.Add("@Plata", MySqlDbType.Decimal).Value = Double.Parse(apg.Plata);
            command.Parameters.Add("@PutniTroskovi", MySqlDbType.Decimal).Value = Double.Parse(apg.PlatniTroskovi);
            command.Parameters.Add("@BrojLicneKarte", MySqlDbType.VarChar).Value = apg.BrojLicneKarte;
            command.Parameters.Add("@DatumRodjenja", MySqlDbType.DateTime).Value = DateTime.Parse(apg.DatumRodjenja);
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


        public static void obrisiRadnika(string id)
        {
            string sql = "DELETE FROM `benzinska_pumpa`.`radnik` WHERE id = @id";
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
