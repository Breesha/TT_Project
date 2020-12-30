using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TT_Project_WPF
{
    /// <summary>
    /// Interaction logic for Staff_Rider_Selection.xaml
    /// </summary>
    public partial class Staff_Rider_Selection : Page
    {
        public Staff_Rider_Selection()
        {
            InitializeComponent();
        }

        private void StaffButton_Click(object sender, RoutedEventArgs e)
        {
            Staff_Home staffHomePage = new Staff_Home();
            this.NavigationService.Navigate(staffHomePage);
        }

        private void RiderButton_Click(object sender, RoutedEventArgs e)
        {
            Project_Home riderHomePage = new Project_Home();
            this.NavigationService.Navigate(riderHomePage);
        }
    }
}
