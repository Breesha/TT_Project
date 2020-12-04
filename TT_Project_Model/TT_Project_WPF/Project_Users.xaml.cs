using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace TT_Project_WPF
{
    /// <summary>
    /// Interaction logic for Project_Users.xaml
    /// </summary>
    public partial class Project_Users : Page
    {
        private CRUDManager _crudManager = new CRUDManager();
        string email;
        public Project_Users()
        {
            InitializeComponent();
            PopulateListBikeEntries();
            PopulateListRaceEntries();

        }


        public Project_Users(string email) : this()
        {
            string receivedEmail = email;
            PopulateRiderFields(receivedEmail);

        }

        //private void PopulateRiderFields()
        //{
        //    LabelEmail.Content = Application.Current.Resources["Email"];

        //}

        private void PopulateRiderFields(string email)
        {
            _crudManager.setSelectedRider(email);
            LabelId.Content = _crudManager.SelectedRider.RiderId;
            TextFName.Text = _crudManager.SelectedRider.FirstName;
            TextLName.Text = _crudManager.SelectedRider.LastName;
            TextDofB.Text = _crudManager.SelectedRider.DateOfBirth;
            TextNation.Text = _crudManager.SelectedRider.Nationality;
            TextExp.Text = _crudManager.SelectedRider.Experience;

            LabelAddId.Content = _crudManager.SelectedRider.RiderId;

            LabelAddBRId.Content = _crudManager.SelectedRider.RiderId;

        }

        private void PopulateListBikeEntries()
        {

            ListBikeEntries.ItemsSource = _crudManager.RetrieveAllBikes();
        }

        private void PopulateListRaceEntries()
        {
            ListViewEntries.ItemsSource = _crudManager.RetrieveAllSpecificEntry();
        }

        //object sender, SelectionChangedEventArgs e

        private void ListViewEntries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SqlCommand cmd = new SqlCommand('select * from Entries where RiderID=1');
            ListViewEntries.ItemsSource = _crudManager.RetrieveAllSpecificEntry();
            
                if (ListViewEntries.SelectedItem != null)
                {
                    _crudManager.SetSelectedRider(ListViewEntries.SelectedItem);
                }
        }

        private void ListBikeEntries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SqlCommand cmd = new SqlCommand('select * from Entries where RiderID=1');
            ListBikeEntries.ItemsSource = _crudManager.RetrieveAllBikes();

            if (ListBikeEntries.SelectedItem != null)
            {
                _crudManager.SetSelectedRider(ListBikeEntries.SelectedItem);
            }
        }

        private void ButtEntryAdd_Click(object sender, RoutedEventArgs e)
        {
            string stringID = LabelAddId.Content.ToString();
            int ID =int.Parse(stringID);
            int raceid = 0;
            if(RadioSport.IsEnabled)
            {
                raceid = 1;
            }
            else if(RadioStock.IsEnabled)
            {
                raceid = 2;
            }
            else if (RadioLight.IsEnabled)
            {
                raceid = 3;
            }
            else if (RadioZero.IsEnabled)
            {
                raceid = 4;
            }
            else if(RadioSenior.IsEnabled)
            {
                raceid = 5;
            }
            _crudManager.CreateRaceEntry(ID, raceid);
            RadioSport.IsChecked = false;
            RadioStock.IsChecked = false;
            RadioLight.IsChecked=false;
            RadioZero.IsChecked = false;
            RadioSenior.IsChecked = false;
        }

        private void ButtUpd_Click(object sender, RoutedEventArgs e)
        {
            _crudManager.UpdateRider(LabelEmail.Content.ToString(), TextFName.Text, TextLName.Text, TextDofB.Text, TextNation.Text, TextExp.Text);
            PopulateRiderFields(LabelEmail.Content.ToString());
        }
    }
}
