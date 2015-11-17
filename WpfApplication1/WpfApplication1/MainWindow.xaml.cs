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
using WMPLib;

namespace WpfApplication1
{
    /// <summary>Sy
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WindowsMediaPlayer Player = new WindowsMediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Player.URL = "https://odysseyblob.blob.core.windows.net/music/7.mp3";
            Player.controls.play();
            //player.Play();
        }

        private void btnOpen_Copy_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
