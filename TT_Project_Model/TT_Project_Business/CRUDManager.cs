using System;
using TT_Project_Model;
using System.Collections.Generic;
using System.Linq;


namespace TT_Project_Business
{
    public class CRUDManager
    {
        private IRiderAccountService _service;

        public CRUDManager(IRiderAccountService service)
        {
            if (service==null)
            {
                throw new NotImplementedException();
            }

            _service = service;
        }

        public CRUDManager()
        {
            _service = new RiderAccountService(new TT_ProjectContext());
        }

        public RiderAccount SelectedRider { get; set; }


        public void SetSelectedRider(object selectedItem)
        {
            SelectedRider = (RiderAccount)selectedItem;
        }

        public void ChoosingSelectedRider(string email)
        {
            SelectedRider = _service.GetRiderAccountByEmail(email);
        }

        public RiderAccount RetrieveSelectedRiderAccount(int riderID)
        {
            // for Moq tests only
            return _service.GetRiderAccountByID(riderID);
        }

        public Entry SelectedEntry { get; set; }

        public void SetSelectedEntry(object selectedItem)
        {
            SelectedEntry = (Entry)selectedItem;
        }

        public Bike SelectedBike { get; set; }

        public void SetSelectedBike(object selectedItem)
        {
            SelectedBike = (Bike)selectedItem;
        }


        public List<RiderAccount> RetrieveAllRider()
        {
            return _service.GetRiderAccountList();
        }


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

        

        public List<Entry> RetrieveAllEntryDetails(string email)
        {
            using (var db = new TT_ProjectContext())
            {
                return (from e in db.Entries
                        join ra in db.RiderAccounts on e.RiderId equals ra.RiderId
                        where ra.Email == email
                        select e).ToList();
            }
        }

        public List<Bike> RetrieveAllBikesDetails(string email)
        {
            using (var db = new TT_ProjectContext())
            {
                return (from b in db.Bikes
                        join ra in db.RiderAccounts on b.RiderId equals ra.RiderId
                        where ra.Email == email
                        select b).ToList();
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

        public void CreateRiderAccount(string email, string password, string firstname, string lastname, DateTime dateofbirth, string nationality, string experience)
        {
                    var newRiderAccount = new RiderAccount()
                    {
                        Email = email.Trim(),
                        Passwrd = password.Trim(),
                        FirstName = firstname.Trim(),
                        LastName = lastname.Trim(),
                        DateOfBirth = dateofbirth.ToShortDateString(),
                        Nationality = nationality.Trim(),
                        Experience = experience.Trim()
                    };

            _service.CreateRiderAccount(newRiderAccount);
        }

        public void UpdateRider(string email, string firstname, string lastname, DateTime dateofbirth, string nationality, string experience)
        {
                SelectedRider = _service.GetRiderAccountByEmail(email);
                
                SelectedRider.FirstName = firstname;
                SelectedRider.LastName = lastname;
                SelectedRider.DateOfBirth = dateofbirth.ToShortDateString();
                SelectedRider.Nationality = nationality;
                SelectedRider.Experience = experience;

            _service.UpdateRider();
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



        //RIDER INFORMATION ABOVE
        //STAFF INFORMATION BELOW



        public StaffAccount SelectedStaff { get; set; }

        public void SetSelectedStaff(object selectedItem)
        {
            SelectedStaff = (StaffAccount)selectedItem;
        }

        public void ChoosingSelectedStaff(string email)
        {
            using (var db = new TT_ProjectContext())
            {
                SelectedStaff = db.StaffAccounts.Where(e => e.Email.Trim() == email.Trim()).FirstOrDefault();
            }
        }

        public List<StaffAccount> RetrieveAllStaff()
        {
            using (var db = new TT_ProjectContext())
            {
                return db.StaffAccounts.ToList();
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

        public List<string> RetrieveAllEmailsSTAFF()
        {
            using (var db = new TT_ProjectContext())
            {
                List<string> emailListSTAFF = new List<string>();
                foreach (var item in db.StaffAccounts)
                {
                    emailListSTAFF.Add(item.Email);
                }
                return emailListSTAFF;

            }
        }

        public Dictionary<string, string> RetrieveAllEmailsPasswordsSTAFF()
        {
            using (var db = new TT_ProjectContext())
            {
                Dictionary<string, string> emailPassSTAFF = new Dictionary<string, string>();
                foreach (var item in db.StaffAccounts)
                {
                    emailPassSTAFF.Add(item.Email, item.Passwrd);
                }
                return emailPassSTAFF;
            }
        }

        public void UpdateStaff(string email, string firstname, string lastname)
        {
            using (var db = new TT_ProjectContext())
            {
                SelectedStaff = db.StaffAccounts.Where(c => c.Email == email).FirstOrDefault();
                
                SelectedStaff.FirstName = firstname;
                SelectedStaff.LastName = lastname;

                db.SaveChanges();
            }
        }

        public void DeleteRider(int riderId)
        {
            _service.DeleteRiderAccount(riderId);
        }
    }
}
