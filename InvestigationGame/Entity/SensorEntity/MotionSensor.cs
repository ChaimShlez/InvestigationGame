using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Entity.SensorEntity
{
    internal class MotionSensor : Sensor, IBreaks
    {

        private bool IsBroken;
        private int Capacity;

        public MotionSensor() : base(EnumTypeSensor.MotionSensor)
        {

            IsBroken = false;
            Capacity = 3;
        }

        public override ActivateResult Activate(IranianAgent agent)
        {
            Capacity--;
            if (Capacity <= 0)
            {
                IsBroken = true;
            }
            return new ActivateResult("", IsBroken);

        }

        //public bool IsBreaks()
        //{

        //    return isBroken;
        //}

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
