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
using System.Windows.Shapes;

namespace OdysseyAplication
{
    /// <summary>
    /// Lógica de interacción para window_id3Tool.xaml
    /// </summary>
    public partial class window_id3Tool : Window
    {
        string _Mode { get; set; }
        DataSong _SongToEdit { get; set; }
        List< Version > _MetadataVersion { get; set; }
        InfoProvider _InfoManager { get; set; }
        public window_id3Tool(DataSong pMetadata)
        {
            this._SongToEdit = pMetadata;
            this._InfoManager = new InfoProvider();
            InitializeComponent();
            textbox_artist.Text = pMetadata._ID3Artist;
            textbox_genre.Text = pMetadata._ID3Genre;
            textbox_lyric.Text = pMetadata._ID3Lyrics;
            textbox_title.Text = pMetadata._ID3Title;
            textbox_album.Text = pMetadata._ID3Album;
            //this._MetadataVersion = this._InfoManager.getVersiono();
        }
        public async void chargeVersions()
        {
        }
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void button_createVersion_Click(object sender, RoutedEventArgs e)
        {
            Version version = new Version();
            version.id3v2_album = textbox_album.Text;
            version.id3v2_author = textbox_artist.Text;
            version.id3v2_genre = textbox_genre.Text;
            version.id3v2_lyrics = textbox_lyric.Text;
            version.id3v2_title = textbox_title.Text;
            //version.id3v2_year = textbox_year.Text;
            if (this._Mode == window_main.MODE_CLOUD)
            {
             //   this._InfoManager.createDataSongVersionCloud();
            }
            else if(this._Mode == window_main.MODE_LOCAL)
            {
            //   this._InfoManager.createDataSongVersionCloud();
            }
        }
        private void button_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}