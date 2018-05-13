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

namespace WpfApplicationProject
{
    /// <summary>
    /// Interaction logic for adminLogin.xaml
    /// </summary>
    public partial class adminLogin : Window
    {
        public adminLogin()
        {
            InitializeComponent();
        }

        private void submitbtn_Click(object sender, RoutedEventArgs e)
        {
            if(user.Text==""||pass.Password=="")
            {
                MessageBox.Show("Please fill all of the fields");
            }
            else
            {
                if ((user.Text == "abbas" && pass.Password == "abbas123")|| (user.Text == "asfand" && pass.Password == "asfand123"))
                {
                    Admin ad = new Admin();
                    ad.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please check your username and password");
                }
            }

        }
    }
}
