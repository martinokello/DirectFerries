using DirectFerries.Business;
using DirectFerries.Business.Interfaces;
using DirectFerries.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
namespace DirectFerries.Tests
{
    [TestClass]
    public class UnitTestBusinessLogic
    {
        private UserDetailViewModel _userDetails;
        private IDateService DateService;
        [TestInitialize]
        public void Setup()
        {
            DateService = new DateOfBirthAndFullNameValidationService();
            DateService.Vowels = "a,o,u,i,e,y,A,O,U,I,E,Y".Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ch=> ch[0]).ToArray();
        }
        [TestMethod]
        public void TestBusinessLogic_NumberOfVowels()
        {
            _userDetails = new UserDetailViewModel { DateOfBirth = DateTime.Now.AddYears(-18), FirstName = "Andrew", LastName = "Coles" };
            var noOfVowels = DateService.NumberOfVowels(_userDetails.FirstName);
            Assert.AreEqual(2, noOfVowels);
        }

        [TestMethod]
        public void TestBusinessLogic_UserAge()
        {
            _userDetails = new UserDetailViewModel { DateOfBirth = DateTime.Now.AddYears(-18), FirstName = "Andrew", LastName = "Coles" };
            var userAge = DateService.UsersAge(_userDetails.DateOfBirth);
            Assert.AreEqual(17, userAge);
        }
        [TestMethod]
        public void TestBusinessLogic_NumberOfDaysBeforeNextBirthDay()
        {
            _userDetails = new UserDetailViewModel { DateOfBirth = DateTime.Now.AddYears(-25), FirstName = "Andrew", LastName = "Coles" };
            var noOfDaysBeforeBirthDay = DateService.NumberOfDaysBeforeNextBirthDay(_userDetails.DateOfBirth);
            Assert.AreEqual(0, noOfDaysBeforeBirthDay);
        }
    }
}
