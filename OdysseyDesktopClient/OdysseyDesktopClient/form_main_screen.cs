﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdysseyDesktopClient
{
    public partial class form_main_screen : Form
    {
        List<Metadata> _SongList { get; set; }
        InfoProvider _IPOP { get; set; }
        string _SignedUser { get; set; }
        string _ProfileUser{ get; set; }
        string _UploadMode { get; set; }

        public form_main_screen()
        {
            this._IPOP = new InfoProvider();
            this._SignedUser = "Braisman";
            InitializeComponent();
        }

        private void refreshSongCollection()
        {
            button_id3_launcher.Visible = false;
            listview_data.BeginUpdate();
            // Delete The Current Data
            while (listview_data.Items.Count > 0)
            {
                listview_data.Items.RemoveAt(0);
            }
            // Insert New Items
            foreach(Metadata ww in this._SongList)
            {
                ListViewItem item = new ListViewItem(ww._SongID);
                item.SubItems.Add(ww._ID3Artist);
                item.SubItems.Add(ww._ID3Title);
                item.SubItems.Add(ww._ID3Album);
                item.SubItems.Add(ww._ID3Genre);
                item.SubItems.Add(ww._ID3Year);
                listview_data.Items.Add(item);
            }
            listview_data.EndUpdate();
        }

        private async void button__personal_library_Click(object sender, EventArgs e)
        {
            this._UploadMode = form_id3_editor.MODE_LOCAL;
            //...Show The Local DB Library Of The Signed User
            this._SongList = await this._IPOP.getSongsByUserInLocal(this._SignedUser);
            //... Refresh The Actual Data List
            this.refreshSongCollection();
        }

        private async void button_cloud_library_Click(object sender, EventArgs e)
        {
            this._UploadMode = form_id3_editor.MODE_CLOUD;
            //...Show The Cloud DB Library Of The Signed User
            this._SongList = await this._IPOP.getSongsByUserInCloud(this._SignedUser);
            //... Refresh The Actual Data List

            this.refreshSongCollection();
        }

        private async void refreshLikeInfo(string pSongID)
        {
            InfoProvider ipop = new InfoProvider();
            label_like_counter.Text = (await ipop.getLikeBySong(pSongID)).ToString();
            label_like_counter.Update();
        }

        private async void refreshDislikeInfo(string pSongID)
        {
            InfoProvider ipop = new InfoProvider();
            label_dislike_counter.Text = (await ipop.getDislikeBySong(pSongID)).ToString();
            label_dislike_counter.Update();
        }
        private async void refreshPlays(string pSongID)
        {
            InfoProvider ipop = new InfoProvider();
            label_song_reproductions.Text = (await ipop.getSongReproductions(pSongID)).ToString();
            label_song_reproductions.Update();
        }
        private async void refreshReproductions(string pSongID)
        {
            InfoProvider ipop = new InfoProvider();
            label_song_reproductions.Text = (await ipop.getSongReproductions(pSongID)).ToString();
            label_song_reproductions.Update();
        }
        private void listview_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listview_data.SelectedItems.Count > 0)
            {
                button_id3_launcher.Visible = true;
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                textbox_lyrics.Text = this._SongList[index]._ID3Lyrics;
                this.refreshLikeInfo(this._SongList[index]._SongID);
                this.refreshDislikeInfo( this._SongList[index]._SongID);
                this.refreshReproductions(this._SongList[index]._SongID);
            }
            else
            {
                button_id3_launcher.Visible = false;
            }
        }

        private void combobox_user_searcher_TextChanged(object sender, EventArgs e)
        {
            // Searchs Users By A String Key
            List<String> peopleList = null;// this._IPOP.searchUsers(combobox_user_searcher.Text);
            combobox_user_searcher.BeginUpdate();
            combobox_user_searcher.Items.Clear();
            foreach(String user_name in peopleList)
            {
                combobox_user_searcher.Items.Add(user_name);
            }
            combobox_user_searcher.EndUpdate();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button_id3_launcher_Click(object sender, EventArgs e)
        {
            if (listview_data.SelectedItems.Count > 0)
            {
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                form_id3_editor form_id3_editor = new form_id3_editor(this._SongList[index], this._ProfileUser, this._UploadMode);
                form_id3_editor.Show();
            }
        }

        private void form_main_screen_Load(object sender, EventArgs e)
        {

        }

        private void textbox_lyrics_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel_complement_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button_friend_manager_Click(object sender, EventArgs e)
        {
            var form_friend = new form_friend_manager(this._ProfileUser);
            form_friend.Show();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (listview_data.SelectedItems.Count > 0)
            {
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                if (listview_data.Items.Count > index + 1)
                {
                    listview_data.Items[index].Selected = false;
                    listview_data.Items[index + 1].Selected = true;
                }
            }
        }

        private async void button_like_Click(object sender, EventArgs e)
        {
            if (listview_data.SelectedItems.Count > 0)
            {
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                InfoProvider ipop = new InfoProvider();
                await ipop.makeLike(this._SongList[index]._SongID);
                this.refreshLikeInfo(this._SongList[index]._SongID);
            }
        }

        private async void button_dislike_Click(object sender, EventArgs e)
        {
            if (listview_data.SelectedItems.Count > 0)
            {
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                InfoProvider ipop = new InfoProvider();
                await ipop.makeDislike(this._SongList[index]._SongID);
                this.refreshDislikeInfo(this._SongList[index]._SongID);
            }
        }

        private void textbox_comment_writer_Click(object sender, EventArgs e)
        {
            textbox_comment_writer.Text = "";
        }

        private void panel_comentario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_previous_Click(object sender, EventArgs e)
        {
            if (listview_data.SelectedItems.Count > 0)
            {
                int index = listview_data.Items.IndexOf(listview_data.SelectedItems[0]);
                if (index > 0)
                {
                    listview_data.Items[index].Selected = false;
                    listview_data.Items[index - 1].Selected = true;
                }
            }
        }

        private void button_play_Click(object sender, EventArgs e)
        {
        }

        private void button__personal_library_Click_1(object sender, EventArgs e)
        {

        }

        private void panel_user_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
