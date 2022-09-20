using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    //define class name player that inherits from person
    public class Player : Person
    {
        //define auto-implemented properties for prosition,goals,assists
        
        //define fully imp property with backing field for primary number
        private int _primaryNo;
        public int PrimaryNo
        {
            get
            {
                return _primaryNo;
            }
            set
            {
                //validate the new value is between the range of 0 and 98
                if (value < 0 || value > 98)
                {
                    throw new ArgumentOutOfRangeException("PrimaryNO must be between 0 and 98");
                }
                else
                {
                    _primaryNo = value;
                }
            }
        }

        public int Goals { get; set; }  
        public int Assists { get; set; }
        public NhlPosition Position { get; set; }

      

        //define a read-only computed property for points
        public int Points //computed property no fields.
        {
            get { return Goals + Assists; }
        }
        //define constructor that passes fullName to Person base class
        public Player(string fullName, NhlPosition position, int primaryNo) : base(fullName)
        {
            Position = position;
            PrimaryNo = primaryNo;
            Goals = 0;
            Assists = 0;
        }
        public Player(string fullName, NhlPosition position, int primaryNo, int goals,int assists) : base(fullName)
        {
            Position = position;
            PrimaryNo = primaryNo;
            Goals = goals;
            Assists = assists;
        }

        public override string ToString()
        {
            return $"{FullName},{PrimaryNo},{Position},{Goals},{Assists},{Points}";
        }

    }
}
