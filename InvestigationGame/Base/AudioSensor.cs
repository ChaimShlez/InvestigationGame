using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Base
{
    internal class AudioSensor
    {
        private string Name;
        private bool IsActivate;

        public AudioSensor(string name)
        {
            Name = name;
            IsActivate = false;
        }

        public virtual bool Activate(string name)
        {
            if(IsActivate == false && name == this.Name)
            {
                IsActivate = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
