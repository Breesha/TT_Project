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
            
                LabelEmail.Content = _crudManager.SelectedRider.Email;
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
            string email = LabelEmail.Content.ToString();
            ListBikeEntriesiD.ItemsSource =_crudManager.RetrieveAllBikesDetails().ToString();

        }

        private void PopulateListRaceEntries()
        {
            
            ListViewEntries.ItemsSource = _crudManager.RetrieveAllEntryDetails();
        }

        


        private void ButtEntryAdd_Click(object sender, RoutedEventArgs e)
        {
            string stringID = LabelAddId.Content.ToString();
            int ID =int.Parse(stringID);
            int raceid = 0;
            if((bool)RadioSport.IsChecked)
            {
                raceid = 1;
            }
            else if((bool)RadioStock.IsChecked)
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
            else if((bool)RadioSenior.IsChecked)
            {
                raceid = 5;
            }
            _crudManager.CreateRaceEntry(ID, raceid);
            RadioSport.IsChecked = false;
            RadioStock.IsChecked = false;
            RadioLight.IsChecked=false;
            RadioZero.IsChecked = false;
            RadioSenior.IsChecked = false;
            ListViewEntries.ItemsSource = null;
            PopulateListRaceEntries();
        }

        private void ButtUpd_Click(object sender, RoutedEventArgs e)
        {
            _crudManager.UpdateRider(LabelEmail.Content.ToString(), TextFName.Text, TextLName.Text, TextDofB.Text, TextNation.Text, TextExp.Text);
            //TextFName.Text = "";
            //TextLName.Text = "";
            //TextDofB.Text = "";
            //TextNation.Text = "";
            //TextExp.Text = "";
            PopulateRiderFields(LabelEmail.Content.ToString());
        }

        private void ButtBikeAdd_Click(object sender, RoutedEventArgs e)
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
            PopulateListBikeEntries();
            


        }

        private void ButtEntryDel_Click(object sender, RoutedEventArgs e)
        {
            //if (ListViewEntries.SelectedItem != null)
            //{
                
            //    _crudManager.DeleteEntry();
            //}


        }
    }
}
