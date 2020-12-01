using System;
using TT_Project_Model;
using System.Collections.Generic;
using System.Linq;


namespace TT_Project_Business
{
    public class CRUDManager
    {
        public Rider SelectRider { get; set; }

        public List<Rider> RetrieveAllRider()
        {
            using (var db = new TT_ProjectContext())
            {
                return db.Riders.ToList();
            }
        }

        public Rider SelectStaff { get; set; }

        public List<staff> RetrieveAllStaff()
        {
            using (var db = new TT_ProjectContext())
            {
                return db.staff.ToList();
            }
        }

        static void Main(string[] args)
        {
            using (var db = new TT_ProjectContext())
            {

            }
        }

        public string CreatRiderAccount(string email, string password)
        {
            using (var db = new TT_ProjectContext())
            {
                if (password.Length > 5)
                {
                    var newRiderAccount = new RiderAccount
                    {
                        Email = email.Trim(),
                        Passwrd = password.Trim()
                    };

                    db.RiderAccounts.Add(newRiderAccount);
                    db.SaveChanges();
                    return "Password accepted";
                }
                else
                {
                    return "Password is too short";
                }
            }
        }

        public void CreateRiderInfo(int riderid, string firstname, string lastname, DateTime dateofbirth, string nationality, string experience)
        {

            using (var db = new TT_ProjectContext())
            {
                var newRider = new Rider
                {
                    FirstName = firstname.Trim(),
                    LastName = lastname.Trim(),
                    DateOfBirth = dateofbirth,
                    Nationality = nationality.Trim(),
                    Experience = experience
                };

                db.Riders.Add(newRider);
                db.SaveChanges();
            }
        }

        public void CreateStaffAccount(string email, string password)
        {
            using (var db = new TT_ProjectContext())
            {
                var newStaffAccount = new StaffAccount
                {
                    Email = email.Trim(),
                    Passwrd = password.Trim()
                };

                db.StaffAccounts.Add(newStaffAccount);
                db.SaveChanges();
            }
        }

        public void CreateStaffInfo(int staffid, string firstname, string lastname)
        {

            using (var db = new TT_ProjectContext())
            {
                var newStaff = new staff
                {
                    FirstName = firstname.Trim(),
                    LastName = lastname.Trim()
                };

                db.staff.Add(newStaff);
                db.SaveChanges();
            }
        }


    }
}
