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




