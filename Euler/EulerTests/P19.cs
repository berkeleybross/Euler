// <copyright file="P19.cs" company="Berkeleybross">
// Copyright (c) Berkeleybross. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace EulerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class P19
    {
        public static int CountSundays()
        {
            return GetFirstDaysOfMonth(1901, 2000).Count(d => d == DayOfWeek.Sunday);
        }

        public static IEnumerable<DayOfWeek> GetFirstDaysOfMonth(int startYear, int endYear)
        {
            // Epoch is Monday, 1st Jan 1900
            var numDaysSinceEpoch = 0;

            // Count number of days between epoch and start year
            for (var year = 1900; year < startYear; year++)
            {
                numDaysSinceEpoch += IsLeapYear(year) ? 366 : 365;
            }

            // For each month of each year, return the day of the week and then progress one month.
            for (var year = startYear; year <= endYear; year++)
            {
                for (var month = 0; month < 12; month++)
                {
                    // Our Epoch has Monday = 0, but DayOfWeek Sunday = 0
                    // Add one to the day of week to account for this offset, then calculate which day it is.
                    yield return (DayOfWeek)((numDaysSinceEpoch + 1) % 7);

                    numDaysSinceEpoch += GetNumDaysInMonth(year, month);
                }
            }
        }

        public static int GetNumDaysInMonth(int year, int month)
        {
            switch (month)
            {
                case 0:
                case 2:
                case 4:
                case 6:
                case 7:
                case 9:
                case 11:
                    return 31;
                case 3:
                case 5:
                case 8:
                case 10:
                    return 30;
                case 1 when IsLeapYear(year):
                    return 29;
                case 1:
                    return 28;
                default:
                    throw new NotSupportedException("Unknown month: " + month);
            }
        }

        public static bool IsLeapYear(int year)
        {
            if (year % 4 != 0)
            {
                return false;
            }

            if (year % 100 == 0)
            {
                return year % 400 == 0;
            }

            return true;
        }
    }
}