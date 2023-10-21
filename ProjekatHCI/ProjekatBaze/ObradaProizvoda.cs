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

    


    class ObradaProizvoda
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



        public static void izmjenaProizvoda(Proizvod pr,String vrsta)
        {
            string sql = "UPDATE `benzinska_pumpa`.`proizvod` SET Vrsta = @Vrsta, Cena = @Cena, idSkladista = @idSkladista WHERE Vrsta =@pVrsta";
            Console.WriteLine("string: "+sql);
            MySqlConnection connection = GetConnection(); 
            MySqlCommand command = new MySqlCommand(sql, connection); 
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Vrsta", MySqlDbType.VarChar).Value = pr.Vrsta;
            command.Parameters.Add("@Cena", MySqlDbType.Decimal).Value = Double.Parse(pr.Cena);
            command.Parameters.Add("@idSkladista", MySqlDbType.Int32).Value = Int32.Parse(pr.idSkladista);
            command.Parameters.Add("@pVrsta", MySqlDbType.VarChar).Value = vrsta;


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
                MessageBox.Show("Doslo je do greske pri izmjeni \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exception.StackTrace);
            }
            connection.Close();
        }



        public static void dodavanjeProizvoda(Proizvod pr)
        {
            string sql = "INSERT INTO `benzinska_pumpa`.`proizvod` VALUES (@Vrsta,@Cena,@idSkladista)";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Vrsta", MySqlDbType.VarChar).Value = pr.Vrsta;
            command.Parameters.Add("@Cena", MySqlDbType.Decimal).Value = Double.Parse(pr.Cena);
            command.Parameters.Add("@idSkladista", MySqlDbType.Int32).Value = Int32.Parse(pr.idSkladista);

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
                MessageBox.Show("Doslo je do greske pri dodavanju \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exception.StackTrace);
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





        public static void obrisiProizvod(string vrsta)
        {
            string sql = "DELETE FROM `benzinska_pumpa`.`proizvod` WHERE Vrsta = @Vrsta";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Vrsta", MySqlDbType.VarChar).Value = vrsta;

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
                MessageBox.Show("Proizvod nije obrisan. \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
    }
}
