using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectFerries.Business.Interfaces
{
    public interface IDateService
    {
        int NumberOfVowels(string fullName);
        int UsersAge(DateTime dateOfBirth);
        int NumberOfDaysBeforeNextBirthDay(DateTime dateOfBirth);
        char[] Vowels { get; set; }
    }
}
