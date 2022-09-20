// See https://aka.ms/new-console-template for more information
using NhlSystem;

Console.WriteLine("09/16/2022 class");

/* Test Plan for Person
 * 
 * Test Case                    Test Data                   Expected Results/Behaviour
 * ---------                    ---------                   --------------------------
 * Valid FullName               FullName = Connor McJezuz    FullName = Connor McJezuz
 * 
 * Null FullName                FullName = Null              ArgumentNullException ("FullName value is required")
 * 
 * Empty FullName               FullName = ""                ArgumentNullExcetption ("FullName value is required")
 * 
 * Whitespace FullName          FullName = "                 ArgumentNullException ("FullName value is required")
 * 
 * FullName < 3 Char            FullName = "AB"              ArgumentException ("FullName must contain 3 or more characters")
 **/


//Test Case 1: Valid FullName

var validPerson = new Person("Connor McJezus");
Console.WriteLine(validPerson.FullName); //the value should be Connor McJezuz

//Test Case 2: Null FullName
try
{
	var nullPerson = new Person(null);
	Console.WriteLine("Test Case failed.");
}
catch (ArgumentNullException ex)
{
	Console.WriteLine(ex.ParamName); //the output should be the error message FullName value is required
}

//Test Case 3: Empty FullName
try
{
    var emptyPerson = new Person("");
    Console.WriteLine("Empty FullName Test Case failed.");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); //the output should be the error message FullName value is required
}
//Test Case 4: Whitespace FullName
try
{
    var whitespacePerson = new Person("           ");
    Console.WriteLine("Whitespace FullName Test Case failed.");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); //the output should be the error message FullName value is required
}

//Test Case5 : FullName < 3 char
try
{
    var invalidFullNameLengthPerson = new Person("AB");
    Console.WriteLine("FullName Lenght Test Case failed.");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); //the output should be the error message FullName must contain 3 or more characters
}

// Test creating a new Team
//pre requisite is a Coach . Create a new Coach for the team
DateTime startDate = DateTime.Parse("2021-09-02");
Coach oilersCoach = new Coach("Jay Woodcroft",startDate);
//create a new Team
Team oilersTeam = new Team("Edmonton Oilers",oilersCoach);
//add 3 players to the team
Player player1 = new Player("Connor McDavid", NhlPosition.C, 97);
Player player2 = new Player("Evander Kane", NhlPosition.LW, 91);
Player player3 = new Player("Leeon Draisaitl", NhlPosition.C, 29);

oilersTeam.AddPlayer(player1);
oilersTeam.AddPlayer(player2);
oilersTeam.AddPlayer(player3);
//assign goals and assists to each player
player1.Goals = 44;
player1.Assists = 79;
player2.Goals = 22;
player2.Assists = 17;
player3.Goals = 55;
player3.Assists = 55;


//check that the Team has 3 players
Console.WriteLine($"Players in team is {oilersTeam.Players.Count}");
//print each player in the team
foreach(Player currentPlayer in oilersTeam.Players)
{
    Console.WriteLine(currentPlayer);
}
//chek the totalPlayerPoints. Should be (44+79+22+17+55+55) = 272
Console.WriteLine($"Total player points is {oilersTeam.TotalPlayerPoints}");
Console.ReadKey();

