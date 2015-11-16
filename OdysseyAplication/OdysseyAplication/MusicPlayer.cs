using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdysseyAplication
{
    interface MusicPlayer
    {
        void playSong();
        void stopSong();
        void pauseSong();
        void setSong(string pSongDirectory);
    }
}
