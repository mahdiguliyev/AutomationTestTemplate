using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver.Inharitance
{
    public abstract class Person
    {
        private string name;
        private string lastname;
        private int age;
        private double height;
        private string position;
        public Person(string namep, string lastnamep, int agep, double heightp, string positionp)
        {
            Name = namep;
            Lastname = lastnamep;
            Age = agep;
            Height = heightp;
            Position = positionp;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 18)
                {
                    Console.WriteLine("Your age should be over 18!");
                }
                age = value;
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public override string ToString()
        {
            return "Your full name: " + Name + " " + Lastname + "\n" + "Your position: " + Position;
        }
    }
}
