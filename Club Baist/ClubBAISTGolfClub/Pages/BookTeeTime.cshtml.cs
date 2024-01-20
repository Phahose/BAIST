#nullable disable
using ClubBAISTGolfClub.Controller;
using ClubBAISTGolfClub.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClubBAISTGolfClub.Pages
{
    [Authorize]
    public class BookTeeTimeModel : PageModel
    {
        public int[,] Calendar { get; set; }
        [BindProperty]
        public int Month { get; set; } = 1;
        [BindProperty]
        public int Day { get; set; }
        public DateOnly? Date { get; set; }
        public string TextDate { get; set; }
        public string MonthName { get; set; }
        [BindProperty]
        public string Go { get; set; } = string.Empty;
        [BindProperty]
        public int PlayerNumber { get; set; }
        public Member Member { get; set; } = new();
        public string Email { get; set; } = string.Empty;
        [BindProperty]
        public string TeeTime { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string MemberInfoString { get; set; } = string.Empty;
        [BindProperty]
        public int Player1Id { get; set; }
        [BindProperty]
        public int Player2Id { get; set; }
        [BindProperty]
        public int Player3Id { get; set; }
        [BindProperty]
        public int Player4Id { get; set; }
        public List<int> PlayerList { get; set; } = new();

        public void OnGet()
        {
            //Get member Info 
            Email = HttpContext.Session.GetString("Email");
            MemberControlls memberControlls = new MemberControlls();
            Member = memberControlls.GetMember(Email);
            MemberInfoString = JsonSerializer.Serialize(Member);
            HttpContext.Session.SetString("MemberInfo", MemberInfoString);

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
            Email = HttpContext.Session.GetString("Email");
            MemberControlls memberControlls = new MemberControlls();
            Member = memberControlls.GetMember(Email);
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, Month, 1);
            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
            int currentDay = 1;

            Calendar = new int[6, 7];
            MonthName = GetMonthName(Month);
            switch (Go)
            {
                case "Go":
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
                    HttpContext.Session.SetInt32("Month", Month);
                    break;
                case "BookDate":
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
                    if (HttpContext.Session.GetInt32("Month") == null)
                    {
                        Month = today.Month;
                    }
                    else
                    {
                        Month = (int)HttpContext.Session.GetInt32("Month");
                    }                   
                    Date = new DateOnly(today.Year, Month, Day);
                    TextDate = GetFormattedDate((DateOnly)Date);
                    HttpContext.Session.SetString("Date", Date.ToString());
                break;
                case "PNumber":             
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
                    HttpContext.Session.SetInt32("PlayerNumber", PlayerNumber);
                    Date = DateOnly.Parse(HttpContext.Session.GetString("Date"));
                    TextDate = GetFormattedDate((DateOnly)Date);
                    break;
                case"BookTime":
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
                    MemberInfoString = HttpContext.Session.GetString("MemberInfo");
                    Member = JsonSerializer.Deserialize<Member>(MemberInfoString);
                    Date = DateOnly.Parse(HttpContext.Session.GetString("Date"));
                    PlayerNumber = (int)HttpContext.Session.GetInt32("PlayerNumber");
                    TeeTime teeTime = new()
                    {
                        MemberID = Member.MemberID,
                        Date = (DateOnly)Date,
                        NumberOfPlayers = PlayerNumber,
                        Time = TimeOnly.Parse(TeeTime)
                    };
                    Member member = memberControlls.GetMemberByID(Player1Id);

                    if (Player1Id != 0)
                    {
                        PlayerList.Add(Player1Id);
                    }
                    if (Player2Id != 0)
                    {
                        PlayerList.Add(Player2Id);
                    }
                    if (Player3Id != 0)
                    {
                        PlayerList.Add(Player3Id);
                    }
                    if (Player4Id != 0)
                    {
                        PlayerList.Add(Player4Id);
                    }

                    bool valid = true;
                    for (int i = 0; i < PlayerList.Count; i++)
                    {
                        member = memberControlls.GetMemberByID(PlayerList[i]);
                        if (member.MembershipType != "")
                        {
                            if (member.MembershipType != Member.MembershipType)
                            {
                                if (member.MembershipType == "Silver")
                                {
                                    TimeOnly startTime = new TimeOnly(15, 0); // 3:00 PM
                                    TimeOnly endTime = new TimeOnly(17, 30); // 5:30 PM
                                    if (TimeOnly.Parse(TeeTime) >= startTime && TimeOnly.Parse(TeeTime) <= endTime)
                                    {
                                        Message = $"Player with ID of ${PlayerList[i]} cannot play at this Time Because They are a Silver Member The can Play Before 3:00 PM and After 5:30PM";
                                        valid = false;
                                    }
                                }
                                else if (member.MembershipType == "Bronze")
                                {
                                    TimeOnly startTime = new TimeOnly(15, 0); // 3:00 PM
                                    TimeOnly endTime = new TimeOnly(18, 0); // 5:30 PM
                                    if (TimeOnly.Parse(TeeTime) >= startTime && TimeOnly.Parse(TeeTime) <= endTime)
                                    {
                                        Message = $"Player with ID of ${PlayerList[i]} cannot play at this Time Because They are a Bronze Member The can Play Before 3:00 PM and After 6:00PM";
                                        valid = false;
                                    }
                                }                              
                            }
                        }
                        else
                        {
                            Message = $"Some of You players Dont Exist Check Player ID{PlayerList[i]}";
                        }
                    }
                    if (valid)
                    {
                        TeeTimeController teeTimeController = new();
                        Message =  teeTimeController.BookReservation(teeTime);
                    }
                    TextDate = GetFormattedDate((DateOnly)Date);
                    break;

            }
           
        }
        static string GetMonthName(int monthNumber)
        {
            DateTimeFormatInfo dtfi = CultureInfo.CurrentCulture.DateTimeFormat;
            return dtfi.GetMonthName(monthNumber);
        }
        public static string GetFormattedDate(DateOnly date)
        {
            string[] suffixes = { "th", "st", "nd", "rd" };

            int day = date.Day;
            string suffix = (day >= 11 && day <= 13) || (day % 10 > 3) ? suffixes[0] : suffixes[day % 10];

            return date.ToString($"MMMM d'{suffix}' yyyy");
        }
    }
}

