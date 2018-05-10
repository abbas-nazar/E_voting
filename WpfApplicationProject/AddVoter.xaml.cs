using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

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

        private async void submitbtn_Click(object sender, RoutedEventArgs e)
        {
            var res = (Area)areadg.SelectedItem;
            if (fntext.Text == "" || lntext.Text == "" || gendertext.Text == ""
               || agetext.Text == "" || phonetext.Text == "" || edutext.Text == ""
               || occtext.Text == "" || cnictext.Text=="")
            {
                // MessageBox.Show("Good","Alert", MessageBoxButton.OKCancel, MessageBoxImage.Error);

                MessageBox.Show("Please fill all of the fields");
            }

            if (res == null)
            {

                MessageBox.Show("Please select your area");

            }

            else
            {

                Voter V = new Voter()
                {
                    First_Name = fntext.Text,
                    Last_Name = lntext.Text,
                    CNIC = cnictext.Text,
                    Age = agetext.Text,
                    Phone = phonetext.Text,
                    Ocupation = occtext.Text,
                    Gender = gendertext.Text,
                    Vote = "no",
                    AID = res.AID
                };
                string p = res.Area1;
                string c = res.City;
                int vid = 0;
                dc.Voters.InsertOnSubmit(V);
                dc.SubmitChanges();

                var res1 = from q in dc.Voters where q.CNIC == V.CNIC select new { VID = q.VID };

                foreach (var r in res1)
                {
                    vid = r.VID;
                }


                //pbStatus.Visibility = Visibility.Visible;
                //pbStatus.IsIndeterminate = true;
                int a = await message(V.Phone, p, c, vid);
               
                // pbStatus.IsIndeterminate = false;


                //pbStatus.Visibility = Visibility.Hidden;

                MessageBox.Show("Succesfully Added");
               
                fntext.Text = "";
                lntext.Text = "";
                gendertext.Text = "";
                agetext.Text = "";
                edutext.Text = "";
                cnictext.Text = "";
                occtext.Text = "";
                phonetext.Text = "";
               


            }

        }

        private void listbtn_Click(object sender, RoutedEventArgs e)
        {
            ListVoters wp = new ListVoters();
            wp.Show();
            this.Close();
        }

        public async Task<int> message(string n,string p,string c,int vid)
        {
            try
            {

                
                TwilioClient.Init(
                    "AC0275b57e81b23fff88700a0c326c5565",
                    "3858cce993376eef12e45f603de25be7");

                MessageResource.Create(
        to: new PhoneNumber(n),
        from: new PhoneNumber("+15412755684"),
        body: "Your Vote has been registered at "+p+" "+c+"  your Vote ID is "+ vid);
                return 0;
            }
            catch(Exception e)
            {
                return 0;
            }
            
        }
    }
}
