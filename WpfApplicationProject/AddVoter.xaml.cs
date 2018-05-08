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
    /// Interaction logic for AddVoter.xaml
    /// </summary>
    public partial class AddVoter : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public AddVoter()
        {
            InitializeComponent();
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

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Admin wp = new Admin();
            wp.Show();
            this.Close();
        }

        private void submitbtn_Click(object sender, RoutedEventArgs e)
        {
            var res = (Area)areadg.SelectedItem;

            Voter V = new Voter()
            {
                First_Name = fntext.Text,
                Last_Name = lntext.Text,
                CNIC = cnictext.Text,
                Age = agetext.Text,
                Phone = phonetext.Text,
                Ocupation = occtext.Text,
                Education = edutext.Text,
                Gender = gendertext.Text,
                Vote="no",
                AID = res.AID
            };

            dc.Voters.InsertOnSubmit(V);
            dc.SubmitChanges();
         }

        private void listbtn_Click(object sender, RoutedEventArgs e)
        {
            ListVoters wp = new ListVoters();
            wp.Show();
            this.Close();
        }
    }
}
