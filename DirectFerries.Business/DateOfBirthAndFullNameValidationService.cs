﻿using DirectFerries.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectFerries.Business
{
    public class DateOfBirthAndFullNameValidationService: IDateService
    {
        public int NumberOfVowels(string fullName)
        {
            var result = 0;
            if (string.IsNullOrEmpty(fullName)) return result;
            foreach (char ch in fullName)
            {
                if (Vowels.Contains(ch))
                {
                    result++;
                }
            }
            return result;
        }

        public int UsersAge(DateTime dateOfBirth)
        {
            var currentDate = DateTime.Now;
            var age = currentDate.Year - dateOfBirth.Year;
            if (dateOfBirth.Month >= currentDate.Month && dateOfBirth.Day >= currentDate.Day)
                return age - 1;
            return age;
        }

        public int NumberOfDaysBeforeNextBirthDay(DateTime dateOfBirth)
        {
            var currentDate = DateTime.Now;
            var daysPerYear = 365;
            float avgDaysInMonth = (float)daysPerYear / 12;
            var month = currentDate.Month;
            var bMonth = dateOfBirth.Month;
            if (bMonth >= month)
                return (int)(dateOfBirth.Day - currentDate.Day + (bMonth - month) * avgDaysInMonth);

            return daysPerYear - (int)(dateOfBirth.Day - currentDate.Day + (month - bMonth) * avgDaysInMonth);
        }
        public char[] Vowels { get; set; }
    }
}
