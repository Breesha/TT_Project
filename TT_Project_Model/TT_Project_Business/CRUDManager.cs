using System;
using TT_Project_Model;
using System.Collections.Generic;
using System.Linq;


namespace TT_Project_Business
{
    public class CRUDManager
    {
        public RiderAccount SelectedRider { get; set; }

        public void SetSelectedRider(object selectedItem)
        {
            SelectedRider = (RiderAccount)selectedItem;
        }

        public List<RiderAccount> RetrieveAllRider()
        {
            using (var db = new TT_ProjectContext())
            {
                return db.RiderAccounts.ToList();
            }
        }

        public StaffAccount SelectedStaff { get; set; }

        public List<string> RetrieveAllEmails()
        {
            using (var db = new TT_ProjectContext())
            {
                List<string> emailList = new List<string>();
                foreach (var item in db.RiderAccounts)
                {
                    emailList.Add(item.Email);
                }
                return emailList;
                
            }
        }

        public Dictionary<string, string> RetrieveAllEmailsPasswords()
        {
            using (var db = new TT_ProjectContext())
            {
                Dictionary<string, string> emailPass = new Dictionary<string, string>();
                foreach (var item in db.RiderAccounts)
                {
                    emailPass.Add(item.Email, item.Passwrd);
                }
                return emailPass;

            }
        }

        public List<Entry> RetrieveAllEntry()
        {
            using (var db = new TT_ProjectContext())
            {
                return db.Entries.ToList();
            }
        }

        public List<Bike> RetrieveAllBikes()
        {
            using (var db = new TT_ProjectContext())
            {
                return db.Bikes.ToList();
            }
        }


        static void Main(string[] args)
        {
            using (var db = new TT_ProjectContext())
            {

            }
        }

        public void CreateRiderAccount(string email, string password, string firstname, string lastname, string dateofbirth, string nationality, string experience)
        {
            using (var db = new TT_ProjectContext())
            {
                //string message = "";

                //foreach (var item in db.RiderAccounts)
                //{
                //    if (item.Email == email)
                //    {
                //        message = "Email already used";
                //    }
                
                
                    var newRiderAccount = new RiderAccount
                    {
                        Email = email.Trim(),
                        Passwrd = password.Trim(),
                        FirstName = firstname.Trim(),
                        LastName = lastname.Trim(),
                        DateOfBirth = dateofbirth,
                        Nationality = nationality.Trim(),
                        Experience = experience.Trim()
                    };
                var dOfB = Convert.ToDateTime(dateofbirth);
                if (((DateTime.Now-dOfB).TotalDays/365)>=21 && password.Length>5)
                {
                    db.RiderAccounts.Add(newRiderAccount);
                    db.SaveChanges();
                }
                else
                {
                    db.SaveChanges();
                }
                
            }
        }

      

        public void CreateStaffAccount(string email, string password, string firstname, string lastname)
        {
            using (var db = new TT_ProjectContext())
            {
                var newStaffAccount = new StaffAccount
                {
                    Email = email.Trim(),
                    Passwrd = password.Trim(),
                    FirstName = firstname.Trim(),
                    LastName = lastname.Trim()
                };

                db.StaffAccounts.Add(newStaffAccount);
                db.SaveChanges();
            }
        }

        public void CreateBike(int riderid, string make, string sponsor)
        {
            using (var db = new TT_ProjectContext())
            {
                var newBike = new Bike
                {
                    RiderId = riderid,
                    BikeMake = make.Trim(),
                    BikeSponsor = sponsor.Trim()
                };

                db.Bikes.Add(newBike);
                db.SaveChanges();
            }
        }

        public void DeleteBike(int bikeid)
        {

            using (var db = new TT_ProjectContext())
            {
                var selectedBike =
            from b in db.Bikes
            where b.BikeId == bikeid
            select b;

                db.Bikes.RemoveRange(selectedBike);


                db.SaveChanges();
            }
        }

        public void CreateRaceEntry(int riderid, int raceid)
        {

            using (var db = new TT_ProjectContext())
            {
                var newEntry = new Entry
                {
                    RiderId = riderid,
                    RaceId = raceid
                };
                
                    db.Entries.Add(newEntry);
                    db.SaveChanges();
                

                //foreach (var item in db.Entries)
                //{
                //    if(item.RiderId==riderid && item.RaceId== raceid)
                //    {
                //        db.Entries.Remove(newEntry);
                //        db.SaveChanges();
                //    }
                   
                //}
                
            }
        }

        public void DeleteEntry(int entryid)
        {

            using (var db = new TT_ProjectContext())
            {
                var selectedEntry =
            from e in db.Entries
            where e.EntryId == entryid
            select e;

                db.Entries.RemoveRange(selectedEntry);
                db.SaveChanges();
            }
        }

    }
}



//public void CreateStaffInfo(int staffid, string firstname, string lastname)
//{

//    using (var db = new TT_ProjectContext())
//    {
//        var newStaff = new staff
//        {
//            FirstName = firstname.Trim(),
//            LastName = lastname.Trim()
//        };

//        db.staff.Add(newStaff);
//        db.SaveChanges();
//    }
//}
