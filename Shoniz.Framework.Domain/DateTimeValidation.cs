using System.Globalization;

namespace Shoniz.Framework.Domain
{
    public static class DateTimeValidation
    {
        public static bool IsValidPersianDate(string date)
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
            catch (Exception)
            {
                return false;
            }

        }
    }
}
