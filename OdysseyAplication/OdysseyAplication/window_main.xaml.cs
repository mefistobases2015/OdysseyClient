using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            this.label_signedUserName.Content = this._SignedUser;
            toolbarMain.Visibility = Visibility.Collapsed;
            musicGrid.Visibility = Visibility.Collapsed;
            communityGrid.Visibility = Visibility.Visible;
            toolbarCommunity.Visibility = Visibility.Visible;
        }
        private void button_id3Editor_Click(object sender, RoutedEventArgs e)
        {
            if (this._SongDataList != null && listview_data.SelectedIndex > -1)
            {
                // Disable The Music Kit
                toolbarMain.Visibility = Visibility.Collapsed;
                musicGrid.Visibility = Visibility.Collapsed;
                // Enable The Kit
                toolbarEditor.Visibility = Visibility.Visible;
                id3Grid.Visibility = Visibility.Visible;
                // Set The Actual Medatada As Info
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                textbox_artist.Text = this._SongDataList[index]._ID3Artist;
                textbox_genre.Text  = this._SongDataList[index]._ID3Genre;
                textbox_lyric.Text  = this._SongDataList[index]._ID3Lyrics;
                textbox_title.Text  = this._SongDataList[index]._ID3Title;
                textbox_album.Text  = this._SongDataList[index]._ID3Album;
                // Get List OF Past Versions Of The Song
                // Song In Cloud Library
                if(this._uploadMode == window_main.MODE_CLOUD)
                {
                  //  this._InfoManager.getListOfDataSong(_SongDataList[index]._SongID);
                }
                // Song In Local Library
                else if (this._uploadMode == window_main.MODE_LOCAL)
                {

                }
                //this._InfoManager.getListOfDataSong(this._SongDataList[index]._SongID);
            }
        }
        private async void button_descovery_Click(object sender, RoutedEventArgs e)
        {
            this.label_signedUserName.Content = this._SignedUser;
            this._SongDataList = await this._InfoManager.getRecomendatedSongs(this._SignedUser);
            if (this._SongDataList != null)
            {
                this.refreshSongCollection();
            }

            
        }
        private async void listview_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listview_data.SelectedItems.Count > 0 && listview_data.SelectedIndex >  -1)
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
            this.label_signedUserName.Content = this._SignedUser;
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
        private async void button_playSong_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.Items.Count > 0)
            {
                // Index Of The Selected Song
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);

                // Actual Song In The Play Queue
                label_actualSong_artist.Content = this._SongDataList[index]._ID3Artist;
                label_actualSong_Title.Content = this._SongDataList[index]._ID3Title;

                // Make A Song Reproduction
                await this._InfoManager.makeReproduction(this._SongDataList[index]._SongID);

                // Play A MP3 Stream
                if(this._uploadMode == window_main.MODE_CLOUD)
                {

                }
                // Play A MP3 Local File
                else if(this._uploadMode == window_main.MODE_LOCAL)
                {

                }
            }
        }

        private void button_local_Click(object sender, RoutedEventArgs e)
        {
            this.label_signedUserName.Content = this._SignedUser;
            this._uploadMode = window_main.MODE_LOCAL;
            this._SongDataList = _InfoManager.getSongsByUserInLocal(this._SignedUser);
            if (this._SongDataList != null)
            {
                this.refreshSongCollection();
            }
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
        }

        private void button_add_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void button1_download_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_close_id3Editor_Click(object sender, RoutedEventArgs e)
        {
            toolbarEditor.Visibility = Visibility.Collapsed;
            id3Grid.Visibility = Visibility.Collapsed;
            toolbarMain.Visibility = Visibility.Visible;
            musicGrid.Visibility = Visibility.Visible;
            textbox_artist.Text = "";
            textbox_genre.Text  = "";
            textbox_lyric.Text  = "";
            textbox_title.Text  = "";
            textbox_album.Text  = "";
        }

        private void button_close_community_Click(object sender, RoutedEventArgs e)
        {
            toolbarCommunity.Visibility = Visibility.Collapsed;
            communityGrid.Visibility = Visibility.Collapsed;
            musicGrid.Visibility = Visibility.Visible;
            toolbarMain.Visibility = Visibility.Visible;
        }

        private void button_upload_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_createVersion_Click(object sender, RoutedEventArgs e)
        {
            //DataSong
            //this._InfoManager.createDataSongVersionLocal();
        }

        private async void button_friend_request_Copy_Click(object sender, RoutedEventArgs e)
        {
            // List Of Users
            List<String> userList = await this._InfoManager.getFriendByUser(this._SignedUser);
            Thread.Sleep(3000);
            MessageBox.Show(userList.Count.ToString());
            // Eliminate All The Users Of The ListView
            while (listview_users.Items.Count > 0)
            {
                listview_users.Items.RemoveAt(0);
            }

            // Add Users To The UserListView
            foreach (string var in userList)
            {
                listview_users.Items.Add(new { Col1 = var });
            }
        }

        private async void button_friend_request_Click(object sender, RoutedEventArgs e)
        {
            // List Of Users
            MessageBox.Show(this._SignedUser);
            List<String> userList = await this._InfoManager.getFriendRequestByUser(this._SignedUser);
            // Eliminate All The Users Of The ListView
            while (listview_users.Items.Count > 0)
            {
                listview_users.Items.RemoveAt(0);
            }

            // Add Users To The UserListView
            foreach (string var in userList)
            {
                listview_users.Items.Add(new { Col1 = var });
            }
        }

        private void button_addRequest_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.SelectedIndex > -1)
            {
                this._InfoManager.acceptFriendRequest(this._SignedUser, "");
            }
        }

        private void button_cancelRequest_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.SelectedIndex > -1)
            {
                this._InfoManager.declineFriendRequest(this._SignedUser, "");
            }
        }

        private async void button_seeProfile_Click(object sender, RoutedEventArgs e)
        {
            if (listview_users.SelectedIndex > -1)
            {
                this._SongDataList = await _InfoManager.getSongsByUserInCloud("Braisman");
            }
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void button_recomendations_Click(object sender, RoutedEventArgs e)
        {
            listview_users.Items.Add(new { Col1 = "Braisman"});
        }
    }
}