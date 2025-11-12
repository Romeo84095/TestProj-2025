using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib
{
    internal class Settings
    {
        // https://www.w3.org/TR/NOTE-datetime
        static public readonly string dateFormatUiUtc = "yyyy-MM-dd";
        static public readonly string dateTimeFormatUiUtc = "yyyy-MM-dd HH:mm:ss.fffZ";
        static public readonly string dateTimeFormatUtc = "yyyy-MM-ddTHH:mm:ss.fffZ";
        static public readonly string dateTimeFormat2Utc = "yyyy-MM-ddTHH:mm:ss.fffZ";
        public static readonly string dateTimeFormatSimpleUtc = "yyyyMMddTHHmmssfffZ";
        static public readonly string dateTimeFormatUiLocal = "yyyy-MM-dd HH:mm:ss.fff";
        static public readonly string dateTimeFormatLocal = "yyyy-MM-ddTHH:mm:ss.fff";
        static public readonly string dateTimeFormat2Local = "yyyy-MM-ddTHH:mm:ss.fff";
        public static readonly string dateTimeFormatSimpleLocal = "yyyyMMddTHHmmssfff";

        public static string GetDateUtc(DateTime dt) { return dt.ToUniversalTime().ToString(dateFormatUiUtc); }
        public static string GetDateTimeUtc(DateTime dt) { return dt.ToUniversalTime().ToString(dateTimeFormatUtc); }
        public static string GetDateTime2Utc(DateTime dt) { return dt.ToUniversalTime().ToString(dateTimeFormat2Utc); }
        public static string GetDateTimeUiUtc(DateTime dt) { return dt.ToUniversalTime().ToString(dateTimeFormatUiUtc); }
        public static string GetDateTimeSimpleUtc(DateTime dt) { return dt.ToUniversalTime().ToString(dateTimeFormatSimpleUtc); }
        public static string GetDateTimeLocal(DateTime dt) { return dt.ToString(dateTimeFormatLocal); }
        public static string GetDateTime2Local(DateTime dt) { return dt.ToString(dateTimeFormat2Local); }
        public static string GetDateTimeUiLocal(DateTime dt) { return dt.ToString(dateTimeFormatUiUtc); }
        public static string GetDateTimeSimpleLocal(DateTime dt) { return dt.ToString(dateTimeFormatSimpleLocal); }
    }
}
