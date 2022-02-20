using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver.Inharitance
{
    public interface IHuman
    {
        public string GetGeneralInfo();
        public void TurnLeft();
        public void TurnRight();
        public void GoStraight();
        public void GoBack();
    }
}
