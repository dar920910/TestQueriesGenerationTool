namespace TestQueriesGenerator.Library.Services
{
	public static class DateTimeService
	{
        public static string GetDateAndTimeDefaultString()
        {
            string sep = " - ";
            string dateSep = ".";
            string timeSep = ".";
            string zero = "0";
            bool ms = true;

            return GetDateAndTime(sep, dateSep, timeSep, ms, zero);
        }

        public static string GetDate(string sep)
        {
            string date, year, month, day;

            day = DateTime.Now.Day.ToString();
            month = DateTime.Now.Month.ToString();
            year = DateTime.Now.Year.ToString();

            date = year + sep + month + sep + day;

            return date;
        }

        public static string GetDate(string sep, string zero)
        {
            string date, dtYear, dtMonth, dtDay;
            int year, month, day;

            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            day = DateTime.Now.Day;

            dtYear = GetDateOrTimeWithZero(year, zero);
            dtMonth = GetDateOrTimeWithZero(month, zero);
            dtDay = GetDateOrTimeWithZero(day, zero);

            date = dtYear + sep + dtMonth + sep + dtDay;

            return date;
        }

        public static string GetTime(string sep, bool ms)
        {
            string time, hour, minute, second;

            second = DateTime.Now.Second.ToString();
            minute = DateTime.Now.Minute.ToString();
            hour = DateTime.Now.Hour.ToString();

            time = hour + sep + minute + sep + second;

            if (ms)
            {
                string milliSecond = DateTime.Now.Millisecond.ToString();
                time += sep + milliSecond;
            }

            return time;
        }

        public static string GetTime(string sep, bool ms, string zero)
        {
            string time, tmHour, tmMinute, tmSecond;
            int hour, minute, second;

            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;

            tmHour = GetDateOrTimeWithZero(hour, zero);
            tmMinute = GetDateOrTimeWithZero(minute, zero);
            tmSecond = GetDateOrTimeWithZero(second, zero);

            time = tmHour + sep + tmMinute + sep + tmSecond;

            if (ms)
            {
                int millisecond;
                string tmMillisecond;

                millisecond = DateTime.Now.Millisecond;
                tmMillisecond = GetMillisecondWithZero(millisecond, zero);

                time += sep + tmMillisecond;
            }

            return time;
        }

        public static string GetDateAndTime(string sep, string dateSep, string timeSep, bool ms)
        {
            string datetime, date, time;

            date = GetDate(dateSep);
            time = GetTime(timeSep, ms);

            datetime = date + sep + time;

            return datetime;
        }

        public static string GetDateAndTime(string sep, string dateSep, string timeSep, bool ms, string zero)
        {
            string datetime, date, time;

            date = GetDate(dateSep, zero);
            time = GetTime(timeSep, ms, zero);

            datetime = date + sep + time;

            return datetime;
        }

        private static string GetDateOrTimeWithZero(int datetimeValue, string zero)
        {
            return (datetimeValue < 10) ? zero + datetimeValue.ToString() : datetimeValue.ToString();
        }

        private static string GetMillisecondWithZero(int millisecond, string zero)
        {
            if (millisecond < 10)
            {
                return zero + zero + millisecond.ToString();
            }

            if (millisecond < 100)
            {
                return zero + millisecond.ToString();
            }

            return millisecond.ToString();
        }
    }
}
