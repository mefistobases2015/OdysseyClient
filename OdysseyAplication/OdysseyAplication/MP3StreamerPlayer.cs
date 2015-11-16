using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace OdysseyAplication
{
    public partial class MP3StreamerPlayer
    {
        enum StreamingPlaybackState
        {
            Stopped,
            Playing,
            Paused
        }
        static WaveOutEvent _waveOut { get; set; }
        Mp3FileReader _Reader { get; set; }
        public MP3StreamerPlayer()
        {
            //this._waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback());
        }
    }
}
