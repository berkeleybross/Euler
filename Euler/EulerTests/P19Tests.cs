/*
Counting Sundays
   
Problem 19
You are given the following information, but you may prefer to do some research for yourself.

1 Jan 1900 was a Monday.
Thirty days has September,
April, June and November.
All the rest have thirty-one,
Saving February alone,
Which has twenty-eight, rain or shine.
And on leap years, twenty-nine.
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
 */

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace EulerTests
{
    public class P19Tests
    {
        public class Solution
            : P19Tests
        {
            [Fact]
            public void Calculates_solution()
            {
                P19.CountSundays().Should().Be(171); // 66ms
            }
        }

        public class GetNumDaysInMonth
            : P19Tests
        {
            [Theory]
            [InlineData(0, 31)] // January
            [InlineData(2, 31)] // March
            [InlineData(3, 30)] // April
            [InlineData(4, 31)] // May
            [InlineData(5, 30)] // June
            [InlineData(6, 31)] // July
            [InlineData(7, 31)] // August
            [InlineData(8, 30)] // September
            [InlineData(9, 31)] // October
            [InlineData(10, 30)] // November
            [InlineData(11, 31)] // December
            public void Gets_correct_value_for_months_with_constant_days(int month, int days)
            {
                P19.GetNumDaysInMonth(0, month).Should().Be(days);
            }
            
            [Theory]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(100)]
            [InlineData(1999)]
            public void Gets_correct_value_for_february_in_non_leap_years(int year)
            {
                P19.GetNumDaysInMonth(year, 1).Should().Be(28);
            }
            
            [Theory]
            [InlineData(0)]
            [InlineData(4)]
            [InlineData(2000)]
            public void Gets_correct_value_for_february_in_leap_years(int year)
            {
                P19.GetNumDaysInMonth(year, 1).Should().Be(29);
            }
        }

        public class GetFirstDaysOfMonth
            : P19Tests
        {
            [Fact]
            public void Returns_correct_days()
            {
                P19.GetFirstDaysOfMonth(1901, 1901).Should().Equal(
                    DayOfWeek.Tuesday,
                    DayOfWeek.Friday, 
                    DayOfWeek.Friday,
                    DayOfWeek.Monday, 
                    DayOfWeek.Wednesday, 
                    DayOfWeek.Saturday,
                    DayOfWeek.Monday,
                    DayOfWeek.Thursday,
                    DayOfWeek.Sunday,
                    DayOfWeek.Tuesday,
                    DayOfWeek.Friday, 
                    DayOfWeek.Sunday);
            }
            
            [Fact]
            public void Matches_system_days_of_week()
            {
                var systemDaysOfMonth = GetSystemFirstDaysOfMonth(1901, 2000);
                P19.GetFirstDaysOfMonth(1901, 2000).Should().Equal(systemDaysOfMonth);
            }

            private static IEnumerable<DayOfWeek> GetSystemFirstDaysOfMonth(int startYear, int endYear)
            {
                for (var year = startYear; year <= endYear; year++)
                {
                    for (var month = 1; month <= 12; month++)
                    {
                        yield return new DateTime(year, month, 1).DayOfWeek;
                    }
                }
            }
        }
        
        public class IsLeapYear
            : P19Tests
        {
            [Theory]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(5)]
            public void Returns_false_for_year_not_divisible_by_four(int year)
            {
                P19.IsLeapYear(year).Should().Be(false);
            }
            
            [Theory]
            [InlineData(0)]
            [InlineData(4)]
            [InlineData(8)]
            public void Returns_true_for_years_divisible_by_four(int year)
            {
                P19.IsLeapYear(year).Should().Be(true);
            }
            
            [Theory]
            [InlineData(100)]
            [InlineData(200)]
            [InlineData(300)]
            public void Returns_false_for_years_on_a_century(int year)
            {
                P19.IsLeapYear(year).Should().Be(false);
            }
            
            [Theory]
            [InlineData(0)]
            [InlineData(400)]
            [InlineData(2000)]
            public void Returns_true_for_years_on_a_century_and_divisible_by_400(int year)
            {
                P19.IsLeapYear(year).Should().Be(true);
            }
        }
    }
}