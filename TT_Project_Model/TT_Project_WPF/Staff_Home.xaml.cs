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
using TT_Project_Model;

namespace TT_Project_WPF
{
    /// <summary>
    /// Interaction logic for Staff_Home.xaml
    /// </summary>
    public partial class Staff_Home : Page
    {
        private CRUDManager _crudManager = new CRUDManager();
        public Staff_Home()
        {
            InitializeComponent();
        }

        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            if (TextRegEmail.Text == "" || TextRegPass.Text == "" || TextRegFNam.Text == "" || TextRegLNam.Text == "")
            {
                LabRegComment.Content = "Every box needs data";
            }
            else if (_crudManager.RetrieveAllEmailsSTAFF().Contains(TextRegEmail.Text))
            {
                LabRegComment.Content = "Rider email already registered";
            }
            else if (TextRegPass.Text.Length < 5)
            {
                LabRegComment.Content = "Password too short, needs 5 characters minimum";
            }
            else
            {
                _crudManager.CreateStaffAccount(TextRegEmail.Text, TextRegPass.Text, TextRegFNam.Text, TextRegLNam.Text);
                Staff_Users staffuserpage = new Staff_Users(TextRegEmail.Text);
                this.NavigationService.Navigate(staffuserpage);
            }
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var email = TextLogEmail.Text;


            if (TextLogEmail.Text == "" || PassLogPass.Password == "")
            {
                LabLogComment.Content = "Every box needs data";
            }
            else
            {
                if (_crudManager.RetrieveAllEmailsPasswordsSTAFF().ContainsKey(TextLogEmail.Text))
                {
                    if (_crudManager.RetrieveAllEmailsPasswordsSTAFF().ContainsValue(PassLogPass.Password))
                    {
                        Staff_Users staffuserpage = new Staff_Users(TextLogEmail.Text);
                        this.NavigationService.Navigate(staffuserpage);
                    }
                    else
                    {
                        LabLogComment.Content = "Incorrect password";
                    }
                }
                else
                {
                    LabLogComment.Content = "Incorrect email";
                }
            }
        }

        
    }
}
