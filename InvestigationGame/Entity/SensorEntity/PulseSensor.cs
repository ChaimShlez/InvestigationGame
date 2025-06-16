using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;

namespace InvestigationGame.Entity.SensorEntity
{
    internal class PulseSensor : Sensor, IBreaks
    {
        private bool isBroken;
        private int capacity;

        public PulseSensor() : base("PulseSensor")
        {
            isBroken = false;
            capacity = 3; 
        }

        public override bool Activate(string name)
        {
           
            if (!isActivate && name == this.name)
            {
                isActivate = true;

                capacity --;
                if (capacity <= 0)
                {
                    isBroken = true;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsBreaks()
        {

            return isBroken;
        }












        public bool IsBroken
        {
            get { return isBroken; }
        }

        public int amountCapsity
        {
            get { return capacity; }
        }
    }
}
