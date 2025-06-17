using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Entity.SensorEntity
{
    internal class PulseSensor : Sensor, IBreaks
    {
        private bool IsBroken;
        private int Capacity;

        public PulseSensor() : base(EnumTypeSensor.PulseSensor)
        {


            IsBroken = false;
            Capacity = 3; 
        }

        public override ActivateResult Activate(IranianAgent agent)
        {
           
            

                Capacity --;
                if (Capacity <= 0)
                {
                    IsBroken = true;
                }
            return new ActivateResult("", IsBroken);
            
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
