using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Server.Data
{
    class DataHandler
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elias\Source\Repos\Film-Manager\Server\Data\DataHolder.mdf;Integrated Security=True");

        public enum Columns
        {
            Films, Genre, Description, Location
        }

        public void Connect()
        {
            try { connection.Open(); } catch { }
        }

        //Add ny row til tabel funktion
        public void AddCommand(string films, string genre, string description, string location)
        {
            Connect();
            using (SqlCommand command = new SqlCommand("INSERT INTO Films (Films, Genre, Description, Location)  VALUES (@Films, @Genre, @Description, @Location)", connection))
            {
                command.Parameters.AddWithValue("@Films", films);
                command.Parameters.AddWithValue("@Genre", genre);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Location", location);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        //Delete fra tabel funktion
        public void DeleteCommand(int id)
        {
            Connect();
            using (SqlCommand command = new SqlCommand("DELETE FROM Films WHERE Id=@ID", connection))
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        //Hent tabel data
        public DataTable DataReader()
        {
            try
            {
                Connect();
                SqlDataReader reader = null;
                using (SqlCommand command = new SqlCommand("SELECT * FROM Films", connection))
                {
                    using (reader = command.ExecuteReader())
                    {
                        using (DataTable table = new DataTable("Temp"))
                        {
                            table.Load(reader);
                            connection.Close();
                            return table;
                        }
                    }
                }
            }
            catch { }

            return null;
        }

        //Opdatere tablet
        public void UpdateTabel(Columns column, string Data, int Id)
        {
            try
            {
                Connect();
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    switch(column)
                    {
                        case Columns.Films:
                            command.CommandText = "UPDATE FILMS SET Films=@FILMTITLE WHERE Id=@ID";
                            break;
                        case Columns.Genre:
                            command.CommandText = "UPDATE FILMS SET Genre=@GENRE WHERE Id=@ID";
                            break;
                        case Columns.Description:
                            command.CommandText = "UPDATE FILMS SET Description=@DESCRIPTION WHERE Id=@ID";
                            break;
                        case Columns.Location:
                            command.CommandText = "UPDATE FILMS set Location=@LOCATION WHERE Id=@ID";
                            break;
                    }
                    Console.WriteLine("Hej");

                    command.Parameters.AddWithValue("@FILMSTITLE", Data);
                    command.Parameters.AddWithValue("@GENRE", Data);
                    command.Parameters.AddWithValue("@DESCRIPTION", Data);
                    command.Parameters.AddWithValue("@LOCATION", Data);
                    command.Parameters.AddWithValue("@ID", Id);

                    command.ExecuteNonQuery();
                }
            } catch
            {
                throw;
            }

            connection.Close();
        }
    }
}
