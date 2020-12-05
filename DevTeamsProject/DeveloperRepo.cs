
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create  
        public void AddDeveloperToList(Developer developer)
        {
            _developerDirectory.Add(developer);
        }
       
        //Developer Read
        public List<Developer> GetDeveloperList()
        {
            return _developerDirectory;
        }
        
        //Developer Update
        public bool UpdateExistingDeveloper(int originalDeveloperID, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperById(originalDeveloperID);

            if(oldDeveloper != null)
            {
                oldDeveloper.DeveloperId = newDeveloper.DeveloperId;
                oldDeveloper.Name = newDeveloper.Name;
                oldDeveloper.HasPluralsight = newDeveloper.HasPluralsight;

                return true;
            }
            else
            {
                return false;
            }
        }

        //public int DeveloperID { get; set; }
        //public string Name { get; set; }
        //public bool HasPluralsight { get; set; }


        //Developer Delete
        public bool RemoveDeveloperFromList(int developerID)
        {
            Developer developer = GetDeveloperById(developerID);

            if(developer == null)
            {
                return false;
            }

            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(developer);

            if(initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperById(int developerID)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if(developer.DeveloperId == developerID)
                {
                    return developer;
                }
            }

            return null;
        }
        
      
        
    }
}
