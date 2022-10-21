using CarecaGenerator.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarecaGenerator.Repository
{
    public class CarecaRepository: ICarecaRepository
    {
        private readonly string? _dataSource;
        private readonly string? _userID;
        private readonly string? _password;
        private readonly string? _database;
        
        public CarecaRepository()
        {
            _dataSource = Environment.GetEnvironmentVariable("DATA_SOURCE");
            _userID = Environment.GetEnvironmentVariable("USER_ID");
            _password = Environment.GetEnvironmentVariable("PASSWORD");
            _database = Environment.GetEnvironmentVariable("DATABASE");
        }

        public Careca GetCareca()
        {
            List<Careca> carecas = new List<Careca>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = _dataSource;
                builder.UserID = _userID;
                builder.Password = _password;
                builder.InitialCatalog = _database;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();

                    var sql = @"SELECT ID, IMAGEB64 FROM CARECA_DB.dbo.CARECA";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var careca = new Careca()
                                {
                                    Id = reader.GetInt64(0),
                                    image = reader.GetString(1)
                                };

                                carecas.Add(careca);
                            }

                            return GetRandomCareca(carecas);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                throw e;
            }
        }

        private Careca GetRandomCareca(List<Careca> carecas)
        {
            Random rnd = new Random();

            int r = rnd.Next(carecas.Count);

            return carecas[r];
        }

    }
}
