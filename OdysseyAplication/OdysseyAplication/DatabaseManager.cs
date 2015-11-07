using System;
using System.Data.SqlClient;
using System.IO;

namespace OdysseyAplication
{
    /// <summary>
    /// Maneja la base de datos local
    /// </summary>
    class DatabaseManager
    {
        private const string queryPath = "../../../LocalDatabase.sql";

        private const string masterConn = "Server=localhost;Integrated security=SSPI;database=master";

        private string  createDatabaseQuery = "CREATE DATABASE " + XmlManager.getDatabaseName();

        private string databaseConn = "Server=localhost;Integrated security=SSPI;database=" + XmlManager.getDatabaseName();

        private bool isDatabase;

        /// <summary>
        /// Constructor, verifica si ya se ha creado 
        /// la base de datos, y si no la crea con las 
        /// tablas.
        /// </summary>
        public DatabaseManager()
        {
            isDatabase = XmlManager.isDatabase();

            if (!isDatabase)
            {
                using (SqlConnection connection = new SqlConnection(masterConn))
                {
                    try
                    {
                        SqlCommand createDatabase = new SqlCommand(createDatabaseQuery, connection);

                        connection.Open();
                        createDatabase.ExecuteNonQuery();

                        connection.Close();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Por alguna razón muy satánica no se pudo crear la base");
                    }

                }

                //se crean las tablas de la base

                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    try
                    {
                        string script = File.ReadAllText(queryPath);

                        SqlCommand addTables = new SqlCommand(script, connection);

                        connection.Open();

                        addTables.ExecuteNonQuery();

                        connection.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("#AlgoSalioMal");
                    }

                }


            }//fin el if


        }

    }
}
