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
    /// Interaction logic for Project_Home.xaml
    /// </summary>
    public partial class Project_Home : Page
    {
        private CRUDManager _crudManager = new CRUDManager();
        public Project_Home()
        {
            InitializeComponent();
        }

        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            if (TextRegEmail.Text == "" || TextRegPass.Text == "" || TextRegFNam.Text == "" || TextRegLNam.Text == "" || TextRegDofB.Text == "" || TextRegNat.Text == "" || TextRegExp.Text == "")
            {
                LabRegComment.Content = "Every box needs data";
            }
            else if(_crudManager.RetrieveAllEmails().Contains(TextRegEmail.Text))
            {
                LabRegComment.Content = "Rider email already registered";
            }
            else
            {
                _crudManager.CreateRiderAccount(TextRegEmail.Text, TextRegPass.Text, TextRegFNam.Text, TextRegLNam.Text, TextRegDofB.Text, TextRegNat.Text, TextRegExp.Text);
                LabRegComment.Content = "";
                TextRegEmail.Text = "";
                TextRegPass.Text = "";
                TextRegFNam.Text = "";
                TextRegLNam.Text = "";
                TextRegDofB.Text = "";
                TextRegNat.Text = "";
                TextRegExp.Text = "";
                Project_Users projectuserpage = new Project_Users();
                this.NavigationService.Navigate(projectuserpage);

            }
            
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            Project_Users projectuserpage = new Project_Users();
            this.NavigationService.Navigate(projectuserpage);
        }
    }
}
