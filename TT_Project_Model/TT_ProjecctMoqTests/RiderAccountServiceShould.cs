using NUnit.Framework;
using TT_Project_Business;
using Microsoft.EntityFrameworkCore;
using TT_Project_Model;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;

namespace TT_ProjecctMoqTests
{
    ////USING FAKES

    public class RiderAccountServiceShould
    {
        private RiderAccountService _sut;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<TT_ProjectContext>()
                .UseInMemoryDatabase(databaseName: "Example_DB")
            .Options;

            var context = new TT_ProjectContext(options);

            _sut = new RiderAccountService(context);

            _sut.CreateRiderAccount(new RiderAccount { RiderId=1, Email = "william@foxton.com", Passwrd = "william", FirstName = "William", LastName = "Foxton", DateOfBirth = "28/12/1996", Nationality = "Manx", Experience = "None" });
            _sut.CreateRiderAccount(new RiderAccount { RiderId=2 ,Email = "nish@mandal.com", Passwrd = "nish", FirstName = "Nishant", LastName = "Mandal", DateOfBirth = "28/12/1996", Nationality = "English", Experience = "None" });
        }

        [Test]
        public void GivenAnExistingRiderEmail_WhenCallingGetRiderEmailMethod_ShouldReturnARiderObject()
        {
            Assert.That(_sut.GetRiderAccountByEmail("william@foxton.com"), Is.Not.Null);
        }

        [Test]
        public void GivenAnInvalidRiderEmail_WhenCallingGetRiderEmailMethod_ShouldNotReturnARiderObject()
        {
            Assert.That(_sut.GetRiderAccountByEmail("foxton@william.com"), Is.Null);
        }

        [Test]
        public void GivenAnExistingRiderID_WhenCallingGetRiderIDMethod_ShouldReturnARiderObject()
        {
            Assert.That(_sut.GetRiderAccountByID(1), Is.Not.Null);
        }

        [Test]
        public void GivenAnInvalidRiderID_WhenCallingGetRiderIDMethod_ShouldNotReturnARiderObject()
        {
            Assert.That(_sut.GetRiderAccountByID(5), Is.Null);
        }

        [Test]
        public void GivenARiderIDOfARiderThatExists_WhenCallingGetRiderIDMethod_ShouldReturnARiderFirstName()
        {
            Assert.That(_sut.GetRiderAccountByID(1).FirstName, Does.Contain("William"));
            Assert.That(_sut.GetRiderAccountByID(2).FirstName, Does.Contain("Nishant"));
        }

        [Test]
        public void WhenICreateARider_ThenTheRiderAccountTableShouldHaveOneMoreRider()
        {
            var riderBefore = _sut.GetRiderAccountList().Count();
            _sut.CreateRiderAccount(new RiderAccount {RiderId=3, Email = "mandal@nish.com", Passwrd = "nish", FirstName = "Nishant", LastName = "Mandal", DateOfBirth = "28/12/1996", Nationality = "English", Experience = "None" });
            var riderAfter = _sut.GetRiderAccountList().Count();
            Assert.That(riderAfter, Is.EqualTo(riderBefore + 1));
            _sut.DeleteRiderAccount(3);
        }

        [Test]
        public void WhenIDeleteACustomerFromTheDatabase_ThenTheCustomerTableShouldHaveOneLessCustomer()
        {

            var riderBefore = _sut.GetRiderAccountList().Count();
            _sut.DeleteRiderAccount(2);
            var riderAfter = _sut.GetRiderAccountList().Count();
            Assert.That(riderAfter, Is.EqualTo(riderBefore - 1));
            _sut.CreateRiderAccount(new RiderAccount { RiderId = 2, Email = "nish@mandal.com", Passwrd = "nish", FirstName = "Nishant", LastName = "Mandal", DateOfBirth = "28/12/1996", Nationality = "English", Experience = "None" });
        }

        [TearDown]
        public void TearDown()
        {
            //Only using method for simplicity for example, should write it out
            _sut.DeleteRiderAccount(1);
            _sut.DeleteRiderAccount(2);
        }

    }
}
