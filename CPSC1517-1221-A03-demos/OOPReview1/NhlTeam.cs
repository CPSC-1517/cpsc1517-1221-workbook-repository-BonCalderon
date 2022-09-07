using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview1
{

    public class NhlTeam
    {
        public NhlConference Conference { get; private set; }
        public NhlDivision Division { get; private set; }
        private string _name; //field for the Name property
        public string Name 
        { 
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must contain text.");
                }
                _name = value.Trim();
            }
        }
        private string _city;
        public string City
        {
            get => _city;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("City must contain text.");
                }
                _city = value.Trim();
            }
        }
        private int _gamesPlayed;
        public int GamesPlayed 
        { 
            get => _gamesPlayed;
            set
            {
                if( value < 0)
                {
                    throw new ArgumentOutOfRangeException("Games played has to be greater than 0.");
                }
                _gamesPlayed = value;
            }
        }
        private int _wins;
        public int Wins
        {
            get => _wins;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Wins has to be greater than or equal to 0.");
                }
                _wins = value;
            }
        }
        private int _losses;
        public int Losses
        {
            get => _losses;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Losses has to be greater than or equal to 0.");
                }
                _wins = value;
            }
        }
        private int _overtimeLosses;
        public int OvertimeLosses
        {
            get => _overtimeLosses;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Overtime Losses has to be greater than or equal 0.");
                }
                _overtimeLosses = value;
            }
        }
        public int Points => (Wins * 2) + OvertimeLosses;
        
        public NhlTeam(NhlConference conference, NhlDivision division, string name,string city)
        {
            Conference = conference;
            Division = division;
            Name = name;
            this.City = city;

            GamesPlayed = 0;
            Wins = 0;
            Losses = 0;
            OvertimeLosses = 0;
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{Conference},{Division},{Name},{City},{GamesPlayed},{Wins},{Losses},{OvertimeLosses}";
        }


    }
}
