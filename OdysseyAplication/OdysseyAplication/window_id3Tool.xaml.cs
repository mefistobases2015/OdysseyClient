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
    }
}
