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
    /// Lógica de interacción para window_friends.xaml
    /// </summary>
    public partial class window_friends : Window
    {
        InfoProvider _InfoManager { get; set; }
        public string _SignedUser { get; set; }
        public window_friends(string pUsername)
        {
            this._SignedUser = pUsername;
            InitializeComponent();
        }
        private async void button_friends_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = (await this._InfoManager.getFriendByUser(this._SignedUser));
            listView.Items.Clear();
            foreach (string m8 in list)
            {
                listView.Items.Add(m8);
            }
        }

        private async void button_friend_request_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = (await this._InfoManager.getFriendRequestByUser(this._SignedUser));
            listView.Items.Clear();
            foreach(string m8 in list)
            {
                listView.Items.Add(m8);
            }
        }

        private async void button_recomendations_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = (await this._InfoManager.getFriendRequestByUser(this._SignedUser));
            listView.Items.Clear();
            foreach (string m8 in list)
            {
                listView.Items.Add(m8);
            };
        }
    }
}
