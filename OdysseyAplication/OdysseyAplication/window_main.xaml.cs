using Microsoft.Win32;
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
        public List<string> _CommunityList { get; set; }
        public List<Version> _VersionList { get; set;  }
        public string _SignedUser { get; set; }
        public string _ProfileUser { get; set; }
        public string _uploadMode { get; set; }
        InfoProvider _InfoManager { get; set; }
        public int _CommentIndex { get; set; }
        MP3StreamerPlayer _Player { get; set; }
        DatabaseManager _DBManager { get; set; }
        public window_main()
        {
            //this._SignedUser = pUserSigned;
            InitializeComponent();
            //this._SignedUser = pUserSigned;
            this._InfoManager = new InfoProvider();
            this._Player = new MP3StreamerPlayer();
            //label_signedUserName.Content = pUserSigned;
            // if (!XmlManager.isDatabase())
            //{
            //   this._DBManager = new DatabaseManager();
            //  if (XmlManager.isDatabase())
            // {
            //    MessageBox.Show("Itz created");
            //}
            //else
            //{
            //   MessageBox.Show(this._DBManager.etrace1);
            //  MessageBox.Show(this._DBManager.etrace2);
            // MessageBox.Show(this._DBManager.etrace3);
            //}

            //}
        }
        private async void refreshLibrary(string pUserName, string pMode)
        {
            label_userName.Content = pUserName;
            this._uploadMode = pMode;
            if(this._uploadMode == window_main.MODE_CLOUD)
            {
                
            }
            else if(this._uploadMode == window_main.MODE_LOCAL)
            {
                this._SongDataList = DatabaseManager.getSongsOfUser(this._SignedUser);
            }
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

        private void refreshMusicGrid()
        {
            // Verify Friend Settings
            if (this._SignedUser == this._ProfileUser)
            {
                button_main_friend.Visibility = Visibility.Collapsed;
                button_id3Editor.Visibility = Visibility.Visible;
            }
            //else if (this._InfoManager.areFriends(this._ProfileUser, this._SignedUser))
            //{
            //button_main_friend.Visibility = Visibility.Visible;
            //button_id3Editor.Visibility = Visibility.Visible;
            //button_main_friend.Content = "✔";
            //}
            else
            {
                button_main_friend.Visibility = Visibility.Visible;
                button_id3Editor.Visibility = Visibility.Collapsed;
                button_main_friend.Content = "✚";
            }
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
        private async void button_community_Click(object sender, RoutedEventArgs e)
        {
            this.label_signedUserName.Content = this._SignedUser;

            // Change The Actual Grid
            toolbarMain.Visibility = Visibility.Collapsed;
            musicGrid.Visibility = Visibility.Collapsed;
            communityGrid.Visibility = Visibility.Visible;
            toolbarCommunity.Visibility = Visibility.Visible;
            label_userName.Content = this._SignedUser;
            this.refreshFriendList(this._SignedUser);
            // Social Ranking By Comments And Friends
            label_PorrasIndex.Content = await this._InfoManager.getUserSocialRanking(this._SignedUser);
            // Clasification By Library
            label_LibraryClas.Content = await this._InfoManager.getUserClasificationByLibrary(this._SignedUser);
            // Clasification By Friend Library
            label_FriendClas.Content =  await this._InfoManager.getUserClasificationByFriends(this._SignedUser);
            this.refresTopUsers();
        }
        private void refreshVersion()
        {
            while (listview_version.Items.Count > 0)
            {
                listview_version.Items.RemoveAt(0);
            }
            // Insert New Items
            foreach (Version ww in this._VersionList)
            {
                listview_version.Items.Add(new { Col1 = ww.id3v2_title, Col2 = ww.id3v2_author, Col3 = ww.id3v2_album, Col4 = ww.id3v2_year, Col5 = ww.submission_date });
            }
        }
        private async void button_id3Editor_Click(object sender, RoutedEventArgs e)
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
                if (this._uploadMode == window_main.MODE_CLOUD)
                {
                    this._VersionList = await this._InfoManager.getListOfDataSong(this._SongDataList[index]._SongID);
                }
                // Song In Local Library
                else if (this._uploadMode == window_main.MODE_LOCAL)
                {

                }
                if (this._VersionList !=  null)
                {
                    MessageBox.Show(this._VersionList.Count.ToString());
                    this.refreshVersion();
                }
            }
        }
        private void button_descovery_Click(object sender, RoutedEventArgs e)
        {
            this.refreshLibrary(this._SignedUser, window_main.MODE_CLOUD);
            
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
                if(this._CommentIndex < this._CommmentList.Count - 1)
                {
                    this._CommentIndex++;
                    label_comment_user.Content = this._CommmentList[this._CommentIndex].autor;
                    label_comment_text.Content = this._CommmentList[this._CommentIndex].cmt;
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
            this._SongDataList = await this._InfoManager.getSongsByUserInCloud(this._SignedUser);
            this.refreshMusicGrid();
        }
        private void button_nextSong_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.Items.Count > 0)
            {
                // Index Of The Selected Song
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                // Last Item
                if (index < listview_data.Items.Count - 1)
                {
                    listview_data.SelectedIndex = index + 1;
                    label_actualSong_artist.Content = this._SongDataList[index + 1]._ID3Artist;
                    label_actualSong_Title.Content = this._SongDataList[index + 1]._ID3Title;

                }
            }
        }
        private void button_prevSong_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.Items.Count > 0)
            {
                // Index Of The Selected Song
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                // First Item
                if (index > 0)
                {
                    listview_data.SelectedIndex = index - 1;
                    label_actualSong_artist.Content = this._SongDataList[index - 1]._ID3Artist;
                    label_actualSong_Title.Content = this._SongDataList[index - 1]._ID3Title;
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
                await this._InfoManager.setSongReproduction(this._SongDataList[index]._SongID);
            }
        }

        private void button_local_Click(object sender, RoutedEventArgs e)
        {
            if(!XmlManager.isDatabase())
            {
                this._DBManager = new DatabaseManager();
            }
            this.refreshLibrary(this._SignedUser, window_main.MODE_LOCAL);
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog saveFileDialog = new OpenFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Filter = "MP3 File (*.mp3)|*.mp3";
            saveFileDialog.Multiselect = true;
            if(saveFileDialog.ShowDialog() == true)
            {

            }

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

        private async void refreshFriendList(string pUserName)
        {
            // Indicator Of Selected Community
            label_communityMode.Content = "Amigos";
            // List Of Users
            this._CommunityList = await this._InfoManager.getFriendByUser(this._SignedUser);
            // Eliminate All The Users Of The ListView
            while (listview_users.Items.Count > 0)
            {
                listview_users.Items.RemoveAt(0);
            }
            // Add Users To The UserListView
            foreach (string var in this._CommunityList)
            {
                listview_users.Items.Add(new { Col1 = var });
            }
            button_cancelRequest.Visibility = Visibility.Collapsed;
            button_addRequest.Visibility = Visibility.Collapsed;
        }
        private async void refreshRequestFriendList(string pUserName)
        {
            // Indicator Of Selected Community
            label_communityMode.Content = "Solicitudes de Amistad";
            // List Of Users
            this._CommunityList = await this._InfoManager.getFriendRequestByUser(this._SignedUser);
            // Eliminate All The Users Of The ListView
            while (listview_users.Items.Count > 0)
            {
                listview_users.Items.RemoveAt(0);
            }
            // Add Users To The UserListView
            foreach (string var in this._CommunityList)
            {
                listview_users.Items.Add(new { Col1 = var });
            }
            button_cancelRequest.Visibility = Visibility.Visible;
            button_addRequest.Visibility = Visibility.Visible;
        }
        private async void refreshFriendRecomendationList(string pUserName)
        {
            // Indicator Of Selected Community
            label_communityMode.Content = "Recomendaciones";
            // List Of Users
            this._CommunityList = await this._InfoManager.getRecomendations(this._SignedUser);
            // Eliminate All The Users Of The ListView
            while (listview_users.Items.Count > 0)
            {
                listview_users.Items.RemoveAt(0);
            }
            // Add Users To The UserListView
            foreach (string var in this._CommunityList)
            {
                listview_users.Items.Add(new { Col1 = var });
            }
            button_cancelRequest.Visibility = Visibility.Visible;
            button_addRequest.Visibility = Visibility.Visible;

        }
        private void button_friend_request_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.refreshFriendList(this._SignedUser);
        }

        private void button_friend_request_Click(object sender, RoutedEventArgs e)
        {
            this.refreshRequestFriendList(this._SignedUser);
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

        private void button_seeProfile_Click(object sender, RoutedEventArgs e)
        {
            if(listview_users.SelectedIndex > -1)
            {
                this.refreshLibrary(this._CommunityList[listview_users.SelectedIndex], window_main.MODE_CLOUD);
                toolbarCommunity.Visibility = Visibility.Collapsed;
                communityGrid.Visibility = Visibility.Collapsed;
                musicGrid.Visibility = Visibility.Visible;
                toolbarMain.Visibility = Visibility.Visible;

                label_signedUserName.Content = this._CommunityList[listview_users.SelectedIndex];
            }
        }
        private void button_recomendations_Click(object sender, RoutedEventArgs e)
        {
            this.refreshFriendRecomendationList(this._SignedUser);
        }
        private async void refresTopUsers()
        {
            List<TopUser> topUsers = await this._InfoManager.getTopUsers();
            while (listview_topUsers.Items.Count > 0)
            {
                listview_topUsers.Items.RemoveAt(0);
            }
            int userPos = 1;
            foreach (TopUser user in topUsers)
            {
                listview_topUsers.Items.Add(new { Col1 = userPos.ToString(), Col2 = user.user_name, Col3 = user.puntaje });
                userPos++;
            }
        }

        private void button_upload_MouseMove(object sender, MouseEventArgs e)
        {
            label_button_info.Content = "Subir";
        }

        private void button_upload_MouseLeave(object sender, MouseEventArgs e)
        {
            label_button_info.Content = "";
        }

        private void button1_download_MouseMove(object sender, MouseEventArgs e)
        {
            label_button_info.Content = "Descargar";
        }

        private void button1_download_MouseLeave(object sender, MouseEventArgs e)
        {
            label_button_info.Content = "";
        }
        private void button_add_MouseMove(object sender, MouseEventArgs e)
        {
            label_button_info.Content = "Añadir";
        }

        private void button_add_MouseLeave(object sender, MouseEventArgs e)
        {
            label_button_info.Content = "";
        }
        
        private void button_id3Editor_MouseMove(object sender, MouseEventArgs e)
        {
            label_button_info.Content = "Editar";
        }

        private void button_id3Editor_MouseLeave(object sender, MouseEventArgs e)
        {
            label_button_info.Content = "";
        }

        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            this._SignedUser = textbox_user.Text;
            label_signedUserName.Content = this._SignedUser;
            loginGrid.Visibility = Visibility.Collapsed;
            musicGrid.Visibility = Visibility.Visible;
            toolbarMain.Visibility = Visibility.Visible;
            playerGrid.Visibility = Visibility.Visible;
            playerInfoGrid.Visibility = Visibility.Visible;

            if (!XmlManager.isDatabase())
            {
                this._DBManager = new DatabaseManager();
                if (XmlManager.isDatabase())
                {
                    MessageBox.Show("Itz created");
                }
                else
                {
                    MessageBox.Show(this._DBManager.etrace1);
                    MessageBox.Show(this._DBManager.etrace2);
                    MessageBox.Show(this._DBManager.etrace3);
                }
            }
        }

        private void button_main_cerrar_Click(object sender, RoutedEventArgs e)
        {
            label_signedUserName.Content = "";
            loginGrid.Visibility = Visibility.Visible;
            musicGrid.Visibility = Visibility.Collapsed;
            toolbarMain.Visibility = Visibility.Collapsed;
            playerGrid.Visibility = Visibility.Collapsed;
            playerInfoGrid.Visibility = Visibility.Collapsed;
        }

        private void button_stopSong_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}