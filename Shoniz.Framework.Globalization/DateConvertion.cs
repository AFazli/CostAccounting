using System;
using System.Globalization;

namespace Shoniz.Framework.Globalization
{
    public static class DateConvertion
    {

        public static bool IsValidDate(string date)
        {
            try
            {
                var dateArray = date.Split('/');

                var year = int.Parse(dateArray[0]);
                var month = int.Parse(dateArray[1]);
                var day = int.Parse(dateArray[2]);

                var pc = new PersianCalendar();
                var dt = pc.ToDateTime(year, month, day, 0, 0, 0, 0);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static DateTime ConvertToDateTime(string persianDate, int hour, int minute, int second, int millisecond)
        {
            var pc = new PersianCalendar();

            var persianDateArray = persianDate.Split('/');

            var year = int.Parse(persianDateArray[0]);
            var month = int.Parse(persianDateArray[1]);
            var day = int.Parse(persianDateArray[2]);

            return new DateTime(year, month, day, hour, minute, second, millisecond, pc);
        }

        public static DateTime ConvertToStartOfDate(string persianDate)
        {
            var pc = new PersianCalendar();

            var persianDateArray = persianDate.Split('/');

            var year = int.Parse(persianDateArray[0]);
            var month = int.Parse(persianDateArray[1]);
            var day = int.Parse(persianDateArray[2]);

            return new DateTime(year, month, day, pc);
        }

        public static DateTime ConvertToEndOfDate(string persianDate)
        {
            var pc = new PersianCalendar();

            var persianDateArray = persianDate.Split('/');

            var year = int.Parse(persianDateArray[0]);
            var month = int.Parse(persianDateArray[1]);
            var day = int.Parse(persianDateArray[2]);

            return new DateTime(year, month, day, 23, 59, 59, 999, pc);
        }

        public static int GetPersianYear(DateTime dateTime)
        {
            var pc = new PersianCalendar();
            return pc.GetYear(dateTime);
        }

        public static string GetPersianDate(DateTime dateTime)
        {
            var pc = new PersianCalendar();
            return $@"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime):D2}/{pc.GetDayOfMonth(dateTime):D2}";
        }

        public static int GetPersianMonth(DateTime dateTime)
        {
            var pc = new PersianCalendar();
            return pc.GetMonth(dateTime);
        }

        public static DateTime GetDateOfLastDayOfPersianMonth(int year, int month)
        {
            var pc = new PersianCalendar();
            var daysInMonth = pc.GetDaysInMonth(year, month);
            var dateOfLastDayInMonth = pc.ToDateTime(year, month, daysInMonth, 23, 59, 59, 999);
            return dateOfLastDayInMonth;
        }

        public static DateTime GetDateOfFirstDayOfPersianMonth(int year, int month)
        {
            var pc = new PersianCalendar();
            return pc.ToDateTime(year, month, 1, 0, 0, 0, 0, 0);
        }

        public static string GetPersianMonthName(int month)
        {
            if (month == 1) return "فروردین";

            if (month == 2) return "اردیبهشت";

            if (month == 3) return "خرداد";

            if (month == 4) return "تیر";

            if (month == 5) return "مرداد";

            if (month == 6) return "شهریور";

            if (month == 7) return "مهر";

            if (month == 8) return "آبان";

            if (month == 9) return "آذر";

            if (month == 10) return "دی";

            if (month == 11) return "بهمن";

            if (month == 12) return "اسفند";

            return "مقدار ماه اشتباه می باشد";
        }
    }
}
