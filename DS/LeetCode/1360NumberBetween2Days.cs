using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static  class _1360NumberBetween2Days
    {

        public static bool isLeapYear(int year)
        {
            return year % 4 == 0 || year % 400 == 0;
        }
        public static int[] months = new int [] {31, 28, 31,30,31,30,31,31 ,30, 31,30,31};
        public static int DaysBetweenDates(string date1, string date2)
        {


            DateTime date1Date = DateTime.Parse(date1);
            DateTime date2Date = DateTime.Parse(date2);

            var gg =Math.Abs((date1Date - date2Date).Days) ;
            return gg;

        }

        public static void Run()
        {
                string date1 = "2019-06-29";
                string date2 = "2019-06-30";
               Console.WriteLine(DaysBetweenDates(date1, date2));
        }

      }

}
