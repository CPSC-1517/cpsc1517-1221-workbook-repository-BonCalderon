// See https://aka.ms/new-console-template for more information
using OOPReview1;

NhlTeam Senators = new NhlTeam(NhlConference.Easter,NhlDivision.Atlantic,"Senators","Ottawa");
Senators.GamesPlayed = 82;
Senators.Wins = 33;
Senators.Losses = 42;
Senators.OvertimeLosses = 7;
//pring the points should be 73
Console.Write(Senators);
Console.WriteLine($"\nPoints = {Senators.Points}");
