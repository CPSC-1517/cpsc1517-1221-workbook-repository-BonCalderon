using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview1
{
    public class NhlRoster
    {
        private const int MinNo = 0;
        private const int MaxNo = 98;
       
        //private fields number,name,position
        private int _number;
        private string _name;
        private string _position;
        private string _team;

        
        //properties

        

        public int Number //property for number
        {
            get { return _number; }
            set
            {
                if (value < MinNo || value > MaxNo)
                {
                    throw new ArgumentOutOfRangeException($"Invalid Jersey Number. Must choose between {MinNo} and {MaxNo}");
                }
                else
                {
                    _number = value;
                }
            }
        }
        public string Name //property for name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be empty, Must put a name");
                }
                else
                {
                    _name = value.Trim();
                }
            }
        }


        //overloaded constructor or greedy constructor
        public NhlPosition playerPosition { get; set; }
        public NhlRoster(int number, string name,  NhlPosition position) //greedy construcotr for roster class include fully implemented properties
        {
            Number = number;
            Name = name;
            playerPosition = position;
        }

        
        //override the toString method to return to 
        public override string ToString()
        {
            //return base.ToString();
            return $"{Number},{Name},{playerPosition}";
        }
    }
}
