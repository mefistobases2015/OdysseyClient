using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace OdysseyAplication
{
    /// <summary>
    /// Maneja las operaciones relacionadas al Blob donde
    /// se almacenan las canciones.
    /// </summary>
    class BlobManager
    {
        /// <summary>
        /// Nombre de usuario con el que se entra al BLOB
        /// </summary>
        private  string accountName = XmlManager.getBlobUserAccount();
        /// <summary>
        /// Key con la que se entra al BLOB manager
        /// </summary>
        private  string accountKey = XmlManager.getBlobKeyAccount();

        /// <summary>
        /// Descarga una canción
        /// </summary>
        private string dnwloadPath = System.Environment.GetEnvironmentVariable("USERPROFILE")+"\\Music\\OdysseyMusic";

        /// <summary>
        /// Carga una canción
        /// </summary>
        /// <param name="song_id">
        /// Id de la canción
        /// </param>
        /// <param name="song_path">
        /// Direncción de carga de la canción
        /// </param>
        /// <returns>
        /// bool que es true si se logra subir, false 
        /// en cualqueir otro caso
        /// </returns>
        public bool uploadSong(int song_id, string song_path)
        {
            bool flag = false;

            //hace la cuenta
            StorageCredentials creds = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);

            //crea el cliente
            CloudBlobClient client = account.CreateCloudBlobClient();

            //crae el contenedor
            CloudBlobContainer container = client.GetContainerReference("music");
            container.CreateIfNotExists();
            //
            CloudBlockBlob blob = container.GetBlockBlobReference(song_id.ToString() + ".mp3");
            using (System.IO.Stream file = System.IO.File.OpenRead(song_path))
            {
                try
                {
                    blob.UploadFromStream(file);
                    flag = true;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    flag = false;
                }

            }

            return flag;
        }

        /// <summary>
        /// Descarga una canción
        /// </summary>
        /// <param name="song_id">
        /// id de la canción
        /// </param>
        /// <param name="song_name">
        /// nombre del archivo de la canción
        /// </param>
        /// <returns>
        /// retorna true si logra descargarla, false en cualquier otro caso
        /// </returns>
        public bool downloadSong(int song_id, string song_name)
        {
            bool flag = false;

            //hace la cuenta
            StorageCredentials creds = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);

            //crea el cliente
            CloudBlobClient client = account.CreateCloudBlobClient();

            //crae el contenedor
            CloudBlobContainer sampleContainer = client.GetContainerReference("music");

            CloudBlockBlob blob = sampleContainer.GetBlockBlobReference(song_id.ToString() + ".mp3");



            try
            {
                //FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.AllAccess, "C:\\Users\\Andres\\Music");
                Console.WriteLine("Path: {0}", dnwloadPath + "\\" + song_name);
                Stream outputFile = new FileStream(dnwloadPath + "\\" + song_name, FileMode.Create);

                blob.DownloadToStream(outputFile);
                flag = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                flag = false;
            }

            return flag;
        }


    }
}
