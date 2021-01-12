using System;
using TT_Project_Business;
using TT_Project_Model;
using NUnit.Framework;
using Moq;

namespace TT_ProjecctMoqTests
{
    class Moq
    {
        private CRUDManager _sut;



        //// USING MOQS AS A DUMMY
        [Ignore("This will fail")]
        [Test]
        public void BeAbleToBeConstructed()
        {
            //Arrange and Act
            _sut = new CRUDManager(null);
            //Assert
            Assert.That(_sut, Is.InstanceOf<CRUDManager>());
        }

        [Test]
        public void BeAbleToBeConstructeUsingMoq()
        {
            //Construct a mock instance of Type IRiderAccountService
            var mockRiderAccountService = new Mock<IRiderAccountService>();

            _sut = new CRUDManager(mockRiderAccountService.Object);

            Assert.That(_sut, Is.InstanceOf<CRUDManager>());
        }



        //// USING MOQS AS STUBS
        [Test]
        public void GetRiderAccount_ReturnDesiredName()
        {
            //Construct a mock instance of Type IRiderAccountService
            var mockRiderAccountService = new Mock<IRiderAccountService>();
            var exampleRiderAccount = new RiderAccount { RiderId=10 , Email = "william@foxton.com", Passwrd = "william", FirstName = "William", LastName = "Foxton", DateOfBirth = "28/12/1996", Nationality = "Manx", Experience = "None" };
            mockRiderAccountService.Setup(c => c.GetRiderAccountByID(10)).Returns(exampleRiderAccount);

            _sut = new CRUDManager(mockRiderAccountService.Object);
            var result = _sut.RetrieveSelectedRiderAccount(10).FirstName;
            Assert.That(result, Is.EqualTo("William"));
        }

        [Test]
        public void DeleteRiderMethod_IsCalled_WithCorrectParameters()
        {
            var mockRiderAccountService = new Mock<IRiderAccountService>();
            _sut = new CRUDManager(mockRiderAccountService.Object);
            //Act (invoke mock)
            _sut.DeleteRider(10);
            mockRiderAccountService.Verify(x => x.DeleteRiderAccount(10));
            mockRiderAccountService.Verify(x => x.DeleteRiderAccount(10), Times.Exactly(1));
        }

        [Test]
        public void RiderDeleteMethod_IsNotCalled_WhenInvokingCRUDManagerCreateMethod()
        {
            var mockRiderAccountService = new Mock<IRiderAccountService>();
            _sut = new CRUDManager(mockRiderAccountService.Object);
            //Act (invoke mock)
            _sut.CreateRiderAccount("nish@mandal.com", "password","Nishant","Mandal", Convert.ToDateTime("12/01/1989"), "English","None");
            mockRiderAccountService.Verify(x => x.DeleteRiderAccount(It.IsAny<int>()), Times.Never);
        }



        ////STRICT Behaviour
        [Test]
        public void GetRiderAccountInCRUDManager_CallsTheCorrectMethodWithCorrectParameters_OfIRiderAccountServiceSTRICT()
        {
            //Construct a mock instance of Type IRiderAccountService
            var mockRiderAccountService = new Mock<IRiderAccountService>(MockBehavior.Strict);
            mockRiderAccountService.Setup(c => c.GetRiderAccountByID(10)).Returns(It.IsAny<RiderAccount>);

            _sut = new CRUDManager(mockRiderAccountService.Object);
            _sut.RetrieveSelectedRiderAccount(10);
        }



        ////LOOSE Behaviour
        [Test]
        public void GetRiderAccountInCRUDManager_CallsTheCorrectMethodWithCorrectParameters_OfIRiderAccountServiceLOOSE()
        {
            //Construct a mock instance of Type IRiderAccountService
            var mockRiderAccountService = new Mock<IRiderAccountService>(MockBehavior.Loose);
            mockRiderAccountService.Setup(c => c.GetRiderAccountByID(10)).Returns(It.IsAny<RiderAccount>);

            _sut = new CRUDManager(mockRiderAccountService.Object);
            _sut.RetrieveSelectedRiderAccount(11);
        }

    }
}