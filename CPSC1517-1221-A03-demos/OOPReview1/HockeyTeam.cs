using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview1
{

    public class HockeyTeam
    {
        public enum HockeyConference { Eastern, Western }
        public enum HockeyDivision { Metropolitan, Atlantic, Central, Pacific }


        //define data fields for storing data
        private HockeyConference _conference;
        private HockeyDivision _division;

        //define fully-implemented properties for data fields
        public HockeyConference Conference
        {
            get { return _conference; }
            set { _conference = value; }
        }
        public HockeyDivision Division 
        {
            get { return _division; }
            set { _division = value; }
        } 
    }
}
