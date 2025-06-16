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
        private bool IsBroken;
        private int Capacity;

        public PulseSensor() : base("PulseSensor")
        {


            IsBroken = false;
            Capacity = 3; 
        }

        public override bool Activate(string name)
        {
           
            if (!isActivate && name == this.name)
            {
                isActivate = true;

                Capacity --;
                if (Capacity <= 0)
                {
                    IsBroken = true;
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












        public bool isBroken
        {
            get { return IsBroken; }
        }

        public int capacity
        {
            get { return Capacity; }
        }
    }
}
