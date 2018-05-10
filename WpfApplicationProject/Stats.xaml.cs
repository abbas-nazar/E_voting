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
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public Stats()
        {
            InitializeComponent();
           
            int res = (from q in dc.Voters
                       select q).Count();
            totalvoters.Content = res;

            int res1 = (from q in dc.Voters
                        where q.Vote=="yes"
                       select q).Count();
            votedvoters.Content = res1;

            int res2 = (from q in dc.Voters
                        where q.Vote == "yes" && q.Gender=="male"
                        select q).Count();
            malevoters.Content = res2;

            int res3 = (from q in dc.Voters
                        where q.Vote == "yes" && q.Gender == "female"
                        select q).Count();
            femalevoters.Content = res3;

            int res4 = (from q in dc.Voters
                        where q.Vote == "yes" && q.Education!=""
                        select q).Count();
            eduvoters.Content = res4 ;

            int res5 = (from q in dc.Voters
                        where q.Vote == "yes" && q.Education == ""
                        select q).Count();
           noneduvoters.Content = res5;

            loadData();
        }
        public void loadData()
        {
            var res = from q in dc.Areas
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin a = new Admin();
            a.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var res = (Area)areadg.SelectedItem;
            if (res == null)
            {
                MessageBox.Show("Please select an area");
            }
            else
            {
                int res1 = (from q in dc.Voters
                            where q.AID == res.AID
                            select q).Count();


                int res2 = (from q in dc.Voters
                            where q.AID == res.AID && q.Vote == "yes"
                            select q).Count();

                int res3 = (from q in dc.Voters
                            where q.AID == res.AID && q.Vote == "yes" && q.Gender == "male"
                            select q).Count();

                int res4 = (from q in dc.Voters
                            where q.AID == res.AID && q.Vote == "yes" && q.Gender == "female"
                            select q).Count();

                int res5 = (from q in dc.Voters
                            where q.AID == res.AID && q.Vote == "yes" && q.Education != ""
                            select q).Count();

                int res6 = (from q in dc.Voters
                            where q.AID == res.AID && q.Vote == "yes" && q.Education == ""
                            select q).Count();

                MessageBox.Show("Registered Voters in " + res.Area1 + "are" + res1 +
                    "\nVoter Turnout: " + res2 +
                     "\nMale Voters: " + res3 +
                      "\nFemale Voters: " + res4 +
                       "\nEducated Voters: " + res5 +
                        "\nNon Educated Voters: " + res6);
            }
        }
    }
}
