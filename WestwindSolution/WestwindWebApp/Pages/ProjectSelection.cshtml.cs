using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestwindWebApp.Models;

namespace WestwindWebApp.Pages
{
    public class ProjectSelectionModel : PageModel
    {
        private readonly IHostEnvironment environment;

        public ProjectSelectionModel(IHostEnvironment environment)
        {
            
        }
        public List<Student> Students { get; private set; } /*= new List<Student>();*/

        public void OnGet()
        {
            Students = new List<Student>();
            using(StreamReader reader = new StreamReader("wwwroot/data/CPSC1517.1221.A03.ClassList.txt")) //construct stream reader object
            {
                reader.ReadLine(); //read online  at a time
                string line;
                while ( (line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(','); //file is separated by comma and starting from the right is the index fname[0],lname[1],id[2]
                    Student currentStudent = new Student(); //currentStudent to generate a new student in the list
                    currentStudent.Id = int.Parse(parts[2]);
                    currentStudent.FirstName = parts[0];
                    currentStudent.LastName = parts[1];
                    Students.Add(currentStudent); //to add the student in the list
                }
            }
           // var dataFilePath = Path.Combine(Environment.Web)
        }
    }
}
