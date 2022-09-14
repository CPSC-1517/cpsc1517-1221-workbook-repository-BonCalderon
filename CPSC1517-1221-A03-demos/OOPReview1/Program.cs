// See https://aka.ms/new-console-template for more information
using OOPReview1;

//Test creating a new Roster with valid values
//var validPlayer1 = new NhlRoster(97, "Connor McDavid", NhlPosition.C);
//var validPlayer1 = new Roster(91, "Connor McDavid", NhlPosition.C);
//print the validPlayer1 object to screen
//the number should be 97, name should be Connor McDavid and position
//should be C
//Console.WriteLine(validPlayer1);
/*try
{
    //test creating a new Roster with an invalid No
    NhlRoster invalidPlayer1 = new NhlRoster(100, "Leon Draisatil", NhlPosition.C);
    //an ArgumentOutOfRanceException should be thrown with a message
    //identify what the error is
}
catch (ArgumentOutOfRangeException ex)
{
    // the parameter name of the exception should be between {MinNo} and {MaxNo}
    //Console.WriteLine(ex.Message);//this will include type of error and we dont need that
    
    Console.WriteLine(ex.ParamName); //use this when dealing with outof range exception


}*/
try
{
    //test creating a new Roster with an invalid null name
    NhlRoster invalidPlayer2 = new NhlRoster(69,null, NhlPosition.C);
    //an ArgumentOutOfRanceException should be thrown with a message
    //identify what the error is
}
catch ( ArgumentNullException ex)
{
    // 
    //Console.WriteLine(ex.Message);//this will include type of error and we dont need that

    Console.WriteLine(ex.ParamName); //use this when dealing with outof range exception


}
try
{
    //test creating a new Roster with an invalid white space name
    NhlRoster invalidPlayer2 = new NhlRoster(69, "                ", NhlPosition.C);
    //an ArgumentOutOfRanceException should be thrown with a message
    //identify what the error is
}
catch (ArgumentNullException ex)
{
    // 
    //Console.WriteLine(ex.Message);//this will include type of error and we dont need that

    Console.WriteLine(ex.ParamName); //use this when dealing with outof range exception


}





var senators = new NhlTeam(
    NhlConferene.Eastern, 
    NhlDivision.Atlantic,
    "Senators",
    "Ottawa");
senators.GamesPlayed = 82;
senators.Wins = 33;
senators.Losses = 42;
senators.OvertimeLosses = 7;
// Print the Points - should be 73
Console.WriteLine(senators);
Console.WriteLine($"Points = {senators.Points}");



Console.ReadKey();
    


