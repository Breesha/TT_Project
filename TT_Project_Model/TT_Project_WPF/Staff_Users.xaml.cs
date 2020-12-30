using System;
using System.Collections.Generic;
using System.Linq;
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
using TT_Project_Business;
using TT_Project_Model;

namespace TT_Project_WPF
{
    /// <summary>
    /// Interaction logic for Staff_Users.xaml
    /// </summary>
    public partial class Staff_Users : Page
    {
        private CRUDManager _crudManager = new CRUDManager();
        public Staff_Users()
        {
            InitializeComponent();
            PopulateListRiders();
        }

        public Staff_Users(string email) : this()
        {
            string receivedEmail = email;
            PopulateStaffFields(receivedEmail);
        }

        private void PopulateStaffFields(string email)
        {
            _crudManager.setSelectedStaff(email);

            LabelEmail.Content = _crudManager.SelectedStaff.Email;
            LabelId.Content = _crudManager.SelectedStaff.StaffId;
            TextFName.Text = _crudManager.SelectedStaff.FirstName;
            TextLName.Text = _crudManager.SelectedStaff.LastName;
        }

        private void PopulateRiderFields(string email)
        {
            _crudManager.setSelectedRider(email);

            RiderLabelId.Content = _crudManager.SelectedRider.RiderId;
            RiderTextFName.Text = _crudManager.SelectedRider.FirstName;
            RiderTextLName.Text = _crudManager.SelectedRider.LastName;
            UpdCalender.SelectedDate = Convert.ToDateTime(_crudManager.SelectedRider.DateOfBirth);
            TextNation.Text = _crudManager.SelectedRider.Nationality;
            TextExp.Text = _crudManager.SelectedRider.Experience;
        }

        private void PopulateListRaceEntries(string email)
        {
            ListViewEntries.ItemsSource = _crudManager.RetrieveAllEntryDetails(email);

            List<string> entRacNum = new List<string>();
            foreach (var item in ListViewEntries.Items)
            {
                entRacNum.Add(item.ToString());
            }
            
            if (entRacNum.Count != entRacNum.Distinct().Count())
            {
                ListViewEntries.Background = Brushes.Red;
            }
            else
            {
                ListViewEntries.Background = Brushes.White;
            }
        }

        private void PopulateListBikeEntries(string email)
        {
            ListViewBikes.ItemsSource = _crudManager.RetrieveAllBikesDetails(email);

        }

        private void ButtUpd_Click(object sender, RoutedEventArgs e)
        {
            if (TextFName.Text == "" || TextLName.Text == "" )
            {
                PopulateStaffFields(LabelEmail.Content.ToString());
            }
            else
            {
                _crudManager.UpdateStaff(LabelEmail.Content.ToString(), TextFName.Text, TextLName.Text);
                
                PopulateStaffFields(LabelEmail.Content.ToString());
            }
        }

        private void PopulateListRiders()
        {
            ListViewRiders.ItemsSource = _crudManager.RetrieveAllRider();
        }

        private void ListViewRiders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewRiders.SelectedItem != null)
            {
                _crudManager.SetSelectedRider(ListViewRiders.SelectedItem);
                var receivedEmail = _crudManager.SelectedRider.Email;
                PopulateRiderFields(receivedEmail);
                PopulateListRaceEntries(receivedEmail);
                PopulateListBikeEntries(receivedEmail);
            }
        }

        private void ListViewEntries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewEntries.SelectedItem != null)
            {
                _crudManager.SetSelectedEntry(ListViewEntries.SelectedItem);
            }
        }

        private void ButtEntryDel_Click(object sender, RoutedEventArgs e)
        {
                if (ListViewEntries.SelectedItem != null)
                {
                    int id = _crudManager.SelectedEntry.EntryId;
                    _crudManager.DeleteEntry(id);
                    var rideremail = _crudManager.SelectedRider.Email;
                    PopulateListRaceEntries(rideremail);
                }
        }

        private void ListViewBikes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewBikes.SelectedItem != null)
            {
                _crudManager.SetSelectedBike(ListViewBikes.SelectedItem);

            }
        }

        private void ButtBikeDel_Click(object sender, RoutedEventArgs e)
        {
            int id = _crudManager.SelectedBike.BikeId;
            _crudManager.DeleteBike(id);
            var rideremail = _crudManager.SelectedRider.Email;
            PopulateListBikeEntries(rideremail);
        }

        private void ButtRiderDel_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewRiders.SelectedItem != null)
            {

                int id = _crudManager.SelectedRider.RiderId;
                _crudManager.DeleteRider(id);

                RiderLabelId.Content = "";
                RiderTextFName.Text = "";
                RiderTextLName.Text = "";
                TextNation.Text = "";
                TextExp.Text = "";

                PopulateListRiders();
            }
        }
    }
}
