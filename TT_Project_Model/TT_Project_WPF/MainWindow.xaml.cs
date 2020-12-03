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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TT_Project_Business;

namespace TT_Project_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        private CRUDManager _crudManager = new CRUDManager();
        public MainWindow()
        {
            InitializeComponent();
            //PopulateListBox();
        }

        //private void PopulateListBox()
        //{
        //    ListViewRiders.ItemsSource = _crudManager.RetrieveAllRider();
        //}

        //private void PopulateRiderFields()
        //{
        //    if (_crudManager.SelectedRider != null)
        //    {
        //        LabelId.Content = _crudManager.SelectedRider.RiderId;
        //        TextFName.Text = _crudManager.SelectedRider.FirstName;
        //        TextLName.Text = _crudManager.SelectedRider.LastName;
        //        TextDofB.Text = _crudManager.SelectedRider.DateOfBirth;
        //        TextNation.Text = _crudManager.SelectedRider.Nationality;
        //        TextExp.Text = _crudManager.SelectedRider.Experience;

        //        LabelAddId.Content = _crudManager.SelectedRider.RiderId;

        //        LabelAddBRId.Content = _crudManager.SelectedRider.RiderId;
        //    }
        //}

        //private void ListBoxRider_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    if (ListViewRiders.SelectedItem != null)
        //    {
        //        _crudManager.SetSelectedRider(ListViewRiders.SelectedItem);
        //        PopulateRiderFields();
        //    }
        //}
    }
}
