using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdysseyDesktopClient
{
    class InfoProvider
    {
        //listo
        public List< Metadata > getID3ByDirectory(List< string > pPatchs)
        {
            List<Metadata> id3Collection = new List<Metadata>();
            TagManager tmop = new TagManager();
            foreach(string directory in pPatchs)
            {
                id3Collection.Add(tmop.getID3ByDirectory(directory));
            }
            return id3Collection;
        }
        //listo
        public async Task<List<Metadata>> getSongsByUserInCloud(string pUserName)
        {
            List<Metadata> result;
            RestTools rtop = new RestTools();
            result = await rtop.getMetadataSongByUser(pUserName);
            return result;
        }
        //listo
        public async Task<List<Metadata>> getSongsByUserInLocal(string pUserName)
        {
            List<Metadata> result;
            RestTools rtop = new RestTools();
            result = await rtop.getMetadataSongByUser(pUserName);
            return result;
        }
        //listo
        public void createMetadataVersionLocal(Metadata pMetadataVersion)
        {
            TagManager tmop = new TagManager();
            tmop.setID3(pMetadataVersion);
        }
        //listo
        public async void createSong(Metadata pMetadataInitial)
        {
            RestTools rtop = new RestTools();
            Song songop = await rtop.createSong(pMetadataInitial._SongDirectory);
            if(songop == null)
            {
                Console.WriteLine("Canción No Fue Creada");
            }
            else
            {
                pMetadataInitial._SongID = songop.song_id.ToString();
                Song songtop = await rtop.createVersion(pMetadataInitial);
                if(songtop == null)
                {
                    MessageBox.Show(("Primera Versión Creada"));
                }
                else
                {
                    Console.WriteLine("Primera NO FUE Versión Creada");
                }
            }
        }
        //listo
        public async void createMetadataVersionCloud(Metadata pMetadataVersion)
        {
            RestTools rtop = new RestTools();
            Song songop = await rtop.createVersion(pMetadataVersion);
        }

        /// <summary>
        /// Busca los amigos de un usuario
        /// </summary>
        /// <param name="pUsername">
        /// Nombre de usuario al que se le van a buscar 
        /// los amigos
        /// </param>
        /// <returns>
        /// Lista de string que tiene los nombres 
        /// de los amigos
        /// </returns>
        public async Task <List< string >>  getFriendByUser(string pUsername)
        {
            List<string> friends = new List<string>();

            RestTools rt = new RestTools();

            friends = await rt.getFriends(pUsername);

            return friends;
        }

        /// <summary>
        /// Obtiene la los usuarios que han enviado solicitudes
        /// de amistad 
        /// </summary>
        /// <param name="pUserName">
        /// Nombre de usuario que tiene las solicitudes
        /// </param>
        /// <returns>
        /// Lista de nombres de usuarioss que han enviado solicitud
        /// </returns>
        public async Task<List< string >> getFriendRequestByUser(string pUserName)
        {

            List<string> friend_request = new List<string>();

            RestTools rt = new RestTools();

            friend_request = await rt.getRequests(pUserName);

            return friend_request;
        }

        /// <summary>
        /// Busca usuarios en la base de datos por partes 
        /// de su nombre
        /// </summary>
        /// <param name="pNameKey">
        /// nombre del usuario que se anda buscando
        /// </param>
        /// <returns>
        /// Retorna lisa de posibles usuarios
        /// </returns>
        public async Task<List< string >> searchUsers(string pNameKey)
        {
            List<string> srch_us = new List<string>();

            RestTools rt = new RestTools();

            srch_us = await rt.searchUsers(pNameKey);

            return srch_us;
        }

        /// <summary>
        /// Registra un nuevo usuario
        /// </summary>
        /// <param name="pUserName">
        /// Nombre del usuario
        /// </param>
        /// <param name="pName">
        /// Contraseña del usuario
        /// </param>
        /// <returns>
        /// bool que es true cuando se completa la acción
        /// de crear un usuario, false en cualquier otro
        /// caso.
        /// </returns>
        public async Task<bool> registerUser(string pUserName, string pName)
        {
            RestTools rt = new RestTools();

            return await rt.createUser(pUserName, pName);
        }

        public void addMetadataVersion(int pID, List<string> pMetadata)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica el password con un nombre de usuario
        /// </summary>
        /// <param name="pUserName">
        /// Nombre de usuario
        /// </param>
        /// <param name="pPassword">
        /// password a comprobar
        /// </param>
        /// <returns>
        /// true si el password es del usuario, false en cualquier
        /// otro ccaso
        /// </returns>
        public async Task<bool> verifyUser(string pUserName, string pPassword)
        {

            RestTools rt = new RestTools();

            bool result = await rt.isPassword(pUserName, pPassword);

            return result;
        }

        /// <summary>
        /// Obtiene los comentarios de una canción
        /// </summary>
        /// <param name="pSongID">
        /// Identificador de la canción 
        /// </param>
        /// <returns>
        /// lista de string donde tiene el autor y luego el comentario
        /// </returns>
        public async Task< List< string > > getSongComments(string pSongID)
        {

            int song_id = Convert.ToInt32(pSongID);

            RestTools rt = new RestTools();

            List<string> list = await rt.getSongComments(song_id);
            
            return list;
        }

        /// <summary>
        /// Obtiene las veces que una canción ha sido 
        /// reproducida
        /// </summary>
        /// <param name="pSongID">
        /// Identificador de la canción
        /// </param>
        /// <returns>
        /// int con la cantidad de reproducciones de 
        /// una canción
        /// </returns>
        public async Task<int> getSongReproductions(string pSongID)
        {

            RestTools rt = new RestTools();

            int song_id = Convert.ToInt32(pSongID);

            int plays = await rt.getSongPlays(song_id);

            return plays;
        }

        /// <summary>
        /// Suma una reproducción a una canción
        /// </summary>
        /// <param name="pSongID">
        /// Identificador de la canción
        /// </param>
        /// <returns>
        /// return un bool que es true si se logra agregar la reproducción
        /// y false en cualquier otro caso
        /// </returns>
        public async Task<bool> setSongReproduction(string pSongID)
        {
            bool result = false;

            RestTools rt = new RestTools();

            int song_id = Convert.ToInt32(pSongID);

            result = await rt.setPlay2ASong(song_id);

            return result;
        }
        
        public bool hasuserLikes(string pUserName, int pSongID)
        {
            return true;
        }
        public bool hasUserDislike(string pUserName, int pSongID)
        {
            return true;
        }

        /// <summary>
        /// Da un like a una cacion
        /// </summary>
        /// <param name="pSongID">
        /// Identificador de la canción a la que se le va a dar like
        /// </param>
        /// <returns>
        /// bool que es true si se realiza la acción, en cualquier otro caso
        /// retorna false.
        /// </returns>
        public async Task<bool> makeLike(string pSongID)
        {

            RestTools rt = new RestTools();

            bool flag = await rt.setLike2ASong(Convert.ToInt32(pSongID));

            return flag;
        }

        /// <summary>
        /// Da un dislike a una cancion
        /// </summary>
        /// <param name="pSongID">
        /// Identificador de la cancion a darle dislike
        /// </param>
        /// <returns>
        /// retorna true si se realiza la acción, en cualquier otro caso 
        /// retorna false.
        /// </returns>
        public async Task<bool> makeDislike(string pSongID)
        {

            RestTools rt = new RestTools();

            bool flag = await rt.setDislike2ASong(Convert.ToInt32(pSongID));

            return flag;
        }

        /// <summary>
        /// Obtiene la cantidad de likes de una cancion
        /// </summary>
        /// <param name="pSongID">
        /// identificador de la canción a a que se le 
        /// van a obtener los likes
        /// </param>
        /// <returns>
        /// int con la cantidad de likes, en caso de fallo
        /// retorna -1
        /// </returns>
        public async Task<int> getLikeBySong(string pSongID)
        {

            RestTools rt = new RestTools();

            int likes = await rt.getSongLikes(Convert.ToInt32(pSongID));

            return likes;
        }

        /// <summary>
        /// Obtiene la cantidad de dislikes de una cancion
        /// </summary>
        /// <param name="pSongID">
        /// Identificador de la canción a la que se le obtienen
        /// los dislikes
        /// </param>
        /// <returns>
        /// int que es la cantidad de dislikes, en caso de error
        /// retorna -1
        /// </returns>
        public async Task<int> getDislikeBySong(string pSongID)
        {
            RestTools rt = new RestTools();

            int likes = await rt.getSongDisLikes(Convert.ToInt32(pSongID));

            return likes;
        }


    }
}