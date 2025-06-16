using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Base
{
    internal abstract class Sensor
    {
        private string Name;
        private bool IsActivate;

        public Sensor(string name)
        {
            Name = name;
            IsActivate = false;
        }

        public abstract bool Activate(string name);
        
           
        

        

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public bool isActivate
        {
            get { return IsActivate; }
            set { IsActivate= value; }
        }

    }
}
