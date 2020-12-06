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
        //string email;
        public Project_Users()
        {
            InitializeComponent();
            

        }


        public Project_Users(string email) : this()
        {
            string receivedEmail = email;
            PopulateRiderFields(receivedEmail);
            PopulateListRaceEntries(receivedEmail);
            PopulateListBikeEntries(receivedEmail);

        }

        //private void PopulateRiderFields()
        //{
        //    LabelEmail.Content = Application.Current.Resources["Email"];

        //}

        private void PopulateRiderFields(string email)
        {
            _crudManager.setSelectedRider(email);
            
                LabelEmail.Content = _crudManager.SelectedRider.Email;
                LabelId.Content = _crudManager.SelectedRider.RiderId;
                TextFName.Text = _crudManager.SelectedRider.FirstName;
                TextLName.Text = _crudManager.SelectedRider.LastName;
                UpdCalender.SelectedDate = Convert.ToDateTime(_crudManager.SelectedRider.DateOfBirth);
                TextNation.Text = _crudManager.SelectedRider.Nationality;
                TextExp.Text = _crudManager.SelectedRider.Experience;

                LabelAddId.Content = _crudManager.SelectedRider.RiderId;

                LabelAddBRId.Content = _crudManager.SelectedRider.RiderId;
           

        }

        private void PopulateListBikeEntries(string email)
        {
            ListBikeEntriesiD.ItemsSource =_crudManager.RetrieveAllBikesDetails(email);

        }

        private void PopulateListRaceEntries(string email)
        {
            
            ListViewEntries.ItemsSource = _crudManager.RetrieveAllEntryDetails(email);
        }

        


        private void ButtEntryAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)RadioSport.IsChecked == false && (bool)RadioStock.IsChecked == false && (bool)RadioLight.IsChecked == false && (bool)RadioZero.IsChecked == false && (bool)RadioSenior.IsChecked == false)
            {
                PopulateListRaceEntries(LabelEmail.Content.ToString());
            }
            else
            {
                string stringID = LabelAddId.Content.ToString();
                int ID = int.Parse(stringID);
                int raceid = 0;
                if ((bool)RadioSport.IsChecked)
                {
                    raceid = 1;
                }
                else if ((bool)RadioStock.IsChecked)
                {
                    raceid = 2;
                }
                else if ((bool)RadioLight.IsChecked)
                {
                    raceid = 3;
                }
                else if ((bool)RadioZero.IsChecked)
                {
                    raceid = 4;
                }
                else if ((bool)RadioSenior.IsChecked)
                {
                    raceid = 5;
                }
                _crudManager.CreateRaceEntry(ID, raceid);
                RadioSport.IsChecked = false;
                RadioStock.IsChecked = false;
                RadioLight.IsChecked = false;
                RadioZero.IsChecked = false;
                RadioSenior.IsChecked = false;
                ListViewEntries.ItemsSource = null;
                PopulateListRaceEntries(LabelEmail.Content.ToString());
            }
        }

        private void ButtUpd_Click(object sender, RoutedEventArgs e)
        {
            if (TextFName.Text == "" || TextLName.Text =="" || TextNation.Text=="" || TextExp.Text=="")
            {
                PopulateRiderFields(LabelEmail.Content.ToString());
            }
            else
            {
                _crudManager.UpdateRider(LabelEmail.Content.ToString(), TextFName.Text, TextLName.Text, Convert.ToDateTime(UpdCalender.SelectedDate), TextNation.Text, TextExp.Text);
                //TextFName.Text = "";
                //TextLName.Text = "";
                //TextDofB.Text = "";
                //TextNation.Text = "";
                //TextExp.Text = "";
                PopulateRiderFields(LabelEmail.Content.ToString());
            }
        }

        private void ButtBikeAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextBMake.Text == "")
            {
                PopulateListBikeEntries(LabelEmail.Content.ToString());
            }
            else
            {
                var id = int.Parse(LabelAddBRId.Content.ToString());
                var make = TextBMake.Text.Trim();
                var sponsor = TextBSpon.Text.Trim();
                _crudManager.CreateBike(id, make, sponsor);
                TextBMake.Text = "";
                TextBSpon.Text = "";
                ListBikeEntriesiD.ItemsSource = null;
                //ListBikeEntriesMake.ItemsSource = null;
                //ListBikeEntriesSpons.ItemsSource = null;
                PopulateListBikeEntries(LabelEmail.Content.ToString());
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
                PopulateListRaceEntries(LabelEmail.Content.ToString());
            }

        }

        private void ListBikeEntriesiD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBikeEntriesiD.SelectedItem != null)
            {
                _crudManager.SetSelectedBike(ListBikeEntriesiD.SelectedItem);

            }
        }

        private void ButtBikeDel_Click(object sender, RoutedEventArgs e)
        {
            int id = _crudManager.SelectedBike.BikeId;
            _crudManager.DeleteBike(id);
            PopulateListBikeEntries(LabelEmail.Content.ToString());
        }
    }
}
