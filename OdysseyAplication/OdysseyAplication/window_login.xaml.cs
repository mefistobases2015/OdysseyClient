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
    /// Lógica de interacción para window_login.xaml
    /// </summary>
    public partial class window_login : Window
    {
        public window_login()
        {
            InitializeComponent();
        }

        private void textBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            window_main main = new window_main();
            main.Show();
            this.Close();
        }
    }
}
