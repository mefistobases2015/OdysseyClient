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
    }
}
