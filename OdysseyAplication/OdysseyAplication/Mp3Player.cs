using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdysseyAplication
{
    
    class MP3Player
    {
        enum StreamingPlaybackState
        {
            Stopped,
            Playing,
            Paused
        }
        WaveOutEvent _waveOut { get; set; }
        Mp3FileReader _Reader { get; set; }
        public MP3Player()
        {
            this._waveOut = new WaveOutEvent();
        }
        ~MP3Player()
        {
            if(this._Reader != null)
            {
                this._Reader.Dispose();
            }
            this._waveOut.Dispose();
        }
        public void  setSong(string pDirectory)
        {
            if(this._Reader != null)
            {
                this._Reader.Dispose();
            }
            this._Reader = new Mp3FileReader(pDirectory);
            this._waveOut.Init(this._Reader);
        }

        public void playSong()
        {
            if(this._Reader != null)
            {
                this._waveOut.Play();
            }
        }
        public void pauseSong()
        {
            if (this._Reader != null)
            {
                this._waveOut.Pause();
            }
        }
        public void stopSong()
        {
            if (this._Reader != null)
            {
                this._waveOut.Stop();
            }
        }
    }
}
