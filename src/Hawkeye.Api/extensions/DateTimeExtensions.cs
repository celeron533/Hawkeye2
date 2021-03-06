﻿using System;
using System.Globalization;

namespace Hawkeye.Extensions
{
    /// <summary>
    ///     Some useful DateTime-related extension methods.
    /// </summary>
    public static class DateTimeExtensions
    {
        #region DateTime

        private static DateTime[] _dayCache;

        /// <summary>
        ///     Converts the date to a short invariant string representation (format
        ///     = "yyyy/MM/dd").
        /// </summary>
        /// <param name="dateTime">The date time to convert.</param>
        /// <returns>
        ///     The converted string representation.
        /// </returns>
        public static string ToShortInvariantString(this DateTime dateTime)
        {
            return dateTime.ToString(@"yyyy/MM/dd");
        }

        /// <summary>
        ///     Converts the date to a long invariant string representation (format
        ///     = "yyyy/MM/dd hh:mm:ss").
        /// </summary>
        /// <param name="dateTime">The date time to convert.</param>
        /// <returns>
        ///     The converted string representation.
        /// </returns>
        public static string ToLongInvariantString(this DateTime dateTime)
        {
            return dateTime.ToString(@"yyyy/MM/dd HH:mm:ss");
        }

        /// <summary>
        ///     Converts the date to a very long invariant string representation
        ///     (format = "yyyy/MM/dd hh:mm:ss.FFFFFFF").
        /// </summary>
        /// <param name="dateTime">The date time to convert.</param>
        /// <returns>
        ///     A string representation of the specified date.
        /// </returns>
        public static string ToVeryLongInvariantString(this DateTime dateTime)
        {
            return dateTime.ToString(@"yyyy/MM/dd HH:mm:ss.FFFFFFF");
        }

        /// <summary>
        ///     Formats the specified <paramref name="day" /> as a short string
        ///     (three letters).
        /// </summary>
        /// <param name="day">The day.</param>
        /// <returns>
        ///     A string representation of the specified date.
        /// </returns>
        public static string ToShortString(this DayOfWeek day)
        {
            return ToShortString(day, CultureInfo.CurrentUICulture);
        }

        /// <summary>
        ///     Formats the specified <paramref name="day" /> as a short string
        ///     (three letters).
        /// </summary>
        /// <param name="day">The day.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>
        ///     A string representation of the specified date.
        /// </returns>
        public static string ToShortString(this DayOfWeek day, CultureInfo culture)
        {
            return ToFormattedString(day, "ddd", culture);
        }

        /// <summary>
        ///     Formats the specified <paramref name="day" /> as a long string.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <returns>
        ///     A string representation of the specified date.
        /// </returns>
        public static string ToLongString(this DayOfWeek day)
        {
            return ToLongString(day, CultureInfo.CurrentUICulture);
        }

        /// <summary>
        ///     Formats the specified <paramref name="day" /> as a long string.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>
        ///     A string representation of the specified date.
        /// </returns>
        public static string ToLongString(this DayOfWeek day, CultureInfo culture)
        {
            return ToFormattedString(day, "dddd", culture);
        }

        private static string ToFormattedString(this DayOfWeek day, string format, CultureInfo culture)
        {
            if (_dayCache == null)
            {
                _dayCache = new DateTime[7];
                var sundayIndex = 2; // January the 2nd 2000 was a Sunday.
                for (var i = 0; i < 7; i++)
                {
                    _dayCache[i] = new DateTime(2000, 1, sundayIndex);
                    sundayIndex++;
                }
            }

            DateTime dt = _dayCache[(int) day];
            return dt.ToString(format, culture);
        }

        #endregion
    }
}