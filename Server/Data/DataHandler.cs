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
        private String connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + 
            Environment.CurrentDirectory + @"\Data\DataHolder.mdf;Integrated Security=True";

        public enum Columns
        {
            Name, Genre, Description, Location
        }

        //Add ny row til tabel funktion
        public Task<AsyncSQLResult> AddCommand(string films, string genre, string description, string location)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("INSERT INTO Films (Name, Genre, Description, Location)  VALUES (@Films, @Genre, @Description, @Location)", conn))
            {
                conn.Open();

                command.Parameters.AddWithValue("@Films", films);
                command.Parameters.AddWithValue("@Genre", genre);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Location", location);

                command.ExecuteNonQuery();
            }
            Program.ServerForm.UpdateMovieCount();

            return Task.FromResult(AsyncSQLResult.Succeful);
        }

        //Delete fra tabel funktion
        public Task<AsyncSQLResult> DeleteCommand(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))            
            using (SqlCommand command = new SqlCommand("DELETE FROM Films WHERE Id=@ID", conn))
            {
                conn.Open();

                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
                Program.ServerForm.UpdateMovieCount();

                return Task.FromResult(AsyncSQLResult.Succeful);
            }
        }

        //Hent tabel data
        public Task<DataTable> DataReader()
        {
            SqlDataReader reader = null;
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM Films", conn))
            {
                conn.Open();
                using (reader = command.ExecuteReader())
                {
                    using (DataTable table = new DataTable("Temp"))
                    {
                        table.Load(reader);
                        reader.Close();
                        conn.Close();
                        return Task.FromResult(table);
                    }
                }
            }
        }

        //Opdatere tablet
        public Task<AsyncSQLResult> UpdateTabel(Columns column, string Data, int Id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", conn))
            {
                conn.Open();
                switch (column)
                {
                    case Columns.Name:
                        command.CommandText = "UPDATE FILMS SET Name=@FILMTITLE WHERE Id=@ID";
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

                command.Parameters.AddWithValue("@FILMTITLE", Data);
                command.Parameters.AddWithValue("@GENRE", Data);
                command.Parameters.AddWithValue("@DESCRIPTION", Data);
                command.Parameters.AddWithValue("@LOCATION", Data);
                command.Parameters.AddWithValue("@ID", Id);

                command.ExecuteNonQuery();

                return Task.FromResult(AsyncSQLResult.Succeful);
            }
        }
    }
}
