using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    // id of type int
    // string name 
    // bool hasPluralsight
    public class Developer
    {
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public bool HasPluralsight { get; set; }
        public Developer() { }
        public Developer(int developerId, string name, bool hasPluralsight)
        {
            DeveloperId = developerId;
            Name = name;
            HasPluralsight = hasPluralsight;
        }


    }
}
