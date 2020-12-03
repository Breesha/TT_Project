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
using TT_Project_Business;

namespace TT_Project_WPF
{
    /// <summary>
    /// Interaction logic for Project_Users.xaml
    /// </summary>
    public partial class Project_Users : Page
    {
        private CRUDManager _crudManager = new CRUDManager();
        public Project_Users()
        {
            InitializeComponent();
            PopulateRiderFields();

        }

        private void PopulateRiderFields()
        {
            if (_crudManager.SelectedRider != null)
            {
                LabelId.Content = _crudManager.SelectedRider.RiderId;
                TextFName.Text = _crudManager.SelectedRider.FirstName;
                TextLName.Text = _crudManager.SelectedRider.LastName;
                TextDofB.Text = _crudManager.SelectedRider.DateOfBirth;
                TextNation.Text = _crudManager.SelectedRider.Nationality;
                TextExp.Text = _crudManager.SelectedRider.Experience;

                LabelAddId.Content = _crudManager.SelectedRider.RiderId;

                LabelAddBRId.Content = _crudManager.SelectedRider.RiderId;
            }
        }

        private void ListBikeEntries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBikeEntries.ItemsSource = _crudManager.RetrieveAllBikes();
        }

        private void ListViewEntries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ListViewEntries.ItemsSource = _crudManager.RetrieveAllEntry();
        }

        private void ButtEntryAdd_Click(object sender, RoutedEventArgs e)
        {
            if(RadioSport.IsEnabled)
            {
                int raceid = 1;
            }
            else if(RadioStock.IsEnabled)
            {
                int raceid = 2;
            }
            else if (RadioLight.IsEnabled)
            {
                int raceid = 3;
            }
            else if (RadioZero.IsEnabled)
            {
                int raceid = 4;
            }
            else if(RadioSenior.IsEnabled)
            {
                int raceid = 5;
            }
            _crudManager.CreateRaceEntry(LabelAddId.Content, raceid);
        }
    }
}
