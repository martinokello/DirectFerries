using DirectFerries.Business;
using DirectFerries.Business.Interfaces;
using DirectFerries.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace DirectFerries.Controllers
{
    public class HomeController : Controller
    {
        private IDateService _dateOfBirthAndFullNameValidationService;

        /*  Best to use IoC, but for illustration won't be using it.    
         * 
              public HomeController(IDateService dateOfBirthAndFullNameValidationService)
              {
                  _dateOfBirthAndFullNameValidationService = dateOfBirthAndFullNameValidationService; 
                  _dateOfBirthAndFullNameValidationService.Vowels = ConfigurationManager.AppSettings["Vowels"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ch => ch[0]).ToArray();

              }*/

        public HomeController()
        {
            _dateOfBirthAndFullNameValidationService = new DateOfBirthAndFullNameValidationService();
            _dateOfBirthAndFullNameValidationService.Vowels = ConfigurationManager.AppSettings["Vowels"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ch => ch[0]).ToArray();

        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserDetailViewModel userDetails)
        {
            if (ModelState.IsValid)
            {
                var noOfDaysToBirthdayDisplayed = 14;
                var actualNumberOfVowels =_dateOfBirthAndFullNameValidationService.NumberOfVowels(userDetails.FirstName);
                var userAge = _dateOfBirthAndFullNameValidationService.UsersAge(userDetails.DateOfBirth);
                var daysBeforeNextBirthday = _dateOfBirthAndFullNameValidationService.NumberOfDaysBeforeNextBirthDay(userDetails.DateOfBirth);
                var f14DaysToBirthday = daysBeforeNextBirthday <= noOfDaysToBirthdayDisplayed;
                return Redirect($"~/Home/ResultsPage?firstName={userDetails.FirstName}&noOfVowels={actualNumberOfVowels}&daysBeforeNextBirthDay={daysBeforeNextBirthday}&userAge={userAge}&if14DaysToBirthday={f14DaysToBirthday}");
            }
            return View(userDetails);
        }

        [HttpGet]
        public ActionResult ResultsPage(string firstName, int noOfVowels, int daysBeforeNextBirthDay, int userAge, bool if14DaysToBirthday)
        {
            ViewBag.FirstName = firstName;
            ViewBag.NoOfVowels = noOfVowels;
            ViewBag.UserAge = userAge;
            ViewBag.NoOfDaysToNextBirthDay = daysBeforeNextBirthDay;
            ViewBag.DateIs14DaysToBD = if14DaysToBirthday;
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}