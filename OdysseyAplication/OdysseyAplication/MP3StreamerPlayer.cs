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
            Buffering,
            Paused
        }

        void OnVolumeSliderChanged(object sender, EventArgs e)
        {
            if (volumeProvider != null)
            {
              //  volumeProvider.Volume = volumeSlider1.Volume;
            }
        }

        private BufferedWaveProvider bufferedWaveProvider;
        private IWavePlayer waveOut;
        private volatile StreamingPlaybackState playbackState;
        private volatile bool fullyDownloaded;
        private HttpWebRequest webRequest;
        private VolumeWaveProvider16 volumeProvider;

        delegate void ShowErrorDelegate(string message);
        

        private void StreamMp3(object state)
        {
            fullyDownloaded = false;
            var url = (string)state;
            webRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status != WebExceptionStatus.RequestCanceled)
                {
                    //ShowError(e.Message);
                }
                return;
            }
            var buffer = new byte[500000 * 4]; // needs to be big enough to hold a decompressed frame

            IMp3FrameDecompressor decompressor = null;
            try
            {
                using (var responseStream = resp.GetResponseStream())
                {
                    var readFullyStream = new ReadFullyStream(responseStream);
                    do
                    {
                        if (IsBufferNearlyFull)
                        {
                            Debug.WriteLine("Buffer getting full, taking a break");
                            Thread.Sleep(500);
                        }
                        else
                        {
                            Mp3Frame frame;
                            try
                            {
                                frame = Mp3Frame.LoadFromStream(readFullyStream);
                            }
                            catch (EndOfStreamException)
                            {
                                fullyDownloaded = true;
                                // reached the end of the MP3 file / stream
                                break;
                            }
                            catch (WebException)
                            {
                                // probably we have aborted download from the GUI thread
                                break;
                            }
                            if (decompressor == null)
                            {
                                // don't think these details matter too much - just help ACM select the right codec
                                // however, the buffered provider doesn't know what sample rate it is working at
                                // until we have a frame
                                decompressor = CreateFrameDecompressor(frame);
                                bufferedWaveProvider = new BufferedWaveProvider(decompressor.OutputFormat);
                                bufferedWaveProvider.BufferDuration = TimeSpan.FromSeconds(20); // allow us to get well ahead of ourselves
                                //this.bufferedWaveProvider.BufferedDuration = 250;
                            }
                            int decompressed = decompressor.DecompressFrame(frame, buffer, 0);
                            //Debug.WriteLine(String.Format("Decompressed a frame {0}", decompressed));
                            bufferedWaveProvider.AddSamples(buffer, 0, decompressed);
                        }

                    } while (playbackState != StreamingPlaybackState.Stopped);
                    Debug.WriteLine("Exiting");
                    // was doing this in a finally block, but for some reason
                    // we are hanging on response stream .Dispose so never get there
                    decompressor.Dispose();
                }
            }
            finally
            {
                if (decompressor != null)
                {
                    decompressor.Dispose();
                }
            }
        }

        public static void PlayMp3FromUrl(string url)
        {
            using (Stream ms = new MemoryStream())
            {
                using (Stream stream = WebRequest.Create(url).GetResponse().GetResponseStream())
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }

                ms.Position = 0;
                using (WaveStream blockAlignedStream =
                    new BlockAlignReductionStream(
                        WaveFormatConversionStream.CreatePcmStream(
                            new Mp3FileReader(ms))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                }
            }
        }
        private static IMp3FrameDecompressor CreateFrameDecompressor(Mp3Frame frame)
        {
            WaveFormat waveFormat = new Mp3WaveFormat(frame.SampleRate, frame.ChannelMode == ChannelMode.Mono ? 1 : 2,
                frame.FrameLength, frame.BitRate);
            return new AcmMp3FrameDecompressor(waveFormat);
        }

        private bool IsBufferNearlyFull
        {
            get
            {
                return bufferedWaveProvider != null &&
                       bufferedWaveProvider.BufferLength - bufferedWaveProvider.BufferedBytes
                       < bufferedWaveProvider.WaveFormat.AverageBytesPerSecond / 4;
            }
        }

        public void play( )
        {
            playbackState = StreamingPlaybackState.Stopped;
            if (playbackState == StreamingPlaybackState.Stopped)
            {
                playbackState = StreamingPlaybackState.Buffering;
                bufferedWaveProvider = null;
                ThreadPool.QueueUserWorkItem(StreamMp3, "https://odysseyblob.blob.core.windows.net/braisman/6.mp3");
            }
            else if (playbackState == StreamingPlaybackState.Paused)
            {
                playbackState = StreamingPlaybackState.Buffering;
            }
        }

        private void StopPlayback()
        {
            if (playbackState != StreamingPlaybackState.Stopped)
            {
                if (!fullyDownloaded)
                {
                    webRequest.Abort();
                }

                playbackState = StreamingPlaybackState.Stopped;
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = null;
                }
                //timer1.Enabled = false;
                // n.b. streaming thread may not yet have exited
                Thread.Sleep(500);
                ShowBufferState(0);
            }
        }

        private void ShowBufferState(double totalSeconds)
        {
            //labelBuffered.Text = String.Format("{0:0.0}s", totalSeconds);
            //progressBarBuffer.Value = (int)(totalSeconds * 1000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (playbackState != StreamingPlaybackState.Stopped)
            {
                if (waveOut == null && bufferedWaveProvider != null)
                {
                    Debug.WriteLine("Creating WaveOut Device");
                    waveOut = CreateWaveOut();
                    waveOut.PlaybackStopped += OnPlaybackStopped;
                    volumeProvider = new VolumeWaveProvider16(bufferedWaveProvider);
                    //volumeProvider.Volume = volumeSlider1.Volume;
                    waveOut.Init(volumeProvider);
                   // progressBarBuffer.Maximum = (int)bufferedWaveProvider.BufferDuration.TotalMilliseconds;
                }
                else if (bufferedWaveProvider != null)
                {
                    var bufferedSeconds = bufferedWaveProvider.BufferedDuration.TotalSeconds;
                    ShowBufferState(bufferedSeconds);
                    // make it stutter less if we buffer up a decent amount before playing
                    if (bufferedSeconds < 0.5 && playbackState == StreamingPlaybackState.Playing && !fullyDownloaded)
                    {
                        Pause();
                    }
                    else if (bufferedSeconds > 4 && playbackState == StreamingPlaybackState.Buffering)
                    {
                        Play();
                    }
                    else if (fullyDownloaded && bufferedSeconds == 0)
                    {
                        Debug.WriteLine("Reached end of stream");
                        StopPlayback();
                    }
                }

            }
        }

        private void Play()
        {
            waveOut.Play();
            Debug.WriteLine(String.Format("Started playing, waveOut.PlaybackState={0}", waveOut.PlaybackState));
            playbackState = StreamingPlaybackState.Playing;
        }

        private void Pause()
        {
            playbackState = StreamingPlaybackState.Buffering;
            waveOut.Pause();
            Debug.WriteLine(String.Format("Paused to buffer, waveOut.PlaybackState={0}", waveOut.PlaybackState));
        }

        private IWavePlayer CreateWaveOut()
        {
            return new WaveOut();
        }

        private void MP3StreamingPanel_Disposing(object sender, EventArgs e)
        {
            StopPlayback();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (playbackState == StreamingPlaybackState.Playing || playbackState == StreamingPlaybackState.Buffering)
            {
                waveOut.Pause();
                Debug.WriteLine(String.Format("User requested Pause, waveOut.PlaybackState={0}", waveOut.PlaybackState));
                playbackState = StreamingPlaybackState.Paused;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopPlayback();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            Debug.WriteLine("Playback Stopped");
            if (e.Exception != null)
            {
                //MessageBox.Show(String.Format("Playback Error {0}", e.Exception.Message));
            }
        }
    }
}
