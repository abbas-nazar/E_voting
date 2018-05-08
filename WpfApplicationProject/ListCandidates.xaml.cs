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
    /// Interaction logic for ListCandidates.xaml
    /// </summary>
    public partial class ListCandidates : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public ListCandidates()
        {
            InitializeComponent();
            loaddata();
            
        }

        public void loaddata()
        {
            var res = from q in dc.Canditates
                      select q;

            areadg.ItemsSource = res;
        }
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            AddCandidate wp = new AddCandidate();
            wp.Show();
            this.Close();
        }
    }
}
