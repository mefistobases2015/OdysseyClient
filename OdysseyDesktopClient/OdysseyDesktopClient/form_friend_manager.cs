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
    public partial class form_friend_manager : Form
    {
        string _UserSigned { get; set; }
        public form_friend_manager(String pUser)
        {
            this._UserSigned = pUser;
            InitializeComponent();
        }

        private void form_friend_manager_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_friend_Click(object sender, EventArgs e)
        {
            button_accept.Enabled = false;
            button_decline.Enabled = false;
        }

        private void button_friend_request_Click(object sender, EventArgs e)
        {
            button_accept.Enabled = true;
            button_decline.Enabled = true;
            this.showFriendCircle(this._UserSigned);
        }

        private void button_suggestion_Click(object sender, EventArgs e)
        {
            button_accept.Enabled = true;
            button_decline.Enabled = true;
            this.showFriendRequest(this._UserSigned);
        }

        private async void showFriendRequest(string pUsername)
        {
            InfoProvider ipop = new InfoProvider();
            //ipop.g
        }

        private async void showFriendCircle(string pUsername)
        {
            InfoProvider ipop = new InfoProvider();
            //ipop.g
        }
    }
}
