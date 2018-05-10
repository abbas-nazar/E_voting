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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void goVoterbtn_Click(object sender, RoutedEventArgs e)
        {
            AddVoter wp = new AddVoter();
            wp.Show();
            this.Close();
        }

        private void gocandidatebtn_Click(object sender, RoutedEventArgs e)
        {
            AddCandidate wp = new AddCandidate();
            wp.Show();
            this.Close();
        }

        private void goconstituencybtn_Click(object sender, RoutedEventArgs e)
        {
            AddConstituency wp = new AddConstituency();
            wp.Show();
            this.Close();
        }

        private void stats_Click(object sender, RoutedEventArgs e)
        {
            Stats wp = new Stats();
            wp.Show();
            this.Close();
        }
    }
}
