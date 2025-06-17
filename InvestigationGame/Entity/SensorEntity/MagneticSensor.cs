using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Entity.SensorEntity
{
    internal class MagneticSensor : Sensor
    {
        public MagneticSensor() : base(EnumTypeSensor.MagneticSensor)
        {
        }

        public override ActivateResult Activate(IranianAgent agent)
        {
            return new ActivateResult("");
        }
    }
}
