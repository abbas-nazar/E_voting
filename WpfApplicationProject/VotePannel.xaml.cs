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
    /// Interaction logic for VotePannel.xaml
    /// </summary>
    public partial class VotePannel : Window
    {
        int b, a;
        public VotePannel(int v,int a)
        {
            InitializeComponent();
            this.a = a;
            this.b = v;
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var res = from q in dc.Canditates where q.AID==a
                      select new
                      {
                          First_Name = q.First_Name,
                          Last_Name = q.Last_Name,
                          Party = q.Area.Area1
                      };
            vote.ItemsSource = res;
            
        }

        private void vte_Click(object sender, RoutedEventArgs e)
        {

            DataClasses1DataContext dc = new DataClasses1DataContext();
            Vote v = new Vote()
            {
                AID=a,
                VID=b
            };
            var r = from q in dc.Voters where q.VID == v.VID select q;
            foreach(var re in r)
            {
                re.Vote = "yes";
                dc.SubmitChanges();
            }
            dc.Votes.InsertOnSubmit(v);

            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
