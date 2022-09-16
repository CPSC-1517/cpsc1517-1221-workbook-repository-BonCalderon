using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    //define class name Coach that inherits from the base class Person
    public class Coach : Person // colon is the inheritance  meanas Coach class will inherit from Person class
    {
        //Define an auto-implemented property for HireDate
        public DateTime HireDate { get; set; }

        //define cosntructor that passes FullName to the Person base Class
        public Coach(String fullName, DateTime hireDate) : base(fullName)
        {
            HireDate = hireDate;
        }

    }
}
