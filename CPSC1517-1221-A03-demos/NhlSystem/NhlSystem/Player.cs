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
        //define auto-implemented properties for prosition,goals,assists,and primary number
        public int PrimaryNo { get; set; } 
        public NhlPosition Position { get; set; }
        public int Goals { get; set; }  
        public int Assists { get; set; }    

        //define a read-only computed property for points
        public int Points
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

    }
}
