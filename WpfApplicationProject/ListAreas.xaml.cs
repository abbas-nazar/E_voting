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
    /// Interaction logic for ListAreas.xaml
    /// </summary>
    public partial class ListAreas : Window
    {

        DataClasses1DataContext dc = new DataClasses1DataContext();
        public ListAreas()
        {
            InitializeComponent();
            loaddata();

            
        }

        public void loaddata()
        {
            var res = from q in dc.Areas
                      select q;

            areadg.ItemsSource = res;
        }
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            AddConstituency wp = new AddConstituency();
            wp.Show();
            this.Close();
        }
    }
}
