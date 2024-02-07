#nullable disable
using ClubBAISTGolfClub.Controller;
using ClubBAISTGolfClub.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ClubBAISTGolfClub.Pages
{
    public class ScoresModel : PageModel
    {
        public Member Member { get; set; } = new();
        public string Email { get; set; } = string.Empty;
        public string MemberInfoString { get; set; } = string.Empty;
        [BindProperty]
        public int PlayerNumber { get; set; }
        [BindProperty]
        public string Submit { get; set; } = string.Empty;
        [BindProperty]
        public string Player1Name { get; set; } = string.Empty; 
        [BindProperty]
        public int Player1Handicap { get; set; }= 0;
        [BindProperty]
        public string Player2Name { get; set; } = string.Empty;
        [BindProperty]
        public int Player2Handicap { get; set; }= 0;
        [BindProperty]
        public string Player3Name { get; set; } = string.Empty;
        [BindProperty]
        public int Player3Handicap { get; set; } = 0;
        [BindProperty]
        public string Player4Name { get; set; } = string.Empty;
        [BindProperty]
        public int Player4Handicap { get; set; }
        public bool Complete { get; set; } = false;
        [BindProperty]
        #region Player 1
        public int Player1Hole1Score { get; set; }
        [BindProperty]
        public int Player1Hole2Score { get; set; }
        [BindProperty]
        public int Player1Hole3Score { get; set; }
        [BindProperty]
        public int Player1Hole4Score { get; set; }
        [BindProperty]
        public int Player1Hole5Score { get; set; }
        [BindProperty]
        public int Player1Hole6Score { get; set; }
        [BindProperty]
        public int Player1Hole7Score { get; set; }
        [BindProperty]
        public int Player1Hole8Score { get; set; }
        [BindProperty]
        public int Player1Hole9Score { get; set; }
        [BindProperty]
        public int Player1Hole10Score { get; set; }
        [BindProperty]
        public int Player1Hole11Score { get; set; }
        [BindProperty]
        public int Player1Hole12Score { get; set; }
        [BindProperty]
        public int Player1Hole13Score { get; set; }
        [BindProperty]
        public int Player1Hole14Score { get; set; }
        [BindProperty]
        public int Player1Hole15Score { get; set; }
        [BindProperty]
        public int Player1Hole16Score { get; set; }
        [BindProperty]
        public int Player1Hole17Score { get; set; }
        [BindProperty]
        public int Player1Hole18Score { get; set; }
        #endregion

        #region Player 2
        public int Player2Hole1Score{get; set;}
        [BindProperty]
        public int Player2Hole2Score{get; set;}
        [BindProperty]
        public int Player2Hole3Score{get; set;}
        [BindProperty]
        public int Player2Hole4Score{get; set;}
        [BindProperty]
        public int Player2Hole5Score{get; set;}
        [BindProperty]
        public int Player2Hole6Score{get; set;}
        [BindProperty]
        public int Player2Hole7Score{get; set;}
        [BindProperty]
        public int Player2Hole8Score{get; set;}
        [BindProperty]
        public int Player2Hole9Score { get; set; }
         [BindProperty]
        public int Player2Hole10Score{get; set;}
        [BindProperty]
        public int Player2Hole11Score{get; set;}
        [BindProperty]
        public int Player2Hole12Score{get; set;}
        [BindProperty]
        public int Player2Hole13Score{get; set;}
        [BindProperty]
        public int Player2Hole14Score{get; set;}
        [BindProperty]
        public int Player2Hole15Score{get; set;}
        [BindProperty]
        public int Player2Hole16Score{get; set;}
        [BindProperty]
        public int Player2Hole17Score{get; set;}
        [BindProperty]
        public int Player2Hole18Score { get; set; }
        #endregion
      
        #region Player 3
        public int Player3Hole1Score{get; set;}
        [BindProperty]
        public int Player3Hole2Score{get; set;}
        [BindProperty]
        public int Player3Hole3Score{get; set;}
        [BindProperty]
        public int Player3Hole4Score{get; set;}
        [BindProperty]
        public int Player3Hole5Score{get; set;}
        [BindProperty]
        public int Player3Hole6Score{get; set;}
        [BindProperty]
        public int Player3Hole7Score{get; set;}
        [BindProperty]
        public int Player3Hole8Score{get; set;}
        [BindProperty]
        public int Player3Hole9Score { get; set; }
         [BindProperty]
        public int Player3Hole10Score{get; set;}
        [BindProperty]
        public int Player3Hole11Score{get; set;}
        [BindProperty]
        public int Player3Hole12Score{get; set;}
        [BindProperty]
        public int Player3Hole13Score{get; set;}
        [BindProperty]
        public int Player3Hole14Score{get; set;}
        [BindProperty]
        public int Player3Hole15Score{get; set;}
        [BindProperty]
        public int Player3Hole16Score{get; set;}
        [BindProperty]
        public int Player3Hole17Score{get; set;}
        [BindProperty]
        public int Player3Hole18Score { get; set; }
        #endregion

        #region Player 4
        public int Player4Hole1Score{get; set;}
        [BindProperty]
        public int Player4Hole2Score{get; set;}
        [BindProperty]
        public int Player4Hole3Score{get; set;}
        [BindProperty]
        public int Player4Hole4Score{get; set;}
        [BindProperty]
        public int Player4Hole5Score{get; set;}
        [BindProperty]
        public int Player4Hole6Score{get; set;}
        [BindProperty]
        public int Player4Hole7Score{get; set;}
        [BindProperty]
        public int Player4Hole8Score{get; set;}
        [BindProperty]
        public int Player4Hole9Score { get; set; }
         [BindProperty]
        public int Player4Hole10Score{get; set;}
        [BindProperty]
        public int Player4Hole11Score{get; set;}
        [BindProperty]
        public int Player4Hole12Score{get; set;}
        [BindProperty]
        public int Player4Hole13Score{get; set;}
        [BindProperty]
        public int Player4Hole14Score{get; set;}
        [BindProperty]
        public int Player4Hole15Score{get; set;}
        [BindProperty]
        public int Player4Hole16Score{get; set;}
        [BindProperty]
        public int Player4Hole17Score{get; set;}
        [BindProperty]
        public int Player4Hole18Score { get; set; }
        #endregion
      
        public Scores Scores { get; set;} = new();
        public string Player1Message { get; set; } = string.Empty;
        public string Player2Message { get; set; } = string.Empty;
        public string Player3Message { get; set; } = string.Empty;
        public string Player4Message { get; set; } = string.Empty;
        public void OnGet()
        {
            Email = HttpContext.Session.GetString("Email");
            MemberControlls memberControlls = new MemberControlls();
            Member = memberControlls.GetMember(Email);
            MemberInfoString = JsonSerializer.Serialize(Member);
            HttpContext.Session.SetString("MemberInfo", MemberInfoString);
        }
        public void OnPost()
        {
            Email = HttpContext.Session.GetString("Email");
            MemberControlls memberControlls = new MemberControlls();
            Member = memberControlls.GetMember(Email);
            MemberInfoString = JsonSerializer.Serialize(Member);
            HttpContext.Session.SetString("MemberInfo", MemberInfoString);
           
            switch (Submit)
            {
                case "Go":
                    PlayerNumber = (int)HttpContext.Session.GetInt32("PlayerNumber");
                    if (Player1Name == null)
                    {
                        Player1Name = "Player 1";      
                    }
                    if (Player2Name == null)
                    {
                        Player2Name = "Player 2";      
                    }
                    if (Player3Name == null)
                    {
                        Player3Name = "Player 3";      
                    }
                    if (Player4Name == null)
                    {
                        Player4Name = "Player 4";      
                    }
                    HttpContext.Session.SetString("Player1Name", Player1Name);
                    HttpContext.Session.SetString("Player2Name", Player2Name);
                    HttpContext.Session.SetString("Player3Name", Player3Name);
                    HttpContext.Session.SetString("Player4Name", Player4Name);

                    HttpContext.Session.SetInt32("Player1Handicap", Player1Handicap);
                    HttpContext.Session.SetInt32("Player2Handicap", Player2Handicap);
                    HttpContext.Session.SetInt32("Player3Handicap", Player3Handicap);
                    HttpContext.Session.SetInt32("Player4Handicap", Player4Handicap);

                    Complete = true;
                break;
                case"PNumber":
                     HttpContext.Session.SetInt32("PlayerNumber", PlayerNumber);
                break;
                case "My Scores":
                    PlayerNumber = (int)HttpContext.Session.GetInt32("PlayerNumber");
                    Complete = true;
                break;
                case "Post Scores":
                    PlayerNumber = (int)HttpContext.Session.GetInt32("PlayerNumber");
                    Player1Name = HttpContext.Session.GetString("Player1Name");
                    Player2Name = HttpContext.Session.GetString("Player2Name");
                    Player3Name = HttpContext.Session.GetString("Player3Name");
                    Player4Name = HttpContext.Session.GetString("Player4Name");

                    Player1Handicap = (int)HttpContext.Session.GetInt32("Player1Handicap");
                    Player2Handicap = (int)HttpContext.Session.GetInt32("Player2Handicap");
                    Player3Handicap = (int)HttpContext.Session.GetInt32("Player3Handicap");
                    Player4Handicap = (int)HttpContext.Session.GetInt32("Player4Handicap");

                    Complete = true;
                    TeeTimeController teeTimeController = new TeeTimeController();
                    if (PlayerNumber == 1)
                    {
                        Scores = new()
                        {
                            PlayerName = Player1Name,
                            MemberID = Member.MemberID,
                            Date = DateTime.Now,
                            Hole1Score= Player1Hole1Score,
                            Hole2Score= Player1Hole2Score,
                            Hole3Score= Player1Hole3Score,
                            Hole4Score= Player1Hole4Score,
                            Hole5Score= Player1Hole5Score,
                            Hole6Score= Player1Hole6Score,
                            Hole7Score= Player1Hole7Score,
                            Hole8Score= Player1Hole8Score,
                            Hole9Score= Player1Hole9Score,
                            Hole10Score= Player1Hole10Score,
                            Hole11Score= Player1Hole11Score,
                            Hole12Score= Player1Hole12Score,
                            Hole13Score= Player1Hole13Score,
                            Hole14Score= Player1Hole14Score,
                            Hole15Score= Player1Hole15Score,
                            Hole16Score= Player1Hole16Score,
                            Hole17Score= Player1Hole17Score,
                            Hole18Score= Player1Hole18Score,
                            TotalScore = (Player1Hole1Score + Player1Hole2Score + Player1Hole3Score + Player1Hole4Score + Player1Hole5Score +
                                          Player1Hole6Score + Player1Hole7Score + Player1Hole8Score + Player1Hole9Score + Player1Hole10Score +
                                          Player1Hole11Score + Player1Hole12Score + Player1Hole13Score + Player1Hole14Score + Player1Hole15Score +
                                          Player1Hole16Score + Player1Hole17Score + Player1Hole18Score) - Player1Handicap
                        };
                        teeTimeController.InsertGolfScores(Scores);
                        Player1Message = $"{Player1Name} Score {Scores.TotalScore}";
                    }
                    if (PlayerNumber == 2)
                    {
                        Scores = new()
                        {
                            PlayerName = Player1Name,
                            MemberID = Member.MemberID,
                            Date = DateTime.Now,
                            Hole1Score= Player1Hole1Score,
                            Hole2Score= Player1Hole2Score,
                            Hole3Score= Player1Hole3Score,
                            Hole4Score= Player1Hole4Score,
                            Hole5Score= Player1Hole5Score,
                            Hole6Score= Player1Hole6Score,
                            Hole7Score= Player1Hole7Score,
                            Hole8Score= Player1Hole8Score,
                            Hole9Score= Player1Hole9Score,
                            Hole10Score= Player1Hole10Score,
                            Hole11Score= Player1Hole11Score,
                            Hole12Score= Player1Hole12Score,
                            Hole13Score= Player1Hole13Score,
                            Hole14Score= Player1Hole14Score,
                            Hole15Score= Player1Hole15Score,
                            Hole16Score= Player1Hole16Score,
                            Hole17Score= Player1Hole17Score,
                            Hole18Score= Player1Hole18Score,
                            TotalScore = (Player1Hole1Score + Player1Hole2Score + Player1Hole3Score + Player1Hole4Score + Player1Hole5Score +
                                          Player1Hole6Score + Player1Hole7Score + Player1Hole8Score + Player1Hole9Score + Player1Hole10Score +
                                          Player1Hole11Score + Player1Hole12Score + Player1Hole13Score + Player1Hole14Score + Player1Hole15Score +
                                          Player1Hole16Score + Player1Hole17Score + Player1Hole18Score) - Player1Handicap
                        };
                        teeTimeController.InsertGolfScores(Scores);
                        Player1Message = $"{Player1Name} Score {Scores.TotalScore}";
                        Scores = new()
                        {
                            PlayerName = Player2Name,
                            MemberID = Member.MemberID,
                            Date = DateTime.Now,
                            Hole1Score= Player2Hole1Score,
                            Hole2Score= Player2Hole2Score,
                            Hole3Score= Player2Hole3Score,
                            Hole4Score= Player2Hole4Score,
                            Hole5Score= Player2Hole5Score,
                            Hole6Score= Player2Hole6Score,
                            Hole7Score= Player2Hole7Score,
                            Hole8Score= Player2Hole8Score,
                            Hole9Score= Player2Hole9Score,
                            Hole10Score= Player2Hole10Score,
                            Hole11Score= Player2Hole11Score,
                            Hole12Score= Player2Hole12Score,
                            Hole13Score= Player2Hole13Score,
                            Hole14Score= Player2Hole14Score,
                            Hole15Score= Player2Hole15Score,
                            Hole16Score= Player2Hole16Score,
                            Hole17Score= Player2Hole17Score,
                            Hole18Score= Player2Hole18Score,
                            TotalScore = (Player2Hole1Score + Player2Hole2Score + Player2Hole3Score + Player2Hole4Score + Player2Hole5Score +
                                          Player2Hole6Score + Player2Hole7Score + Player2Hole8Score + Player2Hole9Score + Player2Hole10Score +
                                          Player2Hole11Score + Player2Hole12Score + Player2Hole13Score + Player2Hole14Score + Player2Hole15Score +
                                          Player2Hole16Score + Player2Hole17Score + Player2Hole18Score) - Player2Handicap
                        };
                        teeTimeController.InsertGolfScores(Scores);
                        Player2Message = $"{Player2Name} Score {Scores.TotalScore}";
                    }
                    if (PlayerNumber == 3)
                    {
                        Scores = new()
                        {
                            PlayerName = Player1Name,
                            MemberID = Member.MemberID,
                            Date = DateTime.Now,
                            Hole1Score= Player1Hole1Score,
                            Hole2Score= Player1Hole2Score,
                            Hole3Score= Player1Hole3Score,
                            Hole4Score= Player1Hole4Score,
                            Hole5Score= Player1Hole5Score,
                            Hole6Score= Player1Hole6Score,
                            Hole7Score= Player1Hole7Score,
                            Hole8Score= Player1Hole8Score,
                            Hole9Score= Player1Hole9Score,
                            Hole10Score= Player1Hole10Score,
                            Hole11Score= Player1Hole11Score,
                            Hole12Score= Player1Hole12Score,
                            Hole13Score= Player1Hole13Score,
                            Hole14Score= Player1Hole14Score,
                            Hole15Score= Player1Hole15Score,
                            Hole16Score= Player1Hole16Score,
                            Hole17Score= Player1Hole17Score,
                            Hole18Score= Player1Hole18Score,
                            TotalScore = (Player1Hole1Score + Player1Hole2Score + Player1Hole3Score + Player1Hole4Score + Player1Hole5Score +
                                          Player1Hole6Score + Player1Hole7Score + Player1Hole8Score + Player1Hole9Score + Player1Hole10Score +
                                          Player1Hole11Score + Player1Hole12Score + Player1Hole13Score + Player1Hole14Score + Player1Hole15Score +
                                          Player1Hole16Score + Player1Hole17Score + Player1Hole18Score) - Player1Handicap
                        };
                        teeTimeController.InsertGolfScores(Scores);
                        Player1Message = $"{Player1Name} Score {Scores.TotalScore}";
                        Scores = new()
                        {
                            PlayerName = Player2Name,
                            MemberID = Member.MemberID,
                            Date = DateTime.Now,
                            Hole1Score= Player2Hole1Score,
                            Hole2Score= Player2Hole2Score,
                            Hole3Score= Player2Hole3Score,
                            Hole4Score= Player2Hole4Score,
                            Hole5Score= Player2Hole5Score,
                            Hole6Score= Player2Hole6Score,
                            Hole7Score= Player2Hole7Score,
                            Hole8Score= Player2Hole8Score,
                            Hole9Score= Player2Hole9Score,
                            Hole10Score= Player2Hole10Score,
                            Hole11Score= Player2Hole11Score,
                            Hole12Score= Player2Hole12Score,
                            Hole13Score= Player2Hole13Score,
                            Hole14Score= Player2Hole14Score,
                            Hole15Score= Player2Hole15Score,
                            Hole16Score= Player2Hole16Score,
                            Hole17Score= Player2Hole17Score,
                            Hole18Score= Player2Hole18Score,
                            TotalScore = (Player2Hole1Score + Player2Hole2Score + Player2Hole3Score + Player2Hole4Score + Player2Hole5Score +
                                          Player2Hole6Score + Player2Hole7Score + Player2Hole8Score + Player2Hole9Score + Player2Hole10Score +
                                          Player2Hole11Score + Player2Hole12Score + Player2Hole13Score + Player2Hole14Score + Player2Hole15Score +
                                          Player2Hole16Score + Player2Hole17Score + Player2Hole18Score) - Player2Handicap
                        };
                        teeTimeController.InsertGolfScores(Scores);
                        Player2Message = $"{Player2Name} Score {Scores.TotalScore}";
                        Scores = new()
                        {
                            PlayerName = Player3Name,
                            MemberID = Member.MemberID,
                            Date = DateTime.Now,
                            Hole1Score= Player3Hole1Score,
                            Hole2Score= Player3Hole2Score,
                            Hole3Score= Player3Hole3Score,
                            Hole4Score= Player3Hole4Score,
                            Hole5Score= Player3Hole5Score,
                            Hole6Score= Player3Hole6Score,
                            Hole7Score= Player3Hole7Score,
                            Hole8Score= Player3Hole8Score,
                            Hole9Score= Player3Hole9Score,
                            Hole10Score= Player3Hole10Score,
                            Hole11Score= Player3Hole11Score,
                            Hole12Score= Player3Hole12Score,
                            Hole13Score= Player3Hole13Score,
                            Hole14Score= Player3Hole14Score,
                            Hole15Score= Player3Hole15Score,
                            Hole16Score= Player3Hole16Score,
                            Hole17Score= Player3Hole17Score,
                            Hole18Score= Player3Hole18Score,
                            TotalScore = (Player3Hole1Score + Player3Hole2Score + Player3Hole3Score + Player3Hole4Score + Player3Hole5Score +
                                          Player3Hole6Score + Player3Hole7Score + Player3Hole8Score + Player3Hole9Score + Player3Hole10Score +
                                          Player3Hole11Score + Player3Hole12Score + Player3Hole13Score + Player3Hole14Score + Player3Hole15Score +
                                          Player3Hole16Score + Player3Hole17Score + Player3Hole18Score) - Player3Handicap
                        };
                        teeTimeController.InsertGolfScores(Scores);
                        Player3Message = $"{Player3Name} Score {Scores.TotalScore}";
                    }
                    if (PlayerNumber == 4)
                    {
                        Scores = new()
                        {
                            PlayerName = Player1Name,
                            MemberID = Member.MemberID,
                            Date = DateTime.Now,
                            Hole1Score= Player1Hole1Score,
                            Hole2Score= Player1Hole2Score,
                            Hole3Score= Player1Hole3Score,
                            Hole4Score= Player1Hole4Score,
                            Hole5Score= Player1Hole5Score,
                            Hole6Score= Player1Hole6Score,
                            Hole7Score= Player1Hole7Score,
                            Hole8Score= Player1Hole8Score,
                            Hole9Score= Player1Hole9Score,
                            Hole10Score= Player1Hole10Score,
                            Hole11Score= Player1Hole11Score,
                            Hole12Score= Player1Hole12Score,
                            Hole13Score= Player1Hole13Score,
                            Hole14Score= Player1Hole14Score,
                            Hole15Score= Player1Hole15Score,
                            Hole16Score= Player1Hole16Score,
                            Hole17Score= Player1Hole17Score,
                            Hole18Score= Player1Hole18Score,
                            TotalScore = (Player1Hole1Score + Player1Hole2Score + Player1Hole3Score + Player1Hole4Score + Player1Hole5Score +
                                          Player1Hole6Score + Player1Hole7Score + Player1Hole8Score + Player1Hole9Score + Player1Hole10Score +
                                          Player1Hole11Score + Player1Hole12Score + Player1Hole13Score + Player1Hole14Score + Player1Hole15Score +
                                          Player1Hole16Score + Player1Hole17Score + Player1Hole18Score) - Player1Handicap
                        };
                        teeTimeController.InsertGolfScores(Scores);
                        Player1Message = $"{Player1Name} Score {Scores.TotalScore}";
                        Scores = new()
                        {
                            PlayerName = Player2Name,
                            MemberID = Member.MemberID,
                            Date = DateTime.Now,
                            Hole1Score= Player2Hole1Score,
                            Hole2Score= Player2Hole2Score,
                            Hole3Score= Player2Hole3Score,
                            Hole4Score= Player2Hole4Score,
                            Hole5Score= Player2Hole5Score,
                            Hole6Score= Player2Hole6Score,
                            Hole7Score= Player2Hole7Score,
                            Hole8Score= Player2Hole8Score,
                            Hole9Score= Player2Hole9Score,
                            Hole10Score= Player2Hole10Score,
                            Hole11Score= Player2Hole11Score,
                            Hole12Score= Player2Hole12Score,
                            Hole13Score= Player2Hole13Score,
                            Hole14Score= Player2Hole14Score,
                            Hole15Score= Player2Hole15Score,
                            Hole16Score= Player2Hole16Score,
                            Hole17Score= Player2Hole17Score,
                            Hole18Score= Player2Hole18Score,
                            TotalScore = (Player2Hole1Score + Player2Hole2Score + Player2Hole3Score + Player2Hole4Score + Player2Hole5Score +
                                          Player2Hole6Score + Player2Hole7Score + Player2Hole8Score + Player2Hole9Score + Player2Hole10Score +
                                          Player2Hole11Score + Player2Hole12Score + Player2Hole13Score + Player2Hole14Score + Player2Hole15Score +
                                          Player2Hole16Score + Player2Hole17Score + Player2Hole18Score) - Player2Handicap
                        };
                        teeTimeController.InsertGolfScores(Scores);
                        Player2Message = $"{Player2Name} Score {Scores.TotalScore}";
                        Scores = new()
                        {
                            PlayerName = Player3Name,
                            MemberID = Member.MemberID,
                            Date = DateTime.Now,
                            Hole1Score= Player3Hole1Score,
                            Hole2Score= Player3Hole2Score,
                            Hole3Score= Player3Hole3Score,
                            Hole4Score= Player3Hole4Score,
                            Hole5Score= Player3Hole5Score,
                            Hole6Score= Player3Hole6Score,
                            Hole7Score= Player3Hole7Score,
                            Hole8Score= Player3Hole8Score,
                            Hole9Score= Player3Hole9Score,
                            Hole10Score= Player3Hole10Score,
                            Hole11Score= Player3Hole11Score,
                            Hole12Score= Player3Hole12Score,
                            Hole13Score= Player3Hole13Score,
                            Hole14Score= Player3Hole14Score,
                            Hole15Score= Player3Hole15Score,
                            Hole16Score= Player3Hole16Score,
                            Hole17Score= Player3Hole17Score,
                            Hole18Score= Player3Hole18Score,
                            TotalScore = (Player3Hole1Score + Player3Hole2Score + Player3Hole3Score + Player3Hole4Score + Player3Hole5Score +
                                          Player3Hole6Score + Player3Hole7Score + Player3Hole8Score + Player3Hole9Score + Player3Hole10Score +
                                          Player3Hole11Score + Player3Hole12Score + Player3Hole13Score + Player3Hole14Score + Player3Hole15Score +
                                          Player3Hole16Score + Player3Hole17Score + Player3Hole18Score) - Player3Handicap
                        };
                        teeTimeController.InsertGolfScores(Scores);
                        Player3Message = $"{Player3Name} Score {Scores.TotalScore}";
                        Scores = new()
                        {
                            PlayerName = Player4Name,
                            MemberID = Member.MemberID,
                            Date = DateTime.Now,
                            Hole1Score= Player4Hole1Score,
                            Hole2Score= Player4Hole2Score,
                            Hole3Score= Player4Hole3Score,
                            Hole4Score= Player4Hole4Score,
                            Hole5Score= Player4Hole5Score,
                            Hole6Score= Player4Hole6Score,
                            Hole7Score= Player4Hole7Score,
                            Hole8Score= Player4Hole8Score,
                            Hole9Score= Player4Hole9Score,
                            Hole10Score= Player4Hole10Score,
                            Hole11Score= Player4Hole11Score,
                            Hole12Score= Player4Hole12Score,
                            Hole13Score= Player4Hole13Score,
                            Hole14Score= Player4Hole14Score,
                            Hole15Score= Player4Hole15Score,
                            Hole16Score= Player4Hole16Score,
                            Hole17Score= Player4Hole17Score,
                            Hole18Score= Player4Hole18Score,
                            TotalScore = (Player4Hole1Score + Player4Hole2Score + Player4Hole3Score + Player4Hole4Score + Player4Hole5Score +
                                          Player4Hole6Score + Player4Hole7Score + Player4Hole8Score + Player4Hole9Score + Player4Hole10Score +
                                          Player4Hole11Score + Player4Hole12Score + Player4Hole13Score + Player4Hole14Score + Player4Hole15Score +
                                          Player4Hole16Score + Player4Hole17Score + Player4Hole18Score) - Player4Handicap
                        };
                        teeTimeController.InsertGolfScores(Scores);
                        Player4Message = $"{Player4Name} Score {Scores.TotalScore}";
                    }   
                break;
            }
        }
    }
}
