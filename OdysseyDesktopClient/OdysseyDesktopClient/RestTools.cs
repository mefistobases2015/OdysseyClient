using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace OdysseyDesktopClient
{
    class RestTools
    {
        private string server_url = "http://odysseyop.azurewebsites.net/";
        private string format = "application/json";

        private string credentials_path = "api/Credenciales";
        private string songs_path = "api/Canciones";
        private string versions_path = "api/Versiones";
        private string properties_path = "api/Propiedades";
        private string songs_by_user_path = "api/CancionesUsuario";
        private const string mongo_songs_path = "api/CancionesMongo";
        private const string friend_request_path = "api/Solicitud";
        private const string mongo_users_path = "api/Usuarios";

        /**
         *Constructor vacío
         */
        public RestTools()
        {
            //constructor vacion con valores default
        }

        public RestTools(string p_server_url)
        {
            this.server_url = p_server_url;
        }

        public void setFormat(string p_format)
        {
            format = p_format;
        }

        public async Task<bool> isUser(string usr_name)
        {
            bool flag = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.GetAsync(credentials_path + "/" + usr_name);

                if (response.IsSuccessStatusCode)
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("\nCodigo de error {0}", response.StatusCode);
                    flag = false;
                }
            }
            return flag;

        }

        public async Task<bool> isPassword(string usr_name, string password)
        {
            bool flag = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.GetAsync(credentials_path + "/" + usr_name);

                if (response.IsSuccessStatusCode)
                {
                    Credential cred = await response.Content.ReadAsAsync<Credential>();

                    string repassword = cred.pass;

                    if (repassword.CompareTo(password) == 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }

                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }

        public async Task<bool> createUser(string p_usr_name, string p_pass)
        {
            bool flag = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                Credential cred = new Credential() { user_name = p_usr_name, pass = p_pass };

                HttpResponseMessage response = await client.PostAsJsonAsync(credentials_path, cred);

                if (response.IsSuccessStatusCode)
                {
                    //Console.WriteLine("Sirvio el post :-D");
                    flag = true;
                }
                else
                {
                    //Console.WriteLine("No sirvio el post D-: {0}", response.StatusCode);
                    flag = false;
                }
            }

            return flag;

        }

        public async Task<Song> createSong(string p_song_directory)
        {

            Song result= new Song();

            Song song = new Song() { song_id = -1, metadata_id = -1, song_directory = p_song_directory };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PostAsJsonAsync(songs_path, song);

                if (response.IsSuccessStatusCode)
                {

                    result = await response.Content.ReadAsAsync<Song>();

                    Console.WriteLine("\nId de la cancion {0}", result.song_id);

                    /*Uri uri = response.Headers.Location;

                    HttpResponseMessage response2 = await client.GetAsync(uri);

                    result = await response2.Content.ReadAsAsync<Song>();*/

                }
                else
                {
                    result = null;
                    Console.WriteLine("\nCodigo de error {0}", response.StatusCode);
                }
            }

            return result;
        }

        public async Task<Song> createVersion(List<string> new_version, string p_song_directory)
        {

            Song song = await createSong(p_song_directory);

            Version ver = new Version(new_version, song.song_id);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PostAsJsonAsync(versions_path, ver);

                if (response.IsSuccessStatusCode)
                {

                    ver = await response.Content.ReadAsAsync<Version>();

                    song.metadata_id = ver.version_id;

                    HttpResponseMessage updsng = await client.PutAsJsonAsync<Song>(songs_path + "/" + song.song_id, song);

                    if (updsng.IsSuccessStatusCode)
                    {
                        song = await updsng.Content.ReadAsAsync<Song>();
                        Console.WriteLine("\nSe creo correctamente, metadata_id {0}", song.metadata_id);
                    }

                    else
                    {
                        song = null;
                        Console.WriteLine("\nError {0}", updsng.StatusCode);
                    }
                }
                else
                {
                    song = null;
                }
            }

            return song;

        }

        public async Task<Song> createVersion(List<string> new_version, Song song)
        {
            Version ver = new Version(new_version, song.song_id);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PostAsJsonAsync(versions_path, ver);

                if (response.IsSuccessStatusCode)
                {

                    ver = await response.Content.ReadAsAsync<Version>();

                    song.metadata_id = ver.version_id;

                    HttpResponseMessage updsng = await client.PutAsJsonAsync<Song>(songs_path + "/" + song.song_id, song);

                    if (updsng.IsSuccessStatusCode)
                    {
                        Console.WriteLine("\nSe creo correctamente, metadata_id {0}", song.metadata_id);
                    }
                    else
                    {
                        song = null;
                        Console.WriteLine("\nError {0}", updsng.StatusCode);
                    }
                }
                else
                {
                    song = null;
                }
            }

            return song;
        }

        public async Task<Song> createVersion(Metadata met)
        {
            Song song;

            Version ver = new Version(met);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PostAsJsonAsync(versions_path, ver);

                if (response.IsSuccessStatusCode)
                {
                    ver = await response.Content.ReadAsAsync<Version>();

                    song = await getSongById(Convert.ToInt32(met._SongID));

                    song.metadata_id = ver.version_id;

                    HttpResponseMessage updsng = await client.PutAsJsonAsync<Song>(songs_path + "/" + song.song_id, song);

                    if (updsng.IsSuccessStatusCode)
                    {
                        Console.WriteLine("\nSe creo correctamente, metadata_id {0}", song.metadata_id);
                    }
                    else
                    {
                        song = null;
                        Console.WriteLine("\nError {0}", updsng.StatusCode);
                    }
                }
                else
                {
                    song = null;
                }

                return song;
            }
        }

        public async Task<bool> addSong2user(string p_user_name, string p_song_name,
            List<string> new_version, string p_song_directory) 
        {
            bool flag = false;

            Song song = await createVersion(new_version, p_song_directory);

            Property prop = new Property() { user_name = p_user_name, song_name = p_song_name, song_id = song.song_id };

            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PostAsJsonAsync<Property>(properties_path, prop);

                if (response.IsSuccessStatusCode)
                {
                    flag = true;
                    Console.WriteLine("\nSe agrego bien la cancion");
                }
                else
                {
                    flag = false;
                    Console.WriteLine("\nEl codigo de error: {0}", response.StatusCode);
                }
            }

            return flag;
        }

        public async Task<bool> addSong2user(string p_user_name, string p_song_name, Song song)
        {
            bool flag = false;

            Property prop = new Property() { user_name = p_user_name, song_name = p_song_name, song_id = song.song_id };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PostAsJsonAsync<Property>(properties_path, prop);

                if (response.IsSuccessStatusCode)
                {
                    flag = true;
                    Console.WriteLine("\nSe agrego bien la cancion");
                }
                else
                {
                    flag = false;
                    Console.WriteLine("\nEl codigo de error: {0}", response.StatusCode);
                }
            }

            return flag;
        }

        public async Task<bool> setMetadataSong(int p_song_id, int p_version_id) 
        {
            bool flag = false;

            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage song_res = await client.GetAsync(songs_path);

                Song song = await song_res.Content.ReadAsAsync<Song>();

                HttpResponseMessage ver_res = await client.GetAsync(versions_path);

                Version ver = await ver_res.Content.ReadAsAsync<Version>();

                song.metadata_id = ver.version_id;

                HttpResponseMessage sng_upd = await client.PutAsJsonAsync<Song>(songs_path + "/" + song.song_id, song);

                if (sng_upd.IsSuccessStatusCode)
                {
                    flag = true;
                    Console.WriteLine("\nSe agrego bien la cancion");
                }
                else
                {
                    flag = false;
                    Console.WriteLine("\nEl codigo de error: {0}", sng_upd.StatusCode);
                }
            }

            return flag;
        }

        public async Task<Song> getSongById(int p_song_id)
        {
            Song song = new Song();

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.GetAsync(songs_path + "/" + p_song_id);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nHubo ok con el server");
                    song = await response.Content.ReadAsAsync<Song>();
                }
                else
                {
                    Console.WriteLine("\nAlgo salio mal D-: codigo {0}", response.StatusCode);
                    song = null;
                }
            }

            return song;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        /// 

        public async Task<List<Metadata>> getMetadataSongByUser(string user_name)
        {
            List<Metadata> songs_metadata = new List<Metadata>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.GetAsync(songs_by_user_path + "/" + user_name);

                MetadataAndSong[] sngs_n_met = await response.Content.ReadAsAsync<MetadataAndSong[]>();

                for (int i = 0; i < sngs_n_met.Length; i++)
                {
                    Metadata song_met = new Metadata();

                    song_met._ID3Artist = (sngs_n_met[i].id3v2_author);

                    song_met._ID3Title = (sngs_n_met[i].id3v2_title);
                    song_met._ID3Album = (sngs_n_met[i].id3v2_album);
                    song_met._ID3Year = (sngs_n_met[i].year.ToString());
                    song_met._ID3Genre = (sngs_n_met[i].id3v2_genre);
                    song_met._ID3Lyrics = (sngs_n_met[i].id3v2_lyrics);
                    song_met._SongID = (sngs_n_met[i].song_id.ToString());
                    song_met._ID3Title = (sngs_n_met[i].song_name);
                    song_met._SongDirectory = (sngs_n_met[i].song_directory);
                    song_met._SubmissionDate = (sngs_n_met[i].submission_date);
                    songs_metadata.Add(song_met);
                }
            }
            return songs_metadata;

        }
        public async Task<string> getMusicalByUserName(string usr_id)
        {
            string res = "";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.GetAsync(mongo_users_path + "/Musical?id=" + usr_id);

                if (response.IsSuccessStatusCode)
                {
                    res = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    res = "";
                }
            }

            return res;
        }

        public async Task<string> getSocialByUserName(string usr_name)
        {
            string res = "";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.GetAsync(mongo_users_path + "/Musical?id=" + usr_name);

                if (response.IsSuccessStatusCode)
                {
                    res = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine("Codigo de respuesta {0}", response.StatusCode);
                    res = "";
                }
            }

            return res;
        }

        public async Task<bool> addFriendByUserName(string usr_name, string friend_usr_name)
        {
            bool res_status = false;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PutAsJsonAsync<string>(mongo_users_path + "/Amigos?id=" + usr_name,
                    friend_usr_name);

                if (response.IsSuccessStatusCode)
                {
                    res_status = true;
                }
                else
                {
                    res_status = false;
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                }
            }

            return res_status;
        }

        public async Task<bool> setLike2ASong(int song_id)
        {
            bool result = false;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PutAsJsonAsync<String>(mongo_songs_path + "/Like?id=" + song_id.ToString(),
                    "");

                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    result = false;
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                }
            }

            return result;
        }

        public async Task<bool> setDislike2ASong(int song_id)
        {
            bool result = false;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PutAsJsonAsync<String>(mongo_songs_path + "/Dislike?id=" + song_id.ToString(),
                    "");

                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    result = false;
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                }
            }

            return result;
        }

        public async Task<bool> setPlay2ASong(int song_id)
        {
            bool result = false;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PutAsJsonAsync<String>(mongo_songs_path + "/Play?id=" + song_id.ToString(),
                    "");

                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    result = false;
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                }
            }

            return result;
        }

        public async Task<bool> setComment2ASong(int song_id, string usr_name, string p_comment)
        {
            bool result = false;

            Comment comm = new Comment() { author = usr_name, comment = p_comment };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PutAsJsonAsync<Comment>(mongo_songs_path + "/Comment?id=" + song_id.ToString(),
                    comm);

                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    result = false;
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                }
            }

            return result;
        }

        public async Task<int> getSongLikes(int song_id)
        {
            int result = 0;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.GetAsync(mongo_songs_path + "/Like?id=" + song_id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    result = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    result = -1;
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                }

                return result;
            }

        }

        public async Task<int> getSongDislkes(int song_id)
        {
            int result = 0;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.GetAsync(mongo_songs_path + "/Dislike?id=" + song_id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    result = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    result = -1;
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                }

                return result;
            }
        }

        public async Task<int> getSongPlays(int song_id)
        {
            int result = 0;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.GetAsync(mongo_songs_path + "/Play?id=" + song_id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    result = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    result = -1;
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                }
            }

            return result;
        }

        public async Task<int> getSongComments(int song_id)
        {
            int result = 0;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.GetAsync(mongo_songs_path + "/Comment?id=" + song_id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    result = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    result = -1;
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                }
            }

            return result;
        }

        public async Task<List<Solicitud>> getRequests(string usr_name)
        {
            List<Solicitud> requests = new List<Solicitud>();

            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.GetAsync(friend_request_path+"/"+usr_name);

                if (response.IsSuccessStatusCode)
                {
                    Solicitud[] requests_array = await response.Content.ReadAsAsync<Solicitud[]>();

                    for(int i = 0; i < requests_array.Length; i++)
                    {
                        requests.Add(requests_array[i]);
                    }
                }
                else
                {
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                }
            }

            return requests;
        } 

        public async Task<bool> setRequest(string p_emisor, string p_receptor)
        {
            bool result = false;

            Solicitud request = new Solicitud() { emisor = p_emisor, receptor = p_receptor };

            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PostAsJsonAsync<Solicitud>(friend_request_path, request);

                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                    result = false;
                }
            }

            return result;
        }

        public async Task<bool> deleteRequest(string p_emisor, string p_receptor)
        {
            bool result = false;

            Solicitud request = new Solicitud() { emisor = p_emisor, receptor = p_receptor };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

                HttpResponseMessage response = await client.PutAsJsonAsync(friend_request_path, request);

                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    Console.WriteLine("Status Code {0}", response.StatusCode);
                    result = false;
                }
            }

            return result;
        }

    }
}
