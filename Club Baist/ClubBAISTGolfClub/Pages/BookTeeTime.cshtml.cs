using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;


namespace ClubBAISTGolfClub.Pages
{
    [Authorize]
    public class BookTeeTimeModel : PageModel
    {
        public int[,]? Calendar { get; set; }
        [BindProperty]
        public int Month { get; set; } 
        public string MonthName { get; set; }

        public void OnGet()
        {
            // Set up the DataGridView
            DateTime today = DateTime.Today;
            Month = today.Month;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
            int currentDay = 1;
            MonthName = GetMonthName(Month);
            Calendar = new int[6, 7];

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if ((row == 0 && col < (int)firstDayOfMonth.DayOfWeek) || currentDay > daysInMonth)
                    {
                        Calendar[row, col] = 0;
                    }
                    else
                    {
                        Calendar[row, col] = currentDay;
                        currentDay++;
                    }
                }
            }
        }
        public void OnPost()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, Month, 1);
            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
            int currentDay = 1;

            Calendar = new int[6, 7];
            MonthName = GetMonthName(Month);
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if ((row == 0 && col < (int)firstDayOfMonth.DayOfWeek) || currentDay > daysInMonth)
                    {
                        Calendar[row, col] = 0;
                    }
                    else
                    {
                        Calendar[row, col] = currentDay;
                        currentDay++;
                    }
                }
            }
        }
        static string GetMonthName(int monthNumber)
        {
            DateTimeFormatInfo dtfi = CultureInfo.CurrentCulture.DateTimeFormat;
            return dtfi.GetMonthName(monthNumber);
        }
    }
    }

