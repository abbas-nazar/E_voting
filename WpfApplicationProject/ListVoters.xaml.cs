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
    /// Interaction logic for ListVoters.xaml
    /// </summary>
    public partial class ListVoters : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public ListVoters()
        {
            InitializeComponent();
            var res = from q in dc.Voters
                      select q;
            //select new
            //{
            //    Province = q.Province,
            //    City = q.City,
            //    Constituency=q.Area1,
            //    AreaID=q.AID

            //};
            areadg.ItemsSource = res;
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            AddVoter wp = new AddVoter();
            wp.Show();
            this.Close();
        }
    }
}
