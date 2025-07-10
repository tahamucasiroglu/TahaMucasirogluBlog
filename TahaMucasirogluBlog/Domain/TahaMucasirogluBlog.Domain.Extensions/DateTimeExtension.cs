namespace TahaMucasirogluBlog.Domain.Extensions
{
    static public class DateTimeExtension
    {
        static public bool IsSameCalenderDate(this DateTime date1, DateTime date2) => date1.Date == date2.Date;
        static public bool IsSameCalenderDate(this DateTime? date1, DateTime date2) => date1?.Date == date2.Date;
        static public bool IsInRange(this DateTime date, DateTime startDate, DateTime endDate) => date > startDate && date < endDate;
        static public bool IsInRange(this DateTime? date, DateTime startDate, DateTime endDate) => date > startDate && date < endDate;
        static public bool IsBiggerThan(this DateTime date, DateTime date2) => date.CompareTo(date2) == -1;
        static public bool IsBiggerThan(this DateTime? date, DateTime date2) => date == null ? false : date?.CompareTo(date2) == -1;
        static public bool IsLessThan(this DateTime date, DateTime date2) => date.CompareTo(date2) == 1;
        static public bool IsLessThan(this DateTime? date, DateTime date2) => date == null ? false : date?.CompareTo(date2) == 1;
    }
}
