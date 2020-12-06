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
            if (TextRegEmail.Text == "" || TextRegPass.Text == "" || TextRegFNam.Text == "" || TextRegLNam.Text == "" || !RegCalender.IsInitialized || TextRegNat.Text == "" || TextRegExp.Text == "")
            {
                LabRegComment.Content = "Every box needs data";
            }
            else if(_crudManager.RetrieveAllEmails().Contains(TextRegEmail.Text))
            {
                LabRegComment.Content = "Rider email already registered";
            }
            else if(TextRegPass.Text.Length<5 )
            {
                LabRegComment.Content = "Password too short, needs 5 characters minimum";
            }
            else if((DateTime.Now- Convert.ToDateTime(RegCalender.SelectedDate)).TotalDays/365<=21)
            {
                LabRegComment.Content = "Too young to register, must be 21 and over";
            }
            else
            {
                _crudManager.CreateRiderAccount(TextRegEmail.Text, TextRegPass.Text, TextRegFNam.Text, TextRegLNam.Text, Convert.ToDateTime(RegCalender.SelectedDate), TextRegNat.Text, TextRegExp.Text);
                //object selected = _crudManager.CreateRiderAccount(TextRegEmail.Text, TextRegPass.Text, TextRegFNam.Text, TextRegLNam.Text, TextRegDofB.Text, TextRegNat.Text, TextRegExp.Text);
                //_crudManager.RetrieveAllEmails().Contains(TextRegEmail.Text);
                //_crudManager.RetrieveAllRider();
                //LabRegComment.Content = "";
                //TextRegEmail.Text = "";
                //TextRegPass.Text = "";
                //TextRegFNam.Text = "";
                //TextRegLNam.Text = "";
                //TextRegDofB.Text = "";
                //TextRegNat.Text = "";
                //TextRegExp.Text = "";
                Project_Users projectuserpage = new Project_Users(TextRegEmail.Text);
                this.NavigationService.Navigate(projectuserpage);

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
                if (_crudManager.RetrieveAllEmailsPasswords().ContainsKey(TextLogEmail.Text))
                {
                    if (_crudManager.RetrieveAllEmailsPasswords().ContainsValue(PassLogPass.Password))
                    {
                        //var selected = _crudManager.RetrieveAllEmails().Contains(TextLogEmail.Text);
                        //Application.Current.Resources.Add("Email", TextLogEmail.Text);
                        Project_Users projectuserpage = new Project_Users(TextLogEmail.Text);
                        this.NavigationService.Navigate(projectuserpage);
                    }
                    else
                    {
                        LabLogComment.Content = "Wrong password";
                    }
                }
                else
                {
                    LabLogComment.Content = "Wrong email";
                }
            }
            
        }
    }
}
