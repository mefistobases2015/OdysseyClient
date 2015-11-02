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
        public async Task<List<Metadata>> getSongsByUserInCloud(string pUserName)
        {
            List<Metadata> result;
            RestTools rtop = new RestTools();
            result = await rtop.getMetadataSongByUser(pUserName);
            return result;
        }

        public async Task<List<Metadata>> getSongsByUserInLocal(string pUserName)
        {
            List<Metadata> result;
            RestTools rtop = new RestTools();
            result = await rtop.getMetadataSongByUser(pUserName);
            return result;
        }

        public void createMetadataVersionLocal(Metadata pMetadataVersion)
        {
            TagManager tmop = new TagManager();
            tmop.setID3(pMetadataVersion);
        }
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
        public async void createMetadataVersionCloud(Metadata pMetadataVersion)
        {
            RestTools rtop = new RestTools();
            Song songop = await rtop.createVersion(pMetadataVersion);
        }
        public List< string > getFriendByUser(string pUsername)
        {
            return null;
        }
        public List< string > getFriendRequestByUser(string pUserName)
        {
            return null;
        }
        public List< string > searchUsers(string pNameKey)
        {
            return null;
        }
        public bool registerUser(string pUserName, string pName)
        {
            return true;
        }

        public void addMetadataVersion(int pID, List<string> pMetadata)
        {
            throw new NotImplementedException();
        }

        public bool verifyUser(string pUserName, string pPassword)
        {
            return true;
        }
        public List< string > getSongComments(int pSongID)
        {
            return null;
        }
        public int getSongReproductions(int pSongID)
        {
            return 0;
        }
        public int getLikeBySong(string pSongID)
        {
            return 0;
        }
        public int getDislikeBySong(string pSongID)
        {
            return 0;
        }
        public int getVisualization(int pSongID)
        {
            return 3;
        }
        public bool hasuserLikes(string pUserName, int pSongID)
        {
            return true;
        }
        public bool hasUserDislike(string pUserName, int pSongID)
        {
            return true;
        }
        public bool makeLike(int pUserID)
        {
            return true;
        }
        public bool makeDislike(int pUserID)
        {
            return false;
        }
    }
}