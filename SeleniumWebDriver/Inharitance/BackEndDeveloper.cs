using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver.Inharitance
{
    public class BackEndDeveloper : Person, IHuman
    {
        private double yearExperience;
        private int countWorkedPlaces;
        public BackEndDeveloper(double yearExperience, int countWorkedPlaces, string name, string lastname, int age, double height, string position)
            :base(name, lastname, age, height, position)
        {
            YearExperience = yearExperience;
            CountWorkedPlaces = countWorkedPlaces;
        }
        public double YearExperience
        {
            get
            {
                return yearExperience;
            }
            set
            {
                if (value >= 1)
                {
                    yearExperience = value;
                }
                else
                {
                    Console.WriteLine("You should have more than 1 year experience!");
                }
            }
        }
        public int CountWorkedPlaces
        {
            get
            {
                return countWorkedPlaces;
            }
            set
            {
                countWorkedPlaces = value;
            }
        }
        public string GetGeneralInfo()
        {
            return "";
        }

        public void GoBack()
        {
            Console.WriteLine("Developer is going back...");
        }

        public void GoStraight()
        {
            Console.WriteLine("Developer is going straight...");
        }

        public void TurnLeft()
        {
            Console.WriteLine("Developer is turning left...");
        }

        public void TurnRight()
        {
            Console.WriteLine("Developer is turning right...");
        }
    }
}
