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
using System.Windows.Threading;
using WMPLib;

namespace OdysseyAplication
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class window_main : Window
    {
        public const string MODE_LOCAL = "LOCAL";
        public const string MODE_CLOUD = "CLOUD";
        public WindowsMediaPlayer _Player { get; }
        public bool _UserDraggin { get; set; }
        public List<DataSong> _SongDataList { get; set; }
        public List<Comment> _CommmentList { get; set; }
        public List<string> _CommunityList { get; set; }
        public List<Version> _VersionList { get; set;  }
        public string _SignedUser { get; set; }
        public string _ProfileUser { get; set; }
        public string _uploadMode { get; set; }
        public DispatcherTimer _Timer { get; set; }
        public string _IDPlay { get; set; }
        public string _IDPlayLocal { get; set; }
        InfoProvider _InfoManager { get; set; }
        public int _CommentIndex { get; set; }
        DatabaseManager _DBManager { get; set; }
        public window_main()
        {
            InitializeComponent();

            this._InfoManager = new InfoProvider();
            this._Player = new WindowsMediaPlayer();
            this._Timer = new DispatcherTimer();
            this._Timer.Interval = TimeSpan.FromSeconds(1);
            this._Timer.Tick += timer_Tick;
            this._Timer.Start();
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

        private async void refreshMusicGrid()
        {
            label_signedUserName.Content = this._ProfileUser;
            // Verify Friend Settings
            if (this._SignedUser == this._ProfileUser)
            {
                button_main_friend.Visibility = Visibility.Collapsed;
                button_id3Editor.Visibility = Visibility.Visible;
            }
            else if (await this._InfoManager.areFriends(this._ProfileUser, this._SignedUser))
            {
                button_main_friend.Visibility = Visibility.Visible;
                button_id3Editor.Visibility = Visibility.Visible;
                button_main_friend.Content = "✔";
            }
            else
            {
                button_main_friend.Visibility = Visibility.Visible;
                button_id3Editor.Visibility = Visibility.Collapsed;
                button_main_friend.Content = "✚";
            }
            if(this._uploadMode == window_main.MODE_LOCAL)
            {
                socialPanel.Visibility = Visibility.Collapsed;
            }
            else if(this._uploadMode == window_main.MODE_CLOUD)
            {
                socialPanel.Visibility = Visibility.Visible;
            }
            if (this._SongDataList != null)
            {
                // Delete The Current Data
                while (listview_data.Items.Count > 0)
                {
                    listview_data.Items.RemoveAt(0);
                }
                // Insert New Items
                foreach (DataSong ww in this._SongDataList)
                {
                    listview_data.Items.Add(new { Col1 = ww._ID3Title, Col2 = ww._ID3Artist, Col3 = ww._ID3Album, Col4 = ww._ID3Genre, Col5 = ww._ID3Year });
                }
            }
        }
        private async void button_community_Click(object sender, RoutedEventArgs e)
        {
            // Change The Actual Grid
            toolbarMain.Visibility = Visibility.Collapsed;
            musicGrid.Visibility = Visibility.Collapsed;
            communityGrid.Visibility = Visibility.Visible;
            toolbarCommunity.Visibility = Visibility.Visible;
            label_userName.Content = this._SignedUser;
            this.refreshFriendList(this._SignedUser);
            // Name Of The Signed User
            this.label_signedUserName.Content = this._SignedUser;
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
                listview_version.Items.Add(new { Col1 = ww.id3v2_title, Col2 = ww.id3v2_author, Col3 = ww.id3v2_album, Col4 = ww.id3v2_year,
                                                 Col5 = ww.id3v2_genre, Col6 = ww.submission_date });
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
                textbox_year.Text   = this._SongDataList[index]._ID3Year;
                textbox_lyric.Text  = this._SongDataList[index]._ID3Lyrics;
                textbox_title.Text  = this._SongDataList[index]._ID3Title;
                textbox_album.Text  = this._SongDataList[index]._ID3Album;
                // Get List OF Past Versions Of The Song
                // Song In Cloud Library
                if (this._uploadMode == window_main.MODE_CLOUD)
                {
                    this._VersionList = await this._InfoManager.getListOfDataSong(this._SongDataList[index]._SongID);
                }
                else if(this._uploadMode == window_main.MODE_LOCAL)
                {
                    this._VersionList = this._InfoManager.getLocalVersionList(this._SongDataList[listview_data.SelectedIndex]._LocalSongID);
                }
                if (this._VersionList !=  null)
                {
                    this.refreshVersion();
                }
            }
        }
        private async void button_descovery_Click(object sender, RoutedEventArgs e)
        {
            this._SongDataList = await this._InfoManager.getRecomendatedSongs(this._ProfileUser);
            this._ProfileUser = this._SignedUser;
            this._uploadMode = window_main.MODE_CLOUD;
            this.refreshMusicGrid();
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

                if (this._SongDataList[index]._SongID == this._IDPlay)
                {
                    button_playSong.Content = "▏ ▏";
                }
                else
                {
                    button_playSong.Content = "▶";
                }

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

            this._ProfileUser = this._SignedUser;
            this._SongDataList = await this._InfoManager.getSongsByUserInCloud(this._SignedUser);
            this.refreshMusicGrid();
        }
        private async void button_nextSong_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.Items.Count > 0)
            {
                // Index Of The Selected Song
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                // Last Item
                if (index < listview_data.Items.Count - 1)
                {
                    if (listview_data.SelectedIndex > -1)
                    {
                        listview_data.SelectedIndex = index + 1;
                        this._IDPlay = this._SongDataList[index + 1]._SongID;
                        label_actualSong_artist.Content = this._SongDataList[index + 1]._ID3Artist;
                        label_actualSong_Title.Content = this._SongDataList[index + 1]._ID3Title;
                        if (this._uploadMode == window_main.MODE_CLOUD)
                        {
                            this._IDPlayLocal = "-1";
                            //this._SongDataList[listview_data.SelectedIndex]._SongID
                            this._Player.URL = "https://odysseyblob.blob.core.windows.net/music/" + this._SongDataList[listview_data.SelectedIndex]._SongID + ".mp3";

                            await this._InfoManager.setSongReproduction(this._SongDataList[listview_data.SelectedIndex]._SongID);
                            
                            // Plays Of The Song
                            string playCounter = (await this._InfoManager.getSongReproductions(this._SongDataList[listview_data.SelectedIndex]._SongID)).ToString();
                            label_play_counter.Content = playCounter;
                        }
                        else if (this._uploadMode == window_main.MODE_LOCAL)
                        {
                            this._IDPlay = "-1";
                            // Set The Local ID
                            this._IDPlay = this._SongDataList[listview_data.SelectedIndex]._LocalSongID;

                            // Set Song
                            this._Player.URL = this._SongDataList[listview_data.SelectedIndex]._SongDirectory;
                        }
                    }
                }
            }
        }
        private async void button_prevSong_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.Items.Count > 0)
            {
                // Index Of The Selected Song
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                // First Item
                if (index > 0)
                {
                    listview_data.SelectedIndex = index - 1;
                    this._IDPlay = this._SongDataList[index - 1]._SongID;
                    label_actualSong_artist.Content = this._SongDataList[index - 1]._ID3Artist;
                    label_actualSong_Title.Content =  this._SongDataList[index - 1]._ID3Title;
                    if (this._uploadMode == window_main.MODE_CLOUD)
                    {
                        this._IDPlayLocal = "-1";
                        //this._SongDataList[listview_data.SelectedIndex]._SongID
                        this._Player.URL = "https://odysseyblob.blob.core.windows.net/music/" + this._SongDataList[listview_data.SelectedIndex]._SongID + ".mp3";
                        await this._InfoManager.setSongReproduction(this._SongDataList[listview_data.SelectedIndex]._SongID);
                        // Plays Of The Song
                        string playCounter = (await this._InfoManager.getSongReproductions(this._SongDataList[listview_data.SelectedIndex]._SongID)).ToString();
                        label_play_counter.Content = playCounter;
                    }
                    else if (this._uploadMode == window_main.MODE_LOCAL)
                    {
                        this._IDPlay = "-1";
                        // Set The Local ID
                        this._IDPlayLocal = this._SongDataList[listview_data.SelectedIndex]._LocalSongID;

                        // Set Song
                        this._Player.URL = this._SongDataList[listview_data.SelectedIndex]._SongDirectory;
                    }
                }
            }
        }
        private async void button_playSong_Click(object sender, RoutedEventArgs e)
        {
            if (listview_data.SelectedIndex > -1)
            {
                
                if (button_playSong.Content.ToString() == "▶")
                {
                    button_playSong.Content = "▏ ▏";
                    if (this._uploadMode == window_main.MODE_CLOUD)
                    {
                        this._IDPlayLocal = "-1";
                        if (this._IDPlay != this._SongDataList[listview_data.SelectedIndex]._SongID)
                        {
                            this._IDPlay = this._SongDataList[listview_data.SelectedIndex]._SongID;

                            // Set Song
                            this._Player.URL = "https://odysseyblob.blob.core.windows.net/music/" + this._SongDataList[listview_data.SelectedIndex]._SongID + ".mp3";

                            // Notify Play
                            await this._InfoManager.setSongReproduction(this._SongDataList[listview_data.SelectedIndex]._SongID);

                            // Set The Info Player Grid
                            label_actualSong_artist.Content = this._SongDataList[listview_data.SelectedIndex]._ID3Artist;
                            label_actualSong_Title.Content = this._SongDataList[listview_data.SelectedIndex]._ID3Title;
                            
                            // Plays Of The Song
                            string playCounter = (await this._InfoManager.getSongReproductions(this._SongDataList[listview_data.SelectedIndex]._SongID)).ToString();
                            label_play_counter.Content = playCounter;
                        }

                    }
                    else if (this._uploadMode == window_main.MODE_LOCAL)
                    {
                        this._IDPlay = "-1";
                        if (this._IDPlayLocal != this._SongDataList[listview_data.SelectedIndex]._LocalSongID)
                        {
                            // Set The Local ID
                            this._IDPlayLocal = this._SongDataList[listview_data.SelectedIndex]._LocalSongID;

                            // Set Song
                            this._Player.URL = this._SongDataList[listview_data.SelectedIndex]._SongDirectory;

                            // Set The Info Player Grid
                            label_actualSong_artist.Content = this._SongDataList[listview_data.SelectedIndex]._ID3Artist;
                            label_actualSong_Title.Content =  this._SongDataList[listview_data.SelectedIndex]._ID3Title;
                        }
                    }
                    this._Player.controls.play();
                }
                else
                {
                    button_playSong.Content = "▶";
                    this._Player.controls.pause();
                }
            }
        }

    private void timer_Tick(object sender, EventArgs e)
    {
            if(this._Player.controls.currentItem != null)
            { 
                slider.Minimum = 0;
                slider.Maximum = this._Player.controls.currentItem.duration;
                slider.Value = this._Player.controls.currentPosition;
                label_counter_timer.Content = this._Player.controls.currentPositionString;
                label_counter_final.Content = this._Player.controls.currentItem.durationString;
            }
        }

    private void button_local_Click(object sender, RoutedEventArgs e)
        {
            this._uploadMode = window_main.MODE_LOCAL;

            this._ProfileUser = this._SignedUser;
            this._SongDataList = this._InfoManager.getSongsByUserInLocal(this._SignedUser);
            this.refreshMusicGrid();
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog saveFileDialog = new OpenFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Filter = "MP3 File (*.mp3)|*.mp3";
            saveFileDialog.Multiselect = true;
            if(saveFileDialog.ShowDialog() == true)
            {
                DataSong d = TagManager.getID3ByDirectory(saveFileDialog.FileNames[0]);
                this._InfoManager.addSong2LocalDatabase(this._SignedUser, new List<string>(saveFileDialog.FileNames));
                MessageBox.Show(DatabaseManager.etrace1);
            }

        }

        private void button1_download_Click(object sender, RoutedEventArgs e)
        {
            this._uploadMode = window_main.MODE_LOCAL;
            this._ProfileUser = this    ._SignedUser;
            this._SongDataList = this._InfoManager.getSongsByUserInLocal(this._SignedUser);
            this._InfoManager.downloadDatabase(this._SignedUser);
                this.refreshMusicGrid();
            }

        private async void button_close_id3Editor_Click(object sender, RoutedEventArgs e)
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

            if(this._uploadMode == window_main.MODE_CLOUD)
            {
                this._SongDataList = await this._InfoManager.getSongsByUserInCloud(this._SignedUser);
            }
            else if(this._uploadMode == window_main.MODE_LOCAL)
            {
                this._SongDataList = this._InfoManager.getSongsByUserInLocal(this._SignedUser);
            }
            this.refreshMusicGrid();
        }

        private void button_close_community_Click(object sender, RoutedEventArgs e)
        {
            toolbarCommunity.Visibility = Visibility.Collapsed;
            communityGrid.Visibility = Visibility.Collapsed;
            musicGrid.Visibility = Visibility.Visible;
            toolbarMain.Visibility = Visibility.Visible;
        }

        private async void button_upload_Click(object sender, RoutedEventArgs e)
        {
            this._uploadMode = window_main.MODE_CLOUD;
            this._ProfileUser = this._SignedUser;
            MessageBox.Show("Se van a cargar canciones, puede tomar un tiempo, no hacer cambios en el programa");
            string debug_message = await this._InfoManager.uploadDatabase(this._SignedUser);
            MessageBox.Show("Carga Completada, Se subieron " + debug_message + " Canciones");
            this._SongDataList = await this._InfoManager.getSongsByUserInCloud(this._SignedUser);
            if (this._SongDataList != null)
            {
                this.refreshMusicGrid();
            }
        }
        private async void refreshFriendList(string pUserName)
        {
            // Indicator Of Selected Community
            label_communityMode.Content = "Amigos";
            // Eliminate All The Users Of The ListView
            while (listview_users.Items.Count > 0)
            {
                listview_users.Items.RemoveAt(0);
            }
            // List Of Users
            this._CommunityList = await this._InfoManager.getFriendByUser(this._SignedUser);
            // Add Users To The UserListView
            foreach (string var in this._CommunityList)
            {
                listview_users.Items.Add(new { Col1 = var });
            }
            button_cancelRequest.Visibility = Visibility.Collapsed;
            button_addRequest.Visibility = Visibility.Collapsed;
            button_sendRequest.Visibility = Visibility.Collapsed;
        }
        private async void refreshRequestFriendList(string pUserName)
        {
            // Indicator Of Selected Community
            label_communityMode.Content = "Solicitudes de Amistad";
            // Eliminate All The Users Of The ListView
            while (listview_users.Items.Count > 0)
            {
                listview_users.Items.RemoveAt(0);
            }
            // List Of Users
            this._CommunityList = await this._InfoManager.getFriendRequestByUser(this._SignedUser);
            // Add Users To The UserListView
            foreach (string var in this._CommunityList)
            {
                listview_users.Items.Add(new { Col1 = var });
            }
            button_cancelRequest.Visibility = Visibility.Visible;
            button_addRequest.Visibility = Visibility.Visible;
            button_sendRequest.Visibility = Visibility.Collapsed;
        }
        private async void refreshFriendRecomendationList(string pUserName)
        {
            // Indicator Of Selected Community
            label_communityMode.Content = "Recomendaciones";
            while (listview_users.Items.Count > 0)
            {
                listview_users.Items.RemoveAt(0);
            }
            // List Of Users
            this._CommunityList = await this._InfoManager.getRecomendations(this._SignedUser);
            // Eliminate All The Users Of The ListView
            // Add Users To The UserListView
            foreach (string var in this._CommunityList)
            {
                listview_users.Items.Add(new { Col1 = var });
            }
            button_cancelRequest.Visibility = Visibility.Collapsed;
            button_addRequest.Visibility = Visibility.Collapsed;
            button_sendRequest.Visibility = Visibility.Visible;

        }
        private void button_friend_request_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.refreshFriendList(this._SignedUser);
        }

        private void button_friend_request_Click(object sender, RoutedEventArgs e)
        {
            this.refreshRequestFriendList(this._SignedUser);
        }

        private async void button_addRequest_Click(object sender, RoutedEventArgs e)
        {
            if (listview_users.SelectedIndex > -1)
            {
                await this._InfoManager.acceptFriendRequest(this._SignedUser, this._CommunityList[listview_users.SelectedIndex]);
                this.refresTopUsers();
            }
        }

        private async void button_cancelRequest_Click(object sender, RoutedEventArgs e)
        {
            if (listview_users.SelectedIndex > -1)
            {
                await this._InfoManager.declineFriendRequest(this._SignedUser, this._CommunityList[listview_users.SelectedIndex]);
                this.refresTopUsers();
            }
        }

        private async void button_seeProfile_Click(object sender, RoutedEventArgs e)
        {
            if(listview_users.SelectedIndex > -1)
            {
                this._ProfileUser = this._CommunityList[listview_users.SelectedIndex];
                this._SongDataList = await this._InfoManager.getSongsByUserInCloud(this._ProfileUser);
                this._uploadMode = window_main.MODE_CLOUD;

                // Change The Grid
                toolbarCommunity.Visibility = Visibility.Collapsed;
                communityGrid.Visibility    = Visibility.Collapsed;
                musicGrid.Visibility        = Visibility.Visible;
                toolbarMain.Visibility      = Visibility.Visible;
                
                this.refreshMusicGrid();
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

        private async void button_ok_Click(object sender, RoutedEventArgs e)
        {
            this._uploadMode = window_main.MODE_CLOUD;
            this._SignedUser = textbox_user.Text;
            this._ProfileUser = textbox_user.Text;
            label_signedUserName.Content = this._SignedUser;
            await this._InfoManager.setConnectedState(this._SignedUser, true);
            loginGrid.Visibility = Visibility.Collapsed;
            musicGrid.Visibility = Visibility.Visible;
            toolbarMain.Visibility = Visibility.Visible;
            playerGrid.Visibility = Visibility.Visible;
            playerInfoGrid.Visibility = Visibility.Visible;
            this.refreshMusicGrid();
        }

        private async void button_main_cerrar_Click(object sender, RoutedEventArgs e)
        {
            await this._InfoManager.setConnectedState(this._SignedUser, false);
            label_signedUserName.Content = "";
            loginGrid.Visibility = Visibility.Visible;
            musicGrid.Visibility = Visibility.Collapsed;
            toolbarMain.Visibility = Visibility.Collapsed;
            playerGrid.Visibility = Visibility.Collapsed;
            playerInfoGrid.Visibility = Visibility.Collapsed;
        }

        private void button_stopSong_Click(object sender, RoutedEventArgs e)
        {
            this._Player.controls.stop();
        }

        private async void button_makeVersion_Click(object sender, RoutedEventArgs e)
        {
            DataSong selectedMeta = new DataSong();

            selectedMeta._SongDirectory = this._SongDataList[listview_data.SelectedIndex]._SongDirectory;
            selectedMeta._SongName      = this._SongDataList[listview_data.SelectedIndex]._SongName;
            selectedMeta._SongID        = this._SongDataList[listview_data.SelectedIndex]._SongID;
            selectedMeta._LocalSongID   = this._SongDataList[listview_data.SelectedIndex]._LocalSongID;
            selectedMeta._ID3Title  = textbox_title.Text;
            selectedMeta._ID3Artist = textbox_artist.Text;
            selectedMeta._ID3Genre  = textbox_genre.Text;
            selectedMeta._ID3Lyrics = textbox_lyric.Text;
            selectedMeta._ID3Album  = textbox_album.Text;
            selectedMeta._ID3Year   = textbox_year.Text;

            if (this._uploadMode == window_main.MODE_CLOUD)
            {
                this._InfoManager.createDataSongVersionCloud(selectedMeta);
                this._VersionList = await this._InfoManager.getListOfDataSong(this._SongDataList[listview_data.SelectedIndex]._SongID);
            }
            else if(this._uploadMode == window_main.MODE_LOCAL)
            {   
                this._InfoManager.createDataSongVersionLocal(selectedMeta);
                this._VersionList = this._InfoManager.getLocalVersionList(this._SongDataList[listview_data.SelectedIndex]._LocalSongID);
            }
            if (this._VersionList != null)
            {
                this.refreshVersion();
            }
        }

        private async void button_chooseVersion_Click(object sender, RoutedEventArgs e)
        {
            if(listview_version.SelectedIndex > -1)
            {
                if (this._uploadMode == window_main.MODE_CLOUD)
                {
                    await this._InfoManager.setOldVersion2Song(this._VersionList[listview_version.SelectedIndex].song_id.ToString(), this._VersionList[listview_version.SelectedIndex].version_id.ToString());
                }
                else if (this._uploadMode == window_main.MODE_LOCAL)
                {
                    this._InfoManager.setVersion2SongLocal(this._VersionList[listview_version.SelectedIndex].version_id.ToString(), this._VersionList[listview_version.SelectedIndex].song_id.ToString());
                }
            }
        }

        private async void  button_user_search_Click(object sender, RoutedEventArgs e)
        {
            // Indicator Of Selected Community
            label_communityMode.Content = "Buscador de Usuarios";
            // Set The Configuration Of Friends 
            button_cancelRequest.Visibility = Visibility.Collapsed;
            button_addRequest.Visibility = Visibility.Collapsed;
            button_sendRequest.Visibility = Visibility.Visible;
            // Eliminate All The Users Of The ListView
            while (listview_users.Items.Count > 0)
            {
                listview_users.Items.RemoveAt(0);
            }
            // List Of Users
            this._CommunityList = await this._InfoManager.searchUsers(textBox.Text);
            // Add Users To The UserListView
            foreach (string var in this._CommunityList)
            {
                listview_users.Items.Add(new { Col1 = var });
            }
            // Set The Default Text
            textBox.Text = "Buscar Usuario...";
        }
        private void textBox_MouseEnter(object sender, MouseEventArgs e)
        {
            textBox.Text = "";
        }
        private async void button_personal_info_Click(object sender, RoutedEventArgs e)
        {
            // Name Of The Signed User
            this.label_userName.Content = this._SignedUser;
            // Social Ranking By Comments And Friends
            label_PorrasIndex.Content = await this._InfoManager.getUserSocialRanking(this._SignedUser);
            // Clasification By Library
            label_LibraryClas.Content = await this._InfoManager.getUserClasificationByLibrary(this._SignedUser);
            // Clasification By Friend Library
            label_FriendClas.Content = await this._InfoManager.getUserClasificationByFriends(this._SignedUser);
        }
        private async void listview_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listview_users.SelectedIndex > -1)
            {
                // Name Of The Signed User
                this.label_userName.Content = this._CommunityList[listview_users.SelectedIndex];
                // Social Ranking By Comments And Friends
                label_PorrasIndex.Content = await this._InfoManager.getUserSocialRanking(this._CommunityList[listview_users.SelectedIndex]);
                // Clasification By Library
                label_LibraryClas.Content = await this._InfoManager.getUserClasificationByLibrary(this._CommunityList[listview_users.SelectedIndex]);
                // Clasification By Friend Library
                label_FriendClas.Content = await this._InfoManager.getUserClasificationByFriends(this._CommunityList[listview_users.SelectedIndex]);
            }
        }
        private void button_seeProfile_MouseLeave(object sender, MouseEventArgs e)
        {
            label_social_option.Content = "";
        }
        private void button_seeProfile_MouseMove(object sender, MouseEventArgs e)
        {
            label_social_option.Content = "Ver Perfil";
        }
        private void button_sendRequest_MouseMove(object sender, MouseEventArgs e)
        {
            label_social_option.Content = "Enviar Solicitud";
        }
        private void button_sendRequest_MouseLeave(object sender, MouseEventArgs e)
        {
            label_social_option.Content = "";
        }
        private void button_cancelRequest_MouseMove(object sender, MouseEventArgs e)
        {
            label_social_option.Content = "Ahorita No";
        }
        private void button_addRequest_MouseLeave(object sender, MouseEventArgs e)
        {
            label_social_option.Content = "";
        }
        private void button_addRequest_MouseMove(object sender, MouseEventArgs e)
        {
            label_social_option.Content = "Aceptar Solicitud";
        }
        private void button_cancelRequest_MouseLeave(object sender, MouseEventArgs e)
        {
            label_social_option.Content = "";
        }

        private async void button_sendRequest_Click(object sender, RoutedEventArgs e)
        {
            if (listview_users.SelectedIndex > -1)
            {
                await this._InfoManager.setFriendRequest(this._SignedUser, this._CommunityList[listview_users.SelectedIndex]);
                this.refresTopUsers();
            }
        }

        private void listview_version_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listview_version.SelectedIndex > -1)
            {
                textbox_artist.Text = this._VersionList[listview_version.SelectedIndex].id3v2_author;
                textbox_genre.Text  = this._VersionList[listview_version.SelectedIndex].id3v2_genre;
                textbox_year.Text   = this._VersionList[listview_version.SelectedIndex].id3v2_year.ToString();
                textbox_lyric.Text  = this._VersionList[listview_version.SelectedIndex].id3v2_lyrics;
                textbox_title.Text  = this._VersionList[listview_version.SelectedIndex].id3v2_title;
                textbox_album.Text  = this._VersionList[listview_version.SelectedIndex].id3v2_album;
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this._UserDraggin)
            {
                this._Player.controls.currentPosition = slider.Value;
            }
        }

        private void slider_MouseEnter(object sender, MouseEventArgs e)
        {
            this._UserDraggin = true;
        }

        private void slider_MouseLeave(object sender, MouseEventArgs e)
        {
            this._UserDraggin = false;
        }

        private async void button_main_friend_Click(object sender, RoutedEventArgs e)
        {
            if(button_main_friend.Content.ToString() == "✔")
            {

            }
            else if(button_main_friend.Content.ToString() == "✚")
            {
                await this._InfoManager.setFriendRequest(this._SignedUser, this._ProfileUser);
            }
        }

        private void textBox_omnifinder_MouseLeave(object sender, MouseEventArgs e)
        {
            textBox_omnifinder.Text = "Buscar Canción...";
        }

        private void textBox_omnifinder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox_omnifinder.Text = "";
        }

        private void button_search_omnifinder_Click(object sender, RoutedEventArgs e)
        {
            this.refreshMusicGrid();
        }
    }
}   