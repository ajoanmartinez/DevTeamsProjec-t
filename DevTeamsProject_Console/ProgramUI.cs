using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject_Console
{
    class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();


        public void Run()
        {
            SeedDeveloperList(); // This method will fire off one time right before the menu runs
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)

            // Display Options to the user

            {
                Console.WriteLine("Select a menu option\n" +
                    "1. Create new developer\n" +
                    "2. View all developers\n" +
                    "3. View developer by ID\n" +
                    "4. Update existing developer\n" +
                    "5. Delete existing developoer\n" +
                    "6. Create new dev team\n" +
                    "7. View all dev teams\n" +
                    "8. View dev team by ID\n" +
                    "9. Update existing dev team\n" +
                    "10. Add developer to existing dev team\n" +
                    "11. Delete developer from existing dev team\n" +
                    "12. Exit");

                // Get user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create New Developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        //View All Developers
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        //View Developer by ID
                        DisplayDeveloperById();
                        break;
                    case "4":
                        //Update Existing Developer
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        //Delete Existing Developer
                        DeleteExistingDevelper();
                        break;
                    case "6":
                        //Create New Dev Team
                        CreateNewDevTeam();
                       break;
                    case "7":
                        //View All Dev Teams
                        DisplayAllDevTeams();
                        break;
                    case "8":
                        //View Dev Team by ID
                        DisplayDevTeamById();
                        break;
                    case "9":
                        //Update Existing Dev Team
                        UpdateExistingDevTeam();
                        break;
                    case "10":
                        //Add Developer to Existing Team
                        AddDeveloperToTeam();
                        break;
                    case "11":
                        //Remove Developer from Existing Team
                        RemoveDeveloperFromTeam();
                        break;
                    case "12":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;

                }

                Console.WriteLine("Please press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        // Create New Developer
        private void CreateNewDeveloper() 
        {
            Console.Clear();

            Developer newDeveloper = new Developer();

            // Developer ID
            Console.WriteLine("Enter the developer's unique ID:");
            string devIdAsString = Console.ReadLine();
            newDeveloper.DeveloperId = int.Parse(devIdAsString);

            // --- How do we ensure the ID entered is unique? --- //

            // Name
            Console.WriteLine("Enter the developer's name");
            newDeveloper.Name = Console.ReadLine();

            // Has Pluralsight
            Console.WriteLine("Does the developer have access to Pluralsight? (y/n)");
            string hasPluralsightString = Console.ReadLine().ToLower();

            if(hasPluralsightString == "y")
            {
                newDeveloper.HasPluralsight = true;
            }
            else
            {
                newDeveloper.HasPluralsight = false;

            }

        }

        // View All Developers
        private void DisplayAllDevelopers()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            foreach(Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Name: {developer.Name}\n" +
                    $"Developer ID: {developer.DeveloperId}");
            }
        }

        // View Developer by ID
        private void DisplayDeveloperById()
        {
            Console.Clear();

            // Prompt user to give the developer's ID
            Console.WriteLine("Enter the developer's ID you would like to see:");

            // Get the user's input
            int developerId = Convert.ToInt16(Console.ReadLine());


            // Find the developer by that ID
            Developer developer = _developerRepo.GetDeveloperById(developerId);

        }

        // Update Existing Developer
        private void UpdateExistingDeveloper()
        {
            // Display All Developers
            DisplayAllDevelopers();

            // Ask for Developer ID to update
            Console.WriteLine("\nEnter the Developer ID you would like to update:");

            //Caputre developer ID input from user
            int oldDevId = Convert.ToInt16(Console.ReadLine());


            // Build new object - Go steal cod from the add new developer, everything except Conosle.Clear, 
            // and _developerRep at teh end of mehtod
            Developer newDeveloper = new Developer();

            // Update developer ID property 
            Console.WriteLine("Enter developer ID:");
            string newDevIdAsString = Console.ReadLine();
            newDeveloper.DeveloperId = int.Parse(newDevIdAsString);


            // Update Name property
            Console.WriteLine("Enter developer name:");
            newDeveloper.Name = Console.ReadLine();

            // Update Has Pluralsight property
            Console.WriteLine("Does the developer have access to Pluralsight? (y/n) ");
            string hasPluralsightString = Console.ReadLine().ToLower();

            if (hasPluralsightString == "y")
            {
                newDeveloper.HasPluralsight = true;
            }
            else
            {
                newDeveloper.HasPluralsight = false;
            }

            // Verify the update worked
            bool wasUpdated = _developerRepo.UpdateExistingDeveloper(oldDevId, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Developer was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update developer");
            }


        }

        // Deleting Existing Developer
        private void DeleteExistingDevelper()
        {
            
            // Display List of Developers
            DisplayAllDevelopers();

            // Prompt user to get developer by developer ID
            Console.WriteLine("\nEnter the developer's ID you would like to remove:");

            //Caputre developer ID input from user
            int input = Convert.ToInt16(Console.ReadLine());

            // Call delete method
            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(input);

            // Verify the devloper was deleted and tell the user if it was, or was not
            if (wasDeleted)
            {
                Console.WriteLine("The developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Developer could not be deleted.");
            }

        }

        // Create New Dev Team
        private void CreateNewDevTeam()
        {
            Console.Clear();

            DevTeam newDevTeam = new DevTeam();

            // Dev Team ID
            Console.WriteLine("Enter the dev team ID:");
            string teamIdAsString = Console.ReadLine();
            newDevTeam.TeamId = int.Parse(teamIdAsString);         

            // Dev Team Name
            Console.WriteLine("Enter the dev team name");
            newDevTeam.TeamName = Console.ReadLine();

            // List of Devolopers--????
            //List<Developer> ListOfDevelopers = new List<Developer>();
        }

        // View All Dev Teams
        private void DisplayAllDevTeams()
        {
            Console.Clear();

            List<DevTeam> listOfTeams = _devTeamRepo.GetDevTeamList();

            foreach (DevTeam team in listOfTeams)
            {
                Console.WriteLine($"Team Name: {team.TeamName}\n" +
                    $"Team ID: {team.TeamId}");
            }
        }

        // View Dev Team by ID
        private void DisplayDevTeamById()
        {
            Console.Clear();

            // Prompt user to give the DevTeam ID
            Console.WriteLine("Enter the Team ID you would like to see:");

            // Get the user's input
            int teamId = Convert.ToInt16(Console.ReadLine());


            // Find the dev team by that ID
            DevTeam devTeam = _devTeamRepo.GetTeamById(teamId);

        }

        // Update Existing Dev Team
        private void UpdateExistingDevTeam()
        {
            // Display All Dev Teams
            DisplayAllDevTeams();

            // Ask for Dev Team ID to update
            Console.WriteLine("\nEnter the dev team ID you would like to update:");

            //Caputre developer ID input from user
            int oldDevTeamId = Convert.ToInt16(Console.ReadLine());


            // Build new object - Go steal cod from the add new developer, everything except Conosle.Clear, 
            // and _developerRep at teh end of mehtod
            DevTeam newDevTeam = new DevTeam();

            // Update Dev Team ID property 
            Console.WriteLine("Enter dev team ID:");
            string newDevTeamAsString = Console.ReadLine();
            newDevTeam.TeamId = int.Parse(newDevTeamAsString);


            // Update Team Name property
            Console.WriteLine("Enter dev team name:");
            newDevTeam.TeamName = Console.ReadLine();

            // Update list of developers?
            

            
        }

        // Add Developer to Existing Team
        private void AddDeveloperToTeam()
        {
            // Display list of existing teams
            DisplayAllDevTeams();

            // Prompt user to select team from list 
            Console.WriteLine("Please select a team:");
            int teamId = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            // Display all developers
            DisplayAllDevelopers();

            // Prompt user to select developer from list
            Console.WriteLine("Please select a developer:");
            int developerId = Convert.ToInt32(Console.ReadLine());

            DevTeam devTeam = _devTeamRepo.GetTeamById(teamId);
            Developer developer = _developerRepo.GetDeveloperById(developerId);

            //Add developer object to list of developers
            devTeam.ListOfDevelopers.Add(developer);
        }
     
       // Remove Developer from Existing Team
       private void RemoveDeveloperFromTeam()
        {
            // Display list of existing teams
            DisplayAllDevTeams();

            // Prompt user to select team from list 
            Console.WriteLine("Please select a team:");
            int teamId = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            // Display all developers
            DisplayAllDevelopers();

            // Prompt user to select developer from list
            Console.WriteLine("Please select a developer:");
            int developerId = Convert.ToInt32(Console.ReadLine());

            DevTeam devTeam = _devTeamRepo.GetTeamById(teamId);
            Developer developer = _developerRepo.GetDeveloperById(developerId);

            //Add developer object to list of developers
            devTeam.ListOfDevelopers.Remove(developer);

        }

        private void SeedDeveloperList()
        {

            // Fill out a few developer objects and add them to the list

            Developer developer = new Developer (1, "Amy Martinez", true);
            

            // After we have filled out a few streaming content objects, we now want to call our developer repository
            _developerRepo.AddDeveloperToList(developer);
           
            // Now we need to call SeedContetList method, We see we have zero references, nothing is being referenced in the method
            // SCROLL BACK UP TO THE TOP TO RUN METHOD

        }



    }
}
