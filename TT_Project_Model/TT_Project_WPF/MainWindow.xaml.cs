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
    public partial class MainWindow : Window
    {
        private CRUDManager _crudManager = new CRUDManager();
        public MainWindow()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            ListViewRiders.ItemsSource = _crudManager.RetrieveAllRider();
        }

        private void PopulateRiderFields()
        {
            if (_crudManager.SelectedRider != null)
            {
                LabelId.Content = _crudManager.SelectedRider.RiderId;
                LabelFName.Content = _crudManager.SelectedRider.FirstName;
                LabelLName.Content = _crudManager.SelectedRider.LastName;
                LabelDofB.Content = _crudManager.SelectedRider.DateOfBirth;
                LabelNation.Content = _crudManager.SelectedRider.Nationality;
                LabelExp.Content = _crudManager.SelectedRider.Experience;
            }
        }

        private void ListBoxCustomer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListViewRiders.SelectedItem != null)
            {
                _crudManager.SelectedRider(ListViewRiders.SelectedItem);
                PopulateRiderFields();
            }
        }
    }
}
