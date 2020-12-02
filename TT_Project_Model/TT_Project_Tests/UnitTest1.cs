using NUnit.Framework;
using System.Linq;
using TT_Project_Model;
using TT_Project_Business;

namespace TT_Project_Tests
{
    public class Tests
    {
		CRUDManager _crudManager = new CRUDManager();

		[SetUp]
        public void Setup()
        {
            using (var db = new TT_ProjectContext())
            {
                //var newRider = new RiderAccount
                //{
                //    Email = "breeshafoxton@hotmail.com",
                //    Passwrd = "password",
                //    FirstName = "Breesha",
                //    LastName = "Foxton",
                //    DateOfBirth = "24/06/1998",
                //    Nationality = "Manx",
                //    Experience = "no rider experience"
                //};
                //db.RiderAccounts.Add(newRider);
                //db.SaveChanges();

                
            }
        }

		[TearDown]

		public void TearDown()
		{
			using (var db = new TT_ProjectContext())
			{

                var selectedRider =
                from ra in db.RiderAccounts
                where ra.Email == "stephfoxton@hotmail.com"
                select ra;
                db.RiderAccounts.RemoveRange(selectedRider);
                db.SaveChanges();

                var selectedStaff =
                from sa in db.StaffAccounts
                where sa.Email == "stephfoxton@hotmail.com"
                select sa;
                db.StaffAccounts.RemoveRange(selectedStaff);
                db.SaveChanges();

                var selectedBike =
                from b in db.Bikes
                where b.BikeMake == "Zero"
                select b;
                db.Bikes.RemoveRange(selectedBike);
                db.SaveChanges();

                var selectedEntry =
                from e in db.Entries
                where e.RaceId == 5
                select e;
                db.Entries.RemoveRange(selectedEntry);
                db.SaveChanges();
            }
		}

        [Test]
        public void RiderIsAdded_NumberIncreasesBy1()
        {
            using (var db = new TT_ProjectContext())
            {
                var numberBefore = db.RiderAccounts.ToList().Count();
                _crudManager.CreateRiderAccount("stephfoxton@hotmail.com", "Password", "Steph", "Foxton", "25/04/1996", "Manx", "No racing experience");
                var numberAfter = db.RiderAccounts.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);
            }

        }

        [Test]
        public void RiderWithPasswordThatIsTooShort_NotAdded()
        {
            using (var db = new TT_ProjectContext())
            {
                var numberBefore = db.RiderAccounts.ToList().Count();
                _crudManager.CreateRiderAccount("stephfoxton@hotmail.com", "Pass", "Steph", "Foxton", "25/04/1996", "Manx", "No racing experience");
                var numberAfter = db.RiderAccounts.ToList().Count();

                Assert.AreEqual(numberBefore, numberAfter);
            }

        }

        [Test]
        public void RiderIsUnder22_NotAdded()
        {
            using (var db = new TT_ProjectContext())
            {
                var numberBefore = db.RiderAccounts.ToList().Count();
                _crudManager.CreateRiderAccount("stephfoxton@hotmail.com", "Password", "Steph", "Foxton", "25/04/2001", "Manx", "No racing experience");
                var numberAfter = db.RiderAccounts.ToList().Count();

                Assert.AreEqual(numberBefore, numberAfter);
            }

        }

        [Test]
        public void StaffIsAdded_NumberIncreasesBy1()
        {
            using (var db = new TT_ProjectContext())
            {
                var numberBefore = db.StaffAccounts.ToList().Count();
                _crudManager.CreateStaffAccount("stephfoxton@hotmail.com", "Password", "Steph", "Foxton");
                var numberAfter = db.StaffAccounts.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);
            }

        }

        [Test]
        public void BikeIsAdded_NumberIncreasesBy1()
        {
            using (var db = new TT_ProjectContext())
            {
                var numberBefore = db.Bikes.ToList().Count();
                _crudManager.CreateBike(1,"Zero", "McGuiness");
                var numberAfter = db.Bikes.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);
            }

        }

        [Test]
        public void BikeIsDeleted_NumberDecreasesBy1()
        {
            using (var db = new TT_ProjectContext())
            {

                var newBike = new Bike
                {
                    RiderId = 1,
                    BikeMake = "Electric",
                    BikeSponsor = "Norton"
                };
                db.Bikes.Add(newBike);
                db.SaveChanges();

                var numberBefore = db.Bikes.ToList().Count();
                _crudManager.DeleteBike(27);
                var numberAfter = db.Bikes.ToList().Count();

                Assert.AreEqual(numberBefore , numberAfter+1);
            }

        }

        [Test]
        public void RaceEntryAdded_EntriesIncreaseBy1()
        {
            using (var db = new TT_ProjectContext())
            {
                var numberBefore = db.Entries.ToList().Count();
                _crudManager.CreateRaceEntry(1,5);
                var numberAfter = db.Entries.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);
            }
        }


        //[Test]
        //public void DuplicateRaceAndRider_NotAdded()
        //{
        //    using (var db = new TT_ProjectContext())
        //    {

        //        var numberBefore = db.Entries.ToList().Count();
        //        _crudManager.CreateRaceEntry(1, 1);
        //        var numberAfter = db.Entries.ToList().Count();

        //        Assert.AreEqual(numberBefore, numberAfter);
        //    }
        //}

        [Test]
        public void EntryIsDeleted_NumberDecreasesBy1()
        {
            using (var db = new TT_ProjectContext())
            {

                //var newEntry = new Entry
                //{
                //    RiderId = 1,
                //    RaceId = 4
                //};
                //db.Entries.Add(newEntry);
                //db.SaveChanges();

                var numberBefore = db.Entries.ToList().Count();
                _crudManager.DeleteEntry(17);
                var numberAfter = db.Entries.ToList().Count();

                Assert.AreEqual(numberBefore, numberAfter + 1);
            }

        }
    }
}