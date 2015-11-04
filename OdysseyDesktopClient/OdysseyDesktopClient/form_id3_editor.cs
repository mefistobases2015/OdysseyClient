using System;
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
    public partial class form_id3_editor : Form
    {
        public const string MODE_LOCAL = "LOCAL";
        public const string MODE_CLOUD = "CLOUD"; 
        string _UserSongName { get; set; }
        public List<Metadata> _OldVersions { get; set; }
        Metadata _MetadataToEdit { get; set; }
        string _UploadMode { get; set; }

        public form_id3_editor(Metadata pMetadata, string pUserPropertary, string pMode)
        {
            this._UserSongName = pUserPropertary;
            this._MetadataToEdit = pMetadata;
            this._UploadMode = pMode;
            InitializeComponent();
            this.paintActualMetadata();
        }

        private void paintActualMetadata()
        {
            textbox_title.Text =   this._MetadataToEdit._ID3Title;
            textbox_genre.Text =   this._MetadataToEdit._ID3Genre;
            textbox_artist.Text =  this._MetadataToEdit._ID3Artist;
            textbox_lyric.Text =   this._MetadataToEdit._ID3Lyrics;
            textbox_year.Text =    this._MetadataToEdit._ID3Year;
            textbox_comment.Text = this._MetadataToEdit._ID3Comment;
            textbox_album.Text =   this._MetadataToEdit._ID3Album;
        }

        private void form_id3_editor_Load(object sender, EventArgs e)
        {
            
        }

        private void panel_biblioteca_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button__apply_Click(object sender, EventArgs e)
        {
            this.saveMetadata();
            InfoProvider ipop = new InfoProvider();
            if (this._UploadMode == form_id3_editor.MODE_CLOUD)
            {
                ipop.createMetadataVersionCloud(this._MetadataToEdit);
            }
            if(this._UploadMode == form_id3_editor.MODE_LOCAL)
            {
                ipop.createMetadataVersionLocal(this._MetadataToEdit);
            }
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveMetadata()
        {
            this._MetadataToEdit._ID3Title = textbox_title.Text;
            this._MetadataToEdit._ID3Artist = textbox_artist.Text;
            this._MetadataToEdit._ID3Album = textbox_album.Text;
            this._MetadataToEdit._ID3Genre = textbox_genre.Text;
            this._MetadataToEdit._ID3Year = textbox_year.Text;
            this._MetadataToEdit._ID3Lyrics = textbox_lyric.Text;
            this._MetadataToEdit._ID3Comment = textbox_comment.Text;
        }

        private void textbox_comment_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_album_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_genre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_artist_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_title_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_year_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
