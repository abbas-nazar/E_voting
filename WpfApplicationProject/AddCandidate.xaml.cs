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
    /// Interaction logic for AddCandidate.xaml
    /// </summary>
    public partial class AddCandidate : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public AddCandidate()
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
                      //    Constituency = q.Area1

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


            if (fntext.Text == "" || lntext.Text == "" || gendertext.Text == ""
                ||agetext.Text==""||educationtext.Text==""||cnictext.Text==""
                ||partytext.Text=="")
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
                Canditate V = new Canditate()
                {
                    First_Name = fntext.Text,
                    Last_Name = lntext.Text,
                    Gender = gendertext.Text,
                    Age = agetext.Text,
                    Education = educationtext.Text,
                    CNIC = cnictext.Text,
                    Party = partytext.Text,
                    AID = res.AID
                };

                dc.Canditates.InsertOnSubmit(V);
                dc.SubmitChanges();
                MessageBox.Show("Succesfully Added");
                fntext.Text = "";
                lntext.Text = "";
                gendertext.Text = "";
                agetext.Text = "";
                educationtext.Text = "";
                cnictext.Text = "";
                partytext.Text = "";
            }
        }

        private void listbtn_Click(object sender, RoutedEventArgs e)
        {
            ListCandidates wp = new ListCandidates();
            wp.Show();
            this.Close();
        }
    }
    
}
