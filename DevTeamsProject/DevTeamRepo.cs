using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        //private readonly DeveloperRepo _developerRepo = new DeveloperRepo(); // this gives you access to the _developerDirectory so you can access existing Developers and add them to a team
       
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create
        public void AddTeamToList(DevTeam devTeam)
        {
            _devTeams.Add(devTeam);
        }


        //DevTeam Read
        public List<DevTeam> GetDevTeamList()
        {
            return _devTeams;
        }


        //DevTeam Update
        public bool UpddateExistingTeam(int originalTeamId, DevTeam newDevTeam)
        {
            DevTeam oldDevTeam = GetTeamById(originalTeamId);

            if(oldDevTeam != null)
            {
                oldDevTeam.TeamId = newDevTeam.TeamId;
                oldDevTeam.TeamId = newDevTeam.TeamId;
                oldDevTeam.ListOfDevelopers = newDevTeam.ListOfDevelopers;

                return true;
            }
            else
            {
                return false;
            }
        }

        //public int TeamId { get; set; }
        //public string TeamName { get; set; }
        //public List<Developer> ListOfDevelopers { get; set; } = new List<Developer>();


        //DevTeam Delete
        public bool RemoveTeamFromList(int teamId)
        {
            DevTeam devTeam = GetTeamById(teamId);

            if(devTeam == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(devTeam);

            if(initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //DevTeam Helper (Get Team by ID)
        public DevTeam GetTeamById(int teamId)
        {
            foreach(DevTeam devTeam  in _devTeams)
            {
                if(devTeam.TeamId == teamId)
                {
                    return devTeam;
                } 
            }

            return null;
        }
        
    }
}
