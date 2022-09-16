using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    public class Person
    {
        // define a fully-implemented property for FUllName with a private set
        private string _fullName = string.Empty; //(get rid of warning); //backing field of the FullName Property
        public string FullName 
        { 
            get  { return _fullName;  } //accessor get=> _fullName; (short syntax for single statement)

            private set 
            {
                //validate new value is not null or empty or whitespace

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("FullName value is required.");
                }
                //validate new value contains at min 3 or more characters
                if (value.Trim().Length < 3)
                {
                    throw new ArgumentException("FullName must contain 3 or more characters.");
                }
                //remove leading and trailing white spaces
                _fullName = value.Trim(); 
            } //mutator
        }

        //create greedy constructor  with a parameter for full name
        public  Person (string fullName) //use the name of the class not the parameter
        {
            FullName = fullName;
        }

    }
}
