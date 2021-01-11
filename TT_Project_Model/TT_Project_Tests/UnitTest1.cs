using NUnit.Framework;
using System.Linq;
using TT_Project_Model;
using TT_Project_Business;
using System;

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

            }
        }

		[TearDown]

		public void TearDown()
		{
			using (var db = new TT_ProjectContext())
			{

                var selectedRider =
                from ra in db.RiderAccounts
                where ra.Email == "stephfoxton@hotmail.com" || ra.Email == "steph@hotmail.com" || ra.Email == "breesha@hotmail.com"
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
        public void CREATERider_NumberIncreasesBy1()
        {
            using (var db = new TT_ProjectContext())
            {
                var numberBefore = db.RiderAccounts.ToList().Count();
                _crudManager.CreateRiderAccount("stephfoxton@hotmail.com", "Password", "Steph", "Foxton", Convert.ToDateTime("25/04/1996"), "Manx", "No racing experience");
                var numberAfter = db.RiderAccounts.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);
            }
        }

        [Test]
        public void READNewRiderAdded_CorrectDetails()
        {
            using (var db = new TT_ProjectContext())
            {
                var numberBefore = db.RiderAccounts.ToList().Count();
                _crudManager.CreateRiderAccount("steph@hotmail.com", "Password", "Steph", "Foxton", Convert.ToDateTime("25/04/1996"), "Manx", "No racing experience");
                var numberAfter = db.RiderAccounts.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);

                var createdRider =
                    from c in db.RiderAccounts
                    where c.Email == "steph@hotmail.com"
                    select c;

                foreach (var c in createdRider)
                {
                    Assert.AreEqual("Password", c.Passwrd);
                    Assert.AreEqual("Steph", c.FirstName);
                    Assert.AreEqual("Foxton", c.LastName);
                    Assert.AreEqual(Convert.ToDateTime("25/04/1996").ToShortDateString(), c.DateOfBirth);
                    Assert.AreEqual("Manx", c.Nationality);
                    Assert.AreEqual("No racing experience", c.Experience);
                }
            }
        }

        [Test]
        public void UPDATERiderDetails_DatabaseIsUpdated()
        {
            using (var db = new TT_ProjectContext())
            {
                var newRider = new RiderAccount()
                {
                    Email = "breesha@hotmail.com",
                    Passwrd = "password",
                    FirstName = "Breesha",
                    LastName = "Foxton",
                    DateOfBirth = Convert.ToDateTime("24/06/1998").ToShortDateString(),
                    Nationality = "Manx",
                    Experience = "no rider experience"
                };
                db.RiderAccounts.Add(newRider);
                db.SaveChanges();
            }
            _crudManager.UpdateRider("breesha@hotmail.com", "Bree", "FoxtoN", Convert.ToDateTime("25/06/1998"), "French", "2020 Winner Senior");

            using (var db = new TT_ProjectContext())
            {
                var SelectedRider = db.RiderAccounts.Where(c => c.Email == "breesha@hotmail.com").FirstOrDefault();

                Assert.AreEqual("Bree", SelectedRider.FirstName);
                Assert.AreEqual("FoxtoN", SelectedRider.LastName);
                Assert.AreEqual(Convert.ToDateTime("25/06/1998").ToShortDateString(), SelectedRider.DateOfBirth);
                Assert.AreEqual("French", SelectedRider.Nationality);
                Assert.AreEqual("2020 Winner Senior", SelectedRider.Experience);
            }
        }

        

        [Test]
        public void CREATEStaff_NumberIncreasesBy1()
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
        public void CREATERaceEntry_EntriesIncreaseBy1()
        {
            using (var db = new TT_ProjectContext())
            {
                var numberBefore = db.Entries.ToList().Count();
                _crudManager.CreateRaceEntry(1, 5);
                var numberAfter = db.Entries.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);
            }
        }

        [Test]
        public void DELETERaceEntry_NumberDecreasesBy1()
        {
            using (var db = new TT_ProjectContext())
            {

                var newEntry = new Entry
                {
                    RiderId = 1,
                    RaceId = 1
                };
                db.Entries.Add(newEntry);
                db.SaveChanges();

                var numberBefore = db.Entries.ToList().Count();
                //SQL Query to find entryid
                _crudManager.DeleteEntry(2048);
                var numberAfter = db.Entries.ToList().Count();

                Assert.AreEqual(numberBefore, numberAfter + 1);
            }

        }


        [Test]
        public void CREATEBike_NumberIncreasesBy1()
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
        public void DELETEBike_NumberDecreasesBy1()
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
                //SQL Query to find bikeid
                _crudManager.DeleteBike(1047);
                var numberAfter = db.Bikes.ToList().Count();

                Assert.AreEqual(numberBefore , numberAfter+1);
            }
        }

        //Tests that passed but the code changed so could no longer run
        //Future implementation

        //[Test]
        //public void RiderWithPasswordThatIsTooShort_NotAdded()
        //{
        //    using (var db = new TT_ProjectContext())
        //    {
        //        var numberBefore = db.RiderAccounts.ToList().Count();
        //        _crudManager.CreateRiderAccount("stephfoxton@hotmail.com", "Pass", "Steph", "Foxton", Convert.ToDateTime(25 / 04 / 1996), "Manx", "No racing experience");
        //        var numberAfter = db.RiderAccounts.ToList().Count();

        //        Assert.AreEqual(numberBefore, numberAfter);
        //    }
        //}

        //[Test]
        //public void RiderIsUnder22_NotAdded()
        //{
        //    using (var db = new TT_ProjectContext())
        //    {
        //        var numberBefore = db.RiderAccounts.ToList().Count();
        //        _crudManager.CreateRiderAccount("stephfoxton@hotmail.com", "Password", "Steph", "Foxton", Convert.ToDateTime(25 / 04 / 2001), "Manx", "No racing experience");
        //        var numberAfter = db.RiderAccounts.ToList().Count();

        //        Assert.AreEqual(numberBefore, numberAfter);
        //    }
        //}

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

    }
}