namespace ArgusMedia.Tests.Common.Helpers
{
    public static class DateTimeParser
    {
        public static DateTime ParseStringTimeHourMinutes(string timeString)
        {
            var time = TimeSpan.Parse(timeString);
            var dateTime = DateTime.Today.Add(time);
            return dateTime;
        }
    }
}
