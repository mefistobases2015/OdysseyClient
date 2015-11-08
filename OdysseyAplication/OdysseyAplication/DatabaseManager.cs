﻿using System;
using System.Collections.Generic;
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

        static private string  createDatabaseQuery = "CREATE DATABASE " + XmlManager.getDatabaseName();

        static private string databaseConn = "Server=localhost;Integrated security=SSPI;database=" + XmlManager.getDatabaseName();
        
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

        /// <summary>
        /// Crea una nueva canción en la base de datos local
        /// </summary>
        /// <param name="datasong">
        /// objeto con toda la información de la canción.
        /// </param>
        /// <returns>
        /// int que es el id de la canción agregada
        /// </returns>
        public static int createSong(DataSong datasong)
        {
            try
            {
                int result = -1;

                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand insertSong = new SqlCommand();

                    insertSong.CommandType = System.Data.CommandType.Text;
                    insertSong.CommandText = "INSERT canciones_tbl (song_directory) output INSERTED.local_song_id VALUES (@directory)";

                    insertSong.Parameters.AddWithValue("@directory", datasong._SongDirectory);

                    insertSong.Connection = connection;

                    connection.Open();

                    object obj = insertSong.ExecuteScalar();
                    result = (int)obj;

                    connection.Close();
                }
                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);

                return -1;
            }
        }

        /// <summary>
        /// Crea la versión de una canción.
        /// </summary>
        /// <param name="datasong">
        /// Objeto con todos los datos de la canción.
        /// </param>
        /// <returns>
        /// int que es el id de la versión, si es -2 no insertó nada
        /// y si es -1 hay un error.
        /// </returns>
        public static int createVersion(DataSong datasong)
        {
            try
            {
                int result = -2;
                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand insertConnection = new SqlCommand();

                    insertConnection.CommandType = System.Data.CommandType.Text;
                    insertConnection.CommandText = "INSERT versiones_tbl output INSERTED.local_version_id"+ 
                        "(local_song_id, id3v2_title, id3v2_author, id3v2_lyrics, id3v2_album, id3v2_genre, id3v2_year) "+
                        "VALUES (@lsng_id, @title, @author, @lyrics, @album, @genre, @year)";

                    insertConnection.Parameters.AddWithValue("@lsng_id", Convert.ToInt32(datasong._SongID));
                    insertConnection.Parameters.AddWithValue("@title", datasong._ID3Title);
                    insertConnection.Parameters.AddWithValue("@author", datasong._ID3Artist);
                    insertConnection.Parameters.AddWithValue("@lyrics", datasong._ID3Lyrics);
                    insertConnection.Parameters.AddWithValue("@album", datasong._ID3Album);
                    insertConnection.Parameters.AddWithValue("@genre", datasong._ID3Genre);
                    insertConnection.Parameters.AddWithValue("@year", Convert.ToInt32(datasong._ID3Year));

                    insertConnection.Connection = connection;

                    connection.Open();

                    object obj = insertConnection.ExecuteScalar();
                    result = (int)obj;

                    connection.Close();

                }

                return result;
            }
            catch
            {
                return -1;
            }
        }
        
        /// <summary>
        /// Crea una relación entre canción y usuario
        /// </summary>
        /// <param name="usr_name">
        /// nombre del usuario al que se le agrega propiedad
        /// </param>
        /// <param name="local_song_id">
        /// identificador de canción local 
        /// </param>
        /// <param name="song_name">
        /// nombre del archivo de la canción
        /// </param>
        /// <returns>
        /// bool que es true donde se logra crear la fila, 
        /// false en cualquier otro caso.
        /// </returns>
        public static bool createProperty(string usr_name, string local_song_id, string song_name)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand createProperty = new SqlCommand();

                    createProperty.CommandType = System.Data.CommandType.Text;
                    createProperty.CommandText = "INSERT propiedades_tbl (usr_name, local_song_id, song_name) " +
                        "VALUES (@usr, @lsng_id, @sng_name)";

                    createProperty.Parameters.AddWithValue("@usr", usr_name);
                    createProperty.Parameters.AddWithValue("@lsng_id", usr_name);
                    createProperty.Parameters.AddWithValue("@sng_name", usr_name);

                    createProperty.Connection = connection;

                    connection.Open();

                    createProperty.ExecuteNonQuery();

                    connection.Close();
                }

                return true;
            }
            catch(Exception e)
            {

                Console.WriteLine(e);

                return false;
            }
        }

        /// <summary>
        /// Le establece el metadata_id a una canción
        /// </summary>
        /// <param name="song_id">
        /// Identificador de cación a la que se le va a 
        /// establecer el metada_id
        /// </param>
        /// <param name="version_id">
        /// Nuevo metadata id
        /// </param>
        /// <returns>
        /// bool que es true si se logro cambiar el metada id, en otro 
        /// caso va a ser falso.
        /// </returns>
        public static bool setVersion2Song(string song_id, string version_id)
        {
            try
            {
                int sng_id = Convert.ToInt32(song_id);
                int ver_id = Convert.ToInt32(version_id);

                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand updateSong = new SqlCommand();
                    updateSong.CommandType = System.Data.CommandType.Text;

                    updateSong.CommandText = "UPDATE canciones_tbl "
                        + "SET metadata_id = @ver_id WHERE local_song_id = @sng_id";

                    updateSong.Parameters.AddWithValue("@ver_id", ver_id);
                    updateSong.Parameters.AddWithValue("@sng_id", sng_id);

                    updateSong.Connection = connection;

                    connection.Open();

                    updateSong.ExecuteNonQuery();

                    connection.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Agrega una canción a un usurio
        /// </summary>
        /// <param name="usr_name">
        /// Usuario al que se le agrega la canción
        /// </param>
        /// <param name="song_name">
        /// Nombre del archivo de la canción
        /// </param>
        /// <param name="datasong">
        /// Objeto con toda la información de la canción
        /// </param>
        /// <returns>
        /// bool que es true si se pudo agregar la canción. 
        /// En cualquier otro caso es false
        /// </returns>
        public static bool addSong2User(string usr_name, string song_name, DataSong datasong)
        {
            int song_id = createSong(datasong);
            datasong._SongID = song_id.ToString();

            int version_id = createVersion(datasong);
            setVersion2Song(song_id.ToString(), version_id.ToString());

            return createProperty(usr_name, song_id.ToString(), song_name);
        }

        /// <summary>
        /// Obtiene todas las versiones de una canción
        /// </summary>
        /// <param name="song_id">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public static List<Version> getVersionsOfSongs(string song_id)
        {
            try
            {
                List<Version> versions_list = new List<Version>();
                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand versionSongs = new SqlCommand();

                    versionSongs.CommandType = System.Data.CommandType.Text;

                    versionSongs.CommandText = "SELECT local_version_id, id3v2_title,id3v2_author,id3v2_lyrics, id3v2_album, id3v2_genre, id3v2_year, submission_date "
                        + "FROM versiones_tbl WHERE local_song_id = @song_id";

                    versionSongs.Parameters.AddWithValue("@song_id", Convert.ToInt32(song_id));

                    versionSongs.Connection = connection;

                    connection.Open();

                    SqlDataReader reader = versionSongs.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Version version = new Version();

                            version.version_id = reader.GetInt32(0);
                            version.id3v2_title = reader.GetString(1);
                            version.id3v2_author = reader.GetString(2);
                            version.id3v2_lyrics = reader.GetString(3);
                            version.id3v2_album = reader.GetString(4);
                            version.id3v2_genre = reader.GetString(5);
                            version.id3v2_year = reader.GetInt32(6);
                            version.submission_date = reader.GetString(7);
                            version.song_id = Convert.ToInt32(song_id);

                            versions_list.Add(version);
                        }
                    }

                    reader.Close();
                    connection.Close();

                    return versions_list;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }

        /// <summary>
        /// Obtiene todas las canciones de un usuario
        /// </summary>
        /// <param name="user_name">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public static List<DataSong> getSongsOfUser(string user_name)
        {
            try
            {
                List<DataSong> songs_list = new List<DataSong>();

                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand versionSongs = new SqlCommand();

                    versionSongs.CommandType = System.Data.CommandType.Text;

                    versionSongs.CommandText = "SELECT * "
                        + "FROM canc_metadata_tbl WHERE usr_name = @usrname";

                    versionSongs.Parameters.AddWithValue("@usrname", user_name);

                    versionSongs.Connection = connection;

                    connection.Open();

                    SqlDataReader reader = versionSongs.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataSong dataSong = new DataSong();
                            
                            dataSong._ID3Title = reader.GetString(1);
                            dataSong._ID3Artist = reader.GetString(2);
                            dataSong._ID3Album = reader.GetString(3);
                            dataSong._ID3Year = reader.GetInt32(4).ToString();
                            dataSong._ID3Genre = reader.GetString(5);
                            dataSong._ID3Lyrics = reader.GetString(6);
                            dataSong._SubmissionDate = reader.GetString(7);
                            dataSong._SongDirectory = reader.GetString(8);
                            dataSong._SongDirectory = reader.GetInt32(9).ToString();

                            songs_list.Add(dataSong);
                        }
                    }

                    reader.Close();
                    connection.Close();

                    return songs_list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }

        /// <summary>
        /// Evalua si una canción esta sincronizada
        /// </summary>
        /// <param name="song_id">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public static bool isSongSync(string song_id)
        {
            try
            {
                bool result = false;

                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand isSync = new SqlCommand();

                    isSync.CommandType = System.Data.CommandType.Text;

                    isSync.CommandText = "SELECT cloud_song_id  "
                        + "FROM canciones_tbl WHERE local_song_id = @id";

                    isSync.Parameters.AddWithValue("@song_id", Convert.ToInt32(song_id));

                    isSync.Connection = connection;

                    connection.Open();

                    SqlDataReader reader = isSync.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int cloud = reader.GetInt32(0);

                            if(cloud > 0)
                            {
                                result = true;
                            }
                        }
                    }

                    reader.Close();
                    connection.Close();

                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return false;
            }
        }

    }

}
