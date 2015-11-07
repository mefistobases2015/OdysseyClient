using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OdysseyAplication
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class window_main : Window
    {
        public const string MODE_LOCAL = "LOCAL";
        public const string MODE_CLOUD = "CLOUD";
        public List<DataSong> _SongDataList { get; set; }
        public List<Comment> _CommmentList { get; set; }
        public string _SignedUser { get; set; }
        public string _uploadMode { get; set; }
        InfoProvider _InfoManager { get; set; }
        public int _CommentIndex { get; set; }
        public window_main(string pUserSigned)
        {
            this._SignedUser = pUserSigned;
            this._InfoManager = new InfoProvider();
            InitializeComponent();
            label_signedUserName.Content = pUserSigned;

        }
        private void refreshSongCollection()
        {
            // Delete The Current Data
            while (listview_data.Items.Count > 0)
            {
                listview_data.Items.RemoveAt(0);
            }
            // Insert New Items
            foreach (DataSong ww in this._SongDataList)
            {
                listview_data.Items.Add(new { Col1 = ww._ID3Artist, Col2 = ww._ID3Title, Col3 = ww._ID3Album, Col4 = ww._ID3Year, Col5 = ww._ID3Genre });
            }
        }
        private void button_community_Click(object sender, RoutedEventArgs e)
        {
            window_friends joey = new window_friends(this._SignedUser);
            joey.Show();
        }
        private void button_id3Editor_Click(object sender, RoutedEventArgs e)
        {
            int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
            window_id3Tool id3T = new window_id3Tool(this._SongDataList[index]);
            id3T.Show();
        }
        private async void button_descovery_Click(object sender, RoutedEventArgs e)
        {
        }
        private async void listview_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listview_data.SelectedItems.Count > 0)
            {
                // Index Of Selected Item
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                // Lyrics
                textbox_lyrics.Text = this._SongDataList[index]._ID3Lyrics;

                // Like's Of The Song
                string likeCounter = (await this._InfoManager.getLikeBySong(this._SongDataList[index]._SongID)).ToString();
                label_like_counter.Content = likeCounter;

                // Dislike's Of The Song
                string dislikeCounter = (await this._InfoManager.getDislikeBySong(this._SongDataList[index]._SongID)).ToString();
                label_dislike_counter.Content = dislikeCounter;

                // Plays Of The Song
                string playCounter = (await this._InfoManager.getSongReproductions(this._SongDataList[index]._SongID)).ToString();
                label_play_counter.Content = playCounter;

                // Comments Of The Song
                this._CommmentList = await this._InfoManager.getSongComments(this._SongDataList[index]._SongID);
                this._CommentIndex = 0;
                if (this._CommmentList.Count > 0)
                {
                    label_comment_user.Content = this._CommmentList[0].autor;
                    label_comment_text.Content = this._CommmentList[0].cmt;
                }
                else
                {
                    label_comment_user.Content = "";
                    label_comment_text.Content = "";
                }
            }
        }
        private async void button_makeLike_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.SelectedItems.Count > 0)
            {
                // Index Of Selected Item
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                await this._InfoManager.makeLike(this._SongDataList[index]._SongID);
                // Like's Of The Song
                string likeCounter = (await this._InfoManager.getLikeBySong(this._SongDataList[index]._SongID)).ToString();
                label_like_counter.Content = likeCounter;
            }
        }
        private async void button_makeDislike_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.SelectedItems.Count > 0)
            {
                // Index Of Selected Item
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                await this._InfoManager.makeDislike(this._SongDataList[index]._SongID);
                // Dislike's Of The Song
                string dislikeCounter = (await this._InfoManager.getDislikeBySong(this._SongDataList[index]._SongID)).ToString();
                label_dislike_counter.Content = dislikeCounter;

            }
        }
        private void button_nextComment_Click(object sender, RoutedEventArgs e)
        {
            if (this._CommmentList != null)
            {
                if(this._CommentIndex < this._CommmentList.Count - 2)
                {
                    this._CommentIndex++;
                    label_comment_user.Content = this._CommmentList[this._CommentIndex].autor;
                    label_comment_text.Content = this._CommmentList[this._CommentIndex].cmt;
                }
            }
        }

        private void button_prevSong_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.Items.Count > 0)
            {
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                if (index > 0)
                {
                    listview_data.SelectedIndex = index - 1;
                    label_actualSong_artist.Content = this._SongDataList[index - 1]._ID3Artist;
                    label_actualSong_Title.Content = this._SongDataList[index - 1]._ID3Title;
                }
            }
        }

        private void button_prevComment_Click(object sender, RoutedEventArgs e)
        {
            if (this._CommmentList != null)
            {
                if (this._CommentIndex > 1)
                {
                    this._CommentIndex--;
                    label_comment_user.Content = this._CommmentList[this._CommentIndex].autor;
                    label_comment_text.Content = this._CommmentList[this._CommentIndex].cmt;
                }
            }
        }

        private async void button_commentMaker_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.Items.Count > 0)
            {
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                await this._InfoManager.setComent(this._SongDataList[index]._SongID, this._SignedUser, textbox_writter.Text);
                // Comments Of The Song
                this._CommmentList = await this._InfoManager.getSongComments(this._SongDataList[index]._SongID);
                this._CommentIndex = 0;
                if (this._CommmentList.Count > 0)
                {
                    label_comment_user.Content = this._CommmentList[0].autor;
                    label_comment_text.Content = this._CommmentList[0].cmt;
                }
                else
                {
                    label_comment_user.Content = "";
                    label_comment_text.Content = "";
                }
                textbox_writter.Text = "";
            }
        }

        private async void button_cloud_Click(object sender, RoutedEventArgs e)
        {
            this._uploadMode = window_main.MODE_CLOUD;
            this._SongDataList = await _InfoManager.getSongsByUserInCloud(this._SignedUser);
            if(this._SongDataList != null)
            {
                this.refreshSongCollection();
            }
        }

        private void button_Copy3_Click(object sender, RoutedEventArgs e)
        {
         //   MP3StreamerPlayer j = new MP3StreamerPlayer();
            MP3StreamerPlayer.PlayMp3FromUrl("https://odysseyblob.blob.core.windows.net/braisman/6.mp3");
        }
        private void button_nextSong_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.Items.Count > 0)
            {
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                if (index < listview_data.Items.Count - 1)
                {
                    listview_data.SelectedIndex = index + 1;
                    label_actualSong_artist.Content = this._SongDataList[index + 1]._ID3Artist;
                    label_actualSong_Title.Content = this._SongDataList[index + 1]._ID3Title;

                }
            }
        }
        private void button_playSong_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.Items.Count > 0)
            {
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                label_actualSong_artist.Content = this._SongDataList[index]._ID3Artist;
                label_actualSong_Title.Content = this._SongDataList[index]._ID3Title;
            }
        }

        private void button_local_Click(object sender, RoutedEventArgs e)
        {
            this._uploadMode = window_main.MODE_LOCAL;
            this._SongDataList = _InfoManager.getSongsByUserInLocal(this._SignedUser);
            if (this._SongDataList != null)
            {
                this.refreshSongCollection();
            }
        }
    }
}
