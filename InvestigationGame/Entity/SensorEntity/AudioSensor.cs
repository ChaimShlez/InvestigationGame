using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;

namespace InvestigationGame.Entity.IranianEntity
{
    internal class AudioSensor : Sensor
    {
        public AudioSensor() : base("AudioSensor")
        {
        }

        public override bool Activate(string name)
        {
            if (!isActivate)
            {
                isActivate = true;

            }
            if (name == this.name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
