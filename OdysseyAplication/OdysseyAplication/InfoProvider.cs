﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdysseyAplication
{
    class InfoProvider
    {
        public async Task<string> getUserSocialStatus (string pUsername)
        {
            RestTools rt = new RestTools();
            return await rt.getSocialByUserName(pUsername);
        }
        public async Task<string> getUserClasificationByFriends(string pUsername)
        {
            RestTools rt = new RestTools();
            return (await rt.getMusicalByFriends(pUsername));
        }
        public async Task<string> getUserClasificationByLibrary(string pUsername)
        {
            RestTools rt = new RestTools();
            return (await rt.getGenreClasification(pUsername));
        }
        public List<DataSong> getID3ByDirectory(List<string> pPatchs)
        {
            List<DataSong> id3Collection = new List<DataSong>();
            TagManager tmop = new TagManager();
            foreach (string directory in pPatchs)
            {
                id3Collection.Add(tmop.getID3ByDirectory(directory));
            }
            return id3Collection;
        }
        //listo
        public async Task<List<DataSong>> getSongsByUserInCloud(string pUserName)
        {
            List<DataSong> result;
            RestTools rtop = new RestTools();
            result = await rtop.getMetadataSongByUser(pUserName);
            return result;
        }
        //listo
        public List<DataSong> getSongsByUserInLocal(string pUserName)
        {
            List<DataSong> result = null;
            return result;
        }
        //listo
        public void createDataSongVersionLocal(DataSong pDataSongVersion)
        {
            TagManager tmop = new TagManager();
            tmop.setID3(pDataSongVersion);
        }
        //listo
        public async void createSong(DataSong pDataSongInitial)
        {
            RestTools rtop = new RestTools();
            Song songop = await rtop.createSong(pDataSongInitial._SongDirectory);
            if (songop == null)
            {
                Console.WriteLine("Canción No Fue Creada");
            }
            else
            {
                pDataSongInitial._SongID = songop.song_id.ToString();
                Song songtop = await rtop.createVersion(pDataSongInitial);
                if (songtop == null)
                {
                }
                else
                {
                    Console.WriteLine("Primera NO FUE Versión Creada");
                }
            }
        }
        //listo
        public async void createDataSongVersionCloud(DataSong pDataSongVersion)
        {
            RestTools rtop = new RestTools();
            Song songop = await rtop.createVersion(pDataSongVersion);
        }

        /// <summary>
        /// Carga una cancion en el blob
        /// </summary>
        /// <param name="pSongID">
        /// Id de la canción a subir
        /// </param>
        /// <param name="pSongPath">
        /// Dirección de la canción a subir
        /// </param>
        /// <returns>
        /// bool que es true si la canción se sube correctamente
        /// </returns>
        public bool uploadSong(int pSongID, string pSongPath)
        {
            BlobManager bm = new BlobManager();

            return bm.uploadSong(pSongID, pSongPath);

        }

        /// <summary>
        /// Descarga una canción
        /// </summary>
        /// <param name="pSongID">
        /// Id de la canción a descargar
        /// </param>
        /// <param name="pSongName">
        /// Nombre de la canción a descargar 
        /// </param>
        /// <param name="pDestinyPath">
        /// Destino de la descarga
        /// </param>
        /// <returns>
        /// bool que es true si se descarga correctamente.
        /// </returns>
        public bool donwloadSong(string pSongID, string pSongName, string pDestinyPath)
        {
            BlobManager bm = new BlobManager();

            return bm.downloadSong(Convert.ToInt32(pSongID), pSongName);
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
        public async Task<List<string>> getFriendByUser(string pUsername)
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
        public async Task<List<string>> getFriendRequestByUser(string pUserName)
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
        public async Task<List<string>> searchUsers(string pNameKey)
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

        //falta, no se que hace
        public void addDataSongVersion(int pID, List<string> pDataSong)
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
        public async Task<List<Comment>> getSongComments(string pSongID)
        {

            int song_id = Convert.ToInt32(pSongID);

            RestTools rt = new RestTools();

            List<Comment> list = await rt.getSongComments(song_id);

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

        /// <summary>
        /// Obtiene todas las versiones de metadata de
        /// una cación
        /// </summary>
        /// <param name="pSongID">
        /// id de la canción de la que se obtienen metadatas
        /// </param>
        /// <returns>
        /// lista de metadatas
        /// </returns>
        public async Task<List<Version>> getListOfDataSong(string pSongID)
        {
            int song_id = Convert.ToInt32(pSongID);

            RestTools rt = new RestTools();

            return await rt.getVersionOfSong(song_id);
        }

        /// <summary>
        /// Crea un comentario en una canción
        /// </summary>
        /// <param name="pSongID">
        /// Identificador de la canción a la que 
        /// se le va a hacer un comentario
        /// </param>
        /// <param name="pUsrName">
        /// Nombre del usaurio que hace el comentario
        /// </param>
        /// <param name="pComment">
        /// Comentraio 
        /// </param>
        /// <returns>
        /// bool que es true si se logra hacer el comentario con exito
        /// en cualquier otro caso false.
        /// </returns>
        public async Task<bool> setComent(string pSongID, string pUsrName, string pComment)
        {
            RestTools rt = new RestTools();

            int song_id = Convert.ToInt32(pSongID);

            return await rt.setComment2ASong(song_id, pUsrName, pComment);
        }

        /// <summary>
        /// Obtiene las reconmendaciones de amigos 
        /// </summary>
        /// <param name="usr_name">
        /// Usuario a l que se le hacen recomendaciones
        /// </param>
        /// <returns>
        /// Lista de string donde estan las recomendaciones.
        /// </returns>
        public async Task<List<string>> getRecomendations(string usr_name)
        {
            RestTools rt = new RestTools();

            return await rt.getRecomendedFriends(usr_name);
        }

        public async Task<List<string>> getRecomendatedSongs(string pUserName)
        {
            RestTools rtop = new RestTools();
            return await rtop.getRecomendedFriends(pUserName);
        }

        public async Task<bool> acceptFriendRequest(string pUserSigned, string pUser)
        {
            RestTools rtop = new RestTools();
            return await rtop.addFriendByUserName(pUserSigned, pUser) && await rtop.deleteRequest(pUser, pUserSigned);
        }
        public async Task<bool> declineFriendRequest(string pUserSigned, string pUser)
        {
            RestTools rtop = new RestTools();
            return await rtop.deleteRequest(pUser, pUserSigned);
        }
        public async Task<List<TopUser>> getTopUsers()
        {
            RestTools rtop = new RestTools();
            return await rtop.getTopUsers();
        }

        /// <summary>
        /// Poularidad 
        /// </summary>
        /// <param name="pUserName">
        /// </param>
        /// <returns>
        /// </returns>
        public async Task<string> getUserSocialRanking(string pUserName)
        {
            RestTools rtop = new RestTools();
            int popularity = await rtop.getPopularityByComments(pUserName);
            return popularity.ToString();
        }

        /// <summary>
        /// Agreaga una canción a un usuario
        /// </summary>
        /// <param name="pUserName">
        /// Nomre del usuario al que se le agregan canciones
        /// </param>
        /// <param name="pSongsNames">
        /// Lista con los nombre de las canciones
        /// </param>
        /// <param name="pMetadatas">
        /// Lista con los metadatos de las canciones
        /// </param>
        /// <returns>
        /// bool que es true si se logran agregar todas las canciones.
        /// </returns>
        public bool addSong2User(string pUserName, List<string> pSongsNames, List<DataSong> pMetadatas)
        {
            //si no es la misma cantidad de valores en las listas
            if (!(pSongsNames.Count == pMetadatas.Count))
            {
                Console.WriteLine("#NoHayLaMismaCantidadEnListas");
                return false;
            }
            else
            {
                //si una lista no tiene elementos
                if(pSongsNames.Count < 1 || pMetadatas.Count < 1)
                {
                    Console.WriteLine("#NoHayDatosEnUnaDeLasListasOAmbas");
                    return false;
                }
                else
                {

                    for(int i = 0; i < pMetadatas.Count; i++)
                    {
                        bool state = DatabaseManager.addSong2User(pUserName, pSongsNames[i], pMetadatas[i]);
                        if (!state)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }

        /// <summary>
        /// Verifica si un usuario es amigo del otro
        /// </summary>
        /// <param name="pUserName">
        /// Nombre de usuario al que se le va a verificar amigo
        /// </param>
        /// <param name="pFriendName">
        /// Nombre de usurio que se va a ver si es amigo del otor usuario
        /// </param>
        /// <returns>
        /// bool que es true si son amigos, en otro caso false.
        /// </returns>
        public async Task<bool> areFriends(string pUserName, string pFriendName)
        {

            RestTools rt = new RestTools();

            List<string> friends = await rt.getFriends(pUserName);

            for (int i = 0; i < friends.Count; i++)
            {
                if(friends[i].CompareTo(pFriendName) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Agrega una version nueva a una canción ya creada.
        /// </summary>
        /// <param name="dataSong">
        /// Objeto DataSong que cnotiene la información 
        /// de la version
        /// </param>
        public void setVersion2Song(DataSong dataSong)
        {
            DatabaseManager.setVersion2Song(dataSong);
        }

        /// <summary>
        /// Cambia el estado de un usuario
        /// </summary>
        /// <param name="connectedStatus">
        /// Estado nuevo que se va a colocar para el usuario
        /// </param>
        /// <returns>
        /// bool que es true si se logra la accion por completo, 
        /// false en cualquier otro caso.
        /// </returns>
        public async Task<bool> setConnectedState(string userName, bool connectedStatus)
        {
            RestTools rt = new RestTools();

            return await rt.setConnectedState(connectedStatus, userName);
        }

        public void uploadSong(string user_name)
        {
            List<DataSong> datasongs = DatabaseManager.getSongsOfUser(user_name);

            for (int i = 0; i < datasongs.Count; i++)
            {

            }

        }

        public void downloadDatabase()
        {

        }

    }
}