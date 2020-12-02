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
        }

		[TearDown]

		public void TearDown()
		{
			using (var db = new TT_ProjectContext())
			{

				var selectedRider =
				from ra in db.RiderAccounts
				where ra.Email == "breeshafoxton@hotmail.com"
				select ra;
				db.RiderAccounts.RemoveRange(selectedRider);
				db.SaveChanges();

                var selectedStaff =
                from sa in db.StaffAccounts
                where sa.Email == "breeshafoxton@hotmail.com"
                select sa;
                db.StaffAccounts.RemoveRange(selectedStaff);
                db.SaveChanges();
            }
		}

        [Test]
        public void RiderIsAdded_NumberIncreasesBy1()
        {
            using (var db = new TT_ProjectContext())
            {
                var numberBefore = db.RiderAccounts.ToList().Count();
                _crudManager.CreateRiderAccount("breeshafoxton@hotmail.com", "Password", "Breesha", "Foxton", "24/06/1998", "Manx", "No racing experience");
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
                _crudManager.CreateRiderAccount("breeshafoxton@hotmail.com", "Pass", "Breesha", "Foxton", "24/06/1998", "Manx", "No racing experience");
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
                _crudManager.CreateRiderAccount("breeshafoxton@hotmail.com", "Password", "Breesha", "Foxton", "24/06/2000", "Manx", "No racing experience");
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
                _crudManager.CreateStaffAccount("breeshafoxton@hotmail.com", "Password", "Breesha", "Foxton");
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
                _crudManager.CreateBike("Kawasaki", "Dad");
                var numberAfter = db.Bikes.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);
            }

        }

    }
}