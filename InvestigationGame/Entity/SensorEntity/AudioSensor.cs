using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Entity.IranianEntity
{
    internal class AudioSensor : Sensor
    {
        public AudioSensor(int id) : base(id,EnumTypeSensor.AudioSensor)
        {
        }

        public override ActivateResult Activate(IranianAgent agent)
        {


            return new ActivateResult("");
            
        }
    }
}
