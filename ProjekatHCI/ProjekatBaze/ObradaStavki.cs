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
    class ObradaStavki
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



        public static void obrisiStavku(string pidStavke)
        {
            string sql = "DELETE FROM `benzinska_pumpa`.`stavka` WHERE id = @id";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(pidStavke);

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
                    MessageBox.Show("Uspjesno obrisana stavka.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException exception)
            {
                MessageBox.Show("Niste uspjeli da obrisete stavku. \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
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

        public static void izmjenaStavke(Stavka apg, String id)
        {
            string sql = "UPDATE `benzinska_pumpa`.`stavka` SET id = @id, Kolicina = @Kolicina,Cena=@Cena,idRacuna=@idRacuna," +
                "PROIZVOD_Vrsta = @PROIZVOD_Vrsta WHERE id =@Pid";
           
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.idStavke);
            command.Parameters.Add("@Kolicina", MySqlDbType.Int32).Value = Int32.Parse(apg.Kolicina);
            command.Parameters.Add("@Cena", MySqlDbType.Decimal).Value = Double.Parse(apg.Cena);


    
            command.Parameters.Add("@idRacuna", MySqlDbType.Int32).Value = Int32.Parse(apg.idRacuna);
            command.Parameters.Add("@PROIZVOD_Vrsta", MySqlDbType.VarChar).Value = apg.ProizvodVrsta;

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

        public static void dodavanjeStavke(Stavka apg)
        {
            string sql = "INSERT INTO `benzinska_pumpa`.`stavka` VALUES (@id,@Kolicina,@Cena,@idRacuna,@PROIZVOD_Vrsta)";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(apg.idStavke);
            command.Parameters.Add("@Kolicina", MySqlDbType.Int32).Value = Int32.Parse(apg.Kolicina);
            command.Parameters.Add("@Cena", MySqlDbType.Decimal).Value = Double.Parse(apg.Cena);

            

            command.Parameters.Add("@idRacuna", MySqlDbType.Int32).Value = Int32.Parse(apg.idRacuna);

            command.Parameters.Add("@PROIZVOD_Vrsta", MySqlDbType.VarChar).Value = apg.ProizvodVrsta;




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
                    MessageBox.Show("Uspjesno ste dodali stavku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException exception)
            {
                MessageBox.Show("Doslo je do greske pri dodavanju. \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exception.StackTrace);
            }
            connection.Close();
        }

    }
}
