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
    /// Interaction logic for AddConstituency.xaml
    /// </summary>
    public partial class AddConstituency : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public AddConstituency()
        {
            InitializeComponent();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Admin wp = new Admin();
            wp.Show();
            this.Close();
        }

        private void submitbtn_Click(object sender, RoutedEventArgs e)
        {

            if (provtext.Text == "" || citytext.Text == "" || areacodetext.Text == "")
            {
                // MessageBox.Show("Good","Alert", MessageBoxButton.OKCancel, MessageBoxImage.Error);

                MessageBox.Show( "Please Fill all of the fields");
            }

            else
            {
                Area a = new Area()
                {
                    Province = provtext.Text,
                    City = citytext.Text,
                    Area1 = areacodetext.Text
                };
                
                dc.Areas.InsertOnSubmit(a);
                dc.SubmitChanges();
                MessageBox.Show("Area has been added successfully");
                provtext.Text = "";
                citytext.Text = "";
                areacodetext.Text = "";
            }
        }

        private void listbtn_Click(object sender, RoutedEventArgs e)
        {
            ListAreas wp = new ListAreas();
            wp.Show();
            this.Close();
        }
    }
}
