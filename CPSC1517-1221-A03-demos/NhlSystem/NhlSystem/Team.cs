using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    public class Team
    {
        // define a readonly property for the Coach
        public Coach Coach { get; private set; } = null!;//coach property us known as Aggregation/Composition when the field is an object

        //define an auto imp read only propery for Players
        public List<Player> Players { get; } = new List<Player>();

        //define a method used to add a new Player to the Team
        public void AddPlayer(Player newPlayer)
        {
            //validate that new player is not null
            if (newPlayer == null)
            {
                throw new ArgumentNullException("Player is required");
            }
            //validate that the tema size(23) is not full
            if (Players.Count >= 3)//testing phase
            {
                throw new ArgumentException("Team is full. Cannot add any more players");
            }
            //validate that the newPlayer primary number is not aready in used
            bool primaryNoFound = false;
            foreach (Player currentPlayer in Players)
            {
                if (currentPlayer.PrimaryNo == newPlayer.PrimaryNo)
                {
                    primaryNoFound = true;
                    break;
                }
            }
            if (primaryNoFound)
            {
                throw new ArgumentException("PrimaryNo is already in use by another player");
            }

            //add the newPlayer to the team
            Players.Add(newPlayer);
        }

        //define a computed-property to return the total of Points of all players
        public int TotalPlayerPoints
        {
            get
            {
                int totalPoints = 0;
                foreach(Player currentPlayer in Players)
                {
                    totalPoints += currentPlayer.Points; //+= is totalPoints + currentPlayer.Points
                }
                return totalPoints;
            }
        }

        // define a fully imp property with a backing field for TeamName
        private string _teamName = string.Empty;
        public string TeamName
        {
            get
            {
                return _teamName;
            }
            set
            {
                //vallidate for not null, empty string, or only whitespaces
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("TeamName is required.");
                }
                else if (value.Trim().Length < 5)
                {
                    throw new ArgumentException("TeamName must contain 5 or more characters");
                }
                else
                {
                _teamName = value;
                }
            }
        }

        public Team(string teamName,Coach coach)
        {
            if (coach == null)
            {
                throw new ArgumentNullException("A Team requires a Coach.");
            }
            Coach = coach;
            TeamName = teamName;
            
        }

        public override string ToString()
        {
            return $"{TeamName},{Coach}";
        }
    }
}
