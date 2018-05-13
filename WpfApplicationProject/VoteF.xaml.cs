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
    /// Interaction logic for VoteF.xaml
    /// </summary>
    public partial class VoteF : Window
    {
        public VoteF()
        {
            InitializeComponent();
        }

        private void submitbtn_Click(object sender, RoutedEventArgs e)
        {

            if (vID.Text == "" || CNIC.Text == "" || Phone_No.Text == "")
            {
                MessageBox.Show("Please fill all of the fields");
            }
            else
            {

                DataClasses1DataContext dc = new DataClasses1DataContext();
                int vid = Convert.ToInt16(vID.Text);
                string cnic = CNIC.Text;
                string phone = Phone_No.Text;


                var res = from q in dc.Voters
                          where q.VID == vid
                          where q.CNIC == cnic
                          where q.Phone == phone
                          select new
                          {
                              VID = q.VID,
                              AID = q.AID,
                              vote = q.Vote
                          };
                foreach (var r in res)
                {
                    if (r.vote.Equals("yes"))
                    {
                        MessageBox.Show("Already Voted");
                    }
                    else
                    {
                        VotePannel v = new VotePannel(r.VID, r.AID);
                        v.Show();
                        this.Close();
                    }

                }




            }
        }
    }
}
