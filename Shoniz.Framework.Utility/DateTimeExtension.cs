using System.Globalization;

namespace Shoniz.Framework.Utility
{
    public static class DateTimeExtension
    {
        public static string ToPersianDateTime(this DateTime dateTime)
        {
            var pc = new PersianCalendar();
            return $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime):D2}/{pc.GetDayOfMonth(dateTime):D2} - {pc.GetHour(dateTime):D2}:{pc.GetMinute(dateTime):D2}:{pc.GetSecond(dateTime):D2}";
        }
    }
}