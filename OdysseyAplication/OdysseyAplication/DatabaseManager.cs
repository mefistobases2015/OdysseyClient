using System;
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

        private const string viewPath = "../../../View.sql";

        static private string createDatabaseQuery = "CREATE DATABASE " + XmlManager.getDatabaseName();

        static private string databaseConn = "Server=localhost;Database=" + XmlManager.getDatabaseName() + ";Trusted_Connection=True;";

        private const string masterConn = "Server=localhost;Integrated security=SSPI;database=master";

        //static private string  createDatabaseQuery = "CREATE DATABASE " + XmlManager.getDatabaseName();

        //static private string databaseConn = "Server=localhost;Integrated security=SSPI;database=" + XmlManager.getDatabaseName();
        
        private bool isDatabase;

        public static string etrace1 = "";

        /// <summary>
        /// Constructor, verifica si ya se ha creado 
        /// la base de datos, y si no la crea con las 
        /// tablas.
        /// </summary>
        public DatabaseManager()
        {
            isDatabase = XmlManager.isDatabase();

            bool isTables = XmlManager.isTables();

            bool isView = XmlManager.isView();

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

                        XmlManager.databaseCreated();
                    }
                    catch (Exception e)
                    {
                        etrace1 = e.Message;
                        Console.WriteLine(e);
                        Console.WriteLine("Por alguna razón muy satánica no se pudo crear la base");
                    }

                }

            }

            //crea tablas
            if (!isTables)
            {
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

                        XmlManager.tablesCreated();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("#AlgoSalioMal");
                    }

                }
            }

            //crea View 
            if (!isView)
            {
                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    try
                    {
                        string view_script = File.ReadAllText(viewPath);

                        SqlCommand createView = new SqlCommand(view_script, connection);

                        connection.Open();

                        createView.ExecuteNonQuery();

                        connection.Close();

                        XmlManager.viewCreated();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("#NoSirveView");
                    }

                }
            }

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
                    insertConnection.CommandText = "INSERT INTO versiones_tbl "+ 
                        "(local_song_id, id3v2_title, id3v2_author, id3v2_lyrics, id3v2_album, id3v2_genre, id3v2_year) "+
                        "output INSERTED.local_version_id VALUES (@lsng_id, @title, @author, @lyrics, @album, @genre, @year)";

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
            catch(Exception e)
            {
                etrace1 = datasong._ID3Lyrics + " "+datasong._ID3Title;
                Console.WriteLine(e);

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
                    createProperty.Parameters.AddWithValue("@lsng_id", local_song_id);
                    createProperty.Parameters.AddWithValue("@sng_name", song_name);

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
            catch(Exception e)
            {
                Console.WriteLine(e);

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
        public static bool addSong2User(string usr_name, DataSong datasong)
        {
            int song_id = createSong(datasong);
            datasong._SongID = song_id.ToString();

            int version_id = createVersion(datasong);
            setVersion2Song(song_id.ToString(), version_id.ToString());

            return createProperty(usr_name, song_id.ToString(), datasong._SongName);
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
                            version.submission_date = reader.GetDateTime(7).ToString();
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
                            dataSong._SubmissionDate = reader.GetDateTime(7).ToString();
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

                    isSync.Parameters.AddWithValue("@id", Convert.ToInt32(song_id));

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

        /// <summary>
        /// Cambia la version de metadata de una canción ya 
        /// existente
        /// </summary>
        /// <param name="dataSong">
        /// Objeto DataSong que contiene el id de la canción y 
        /// la información de la nueva versión
        /// </param>
        /// <returns>
        /// bool que es true si se hace el cambio exitosamente, false 
        /// en cualquier otro caso. 
        /// </returns>
        public static bool setVersion2Song(DataSong dataSong)
        {
            try
            {
                //crea la version a agregar a la canción
                int version_id = createVersion(dataSong);

                return setVersion2Song(dataSong._SongID, version_id.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }
        
        /// <summary>
        /// Actuliza una canción, estableciendole un cloud id
        /// </summary>
        /// <param name="localIdSong">
        /// La canción local que se va a sincronizar
        /// </param>
        /// <param name="syncIdSong">
        /// Id de la cancion en la nube
        /// </param>
        /// <returns>
        /// bool que es true si se termino correctamente la escritura 
        /// del id, false en cualquier otro caso.
        /// </returns>
        public static bool setSyncId2Song(int localIdSong, int syncIdSong)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand insertSong = new SqlCommand();

                    insertSong.CommandType = System.Data.CommandType.Text;
                    insertSong.CommandText = "UPDATE canciones_tbl "
                        + "SET cloud_song_id = @syncId "
                        + "WHERE local_song_id = @localId";

                    insertSong.Parameters.AddWithValue("@localId", localIdSong);
                    insertSong.Parameters.AddWithValue("@syncId", syncIdSong);

                    insertSong.Connection = connection;

                    connection.Open();

                    insertSong.ExecuteNonQuery();

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
        /// Establece los id de la nube, una vez que son sincronizados.
        /// </summary>
        /// <param name="local_version_id">
        /// id de version local
        /// </param>
        /// <param name="cloud_version_id">
        /// id de version en la nube
        /// </param>
        /// <param name="cloud_song_id">
        /// id de la cancion en la nube
        /// </param>
        /// <returns></returns>
        public static bool setSyncIdVersion(int local_version_id, int cloud_version_id, int cloud_song_id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand updateVersion = new SqlCommand();

                    updateVersion.CommandType = System.Data.CommandType.Text;
                    updateVersion.CommandText = "UPDATE versiones_tbl "
                        + "SET cloud_song_id = @syncSongId, cloud_version_id = @syncVersionId"
                        + "WHERE local_version_id = @localId";

                    updateVersion.Parameters.AddWithValue("@syncSongId", cloud_song_id);
                    updateVersion.Parameters.AddWithValue("@syncVersionId", cloud_version_id);

                    updateVersion.Connection = connection;

                    connection.Open();

                    updateVersion.ExecuteNonQuery();

                    connection.Close();
                }

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Obtiene la información necessario para subir 
        /// una version a la nube
        /// </summary>
        /// <param name="local_song_id">
        /// identificador de la version
        /// </param>
        /// <returns>
        /// objeto Version que contiene la información importante sobre 
        /// la version, si viene vacia, algo salio mal con la obtencion 
        /// de la información.
        /// </returns>
        public static Version getVersion(int local_song_id)
        {
            Version version = new Version();

            try
            {
                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand versionSongs = new SqlCommand();

                    versionSongs.CommandType = System.Data.CommandType.Text;

                    versionSongs.CommandText = "SELECT V.id3v2_title, V.id3v2_author, V.id3v2_lyrics, V.id3v2_album, V.id3v2_genre, V.id3v2_year, V.submission_date, V.local_version_id "
                        + "FROM canciones_tbl AS C JOIN versiones_tbl AS V ON C.metadata_id = V.local_version_id"
                        + "WHERE V.local_song_id = @lc_sng_id";

                    versionSongs.Parameters.AddWithValue("@lc_sng_id", local_song_id);

                    versionSongs.Connection = connection;

                    connection.Open();

                    SqlDataReader reader = versionSongs.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            version.id3v2_title = reader.GetString(1);
                            version.id3v2_author = reader.GetString(2);
                            version.id3v2_lyrics = reader.GetString(3);
                            version.id3v2_album = reader.GetString(4);
                            version.id3v2_genre = reader.GetString(5);
                            version.id3v2_year = reader.GetInt32(6);
                            version.submission_date = reader.GetDateTime(7).ToString();
                            version.version_id = reader.GetInt32(8);
                        }

                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return version;
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="local_song_id"></param>
        /// <returns></returns>
        public static string getSongDirectoryFromASong(int local_song_id)
        {
            string songDirectory = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand songDirectoryQuery = new SqlCommand();

                    songDirectoryQuery.CommandType = System.Data.CommandType.Text;

                    songDirectoryQuery.CommandText = "SELECT song_directory"
                        + "FROM canciones_tbl WHERE local_song_id = @locSngId";

                    songDirectoryQuery.Parameters.AddWithValue("@locSngId", local_song_id);

                    songDirectoryQuery.Connection = connection;

                    connection.Open();

                    SqlDataReader reader = songDirectoryQuery.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            songDirectory = reader.GetString(1);
                        }
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return songDirectory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_name">
        /// </param>
        /// <param name="local_song_id">
        /// </param>
        /// <returns>
        /// </returns>
        public static string getSongName(string user_name, int local_song_id)
        {
            string songName = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(databaseConn))
                {
                    SqlCommand getSongName = new SqlCommand();

                    getSongName.CommandType = System.Data.CommandType.Text;

                    getSongName.CommandText = "SELECT song_name "
                        + "FROM propiedades_tbl "
                        + "WHERE usr_name = @usrName AND local_song_id = @lcSongId";

                    getSongName.Parameters.AddWithValue("@usrName", user_name);

                    getSongName.Parameters.AddWithValue("@lcSongId", local_song_id);

                    getSongName.Connection = connection;

                    connection.Open();

                    SqlDataReader reader = getSongName.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            songName = reader.GetString(1);
                        }

                    }

                    reader.Close();
                    connection.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return songName;
        }


    }

}
