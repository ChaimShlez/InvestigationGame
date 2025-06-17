using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Entity.SensorEntity
{
    internal class LightSensor : Sensor, IGetInfromation
    {
        public LightSensor() : base(EnumTypeSensor.LightSensor)
        {
        }

        public override ActivateResult Activate(IranianAgent agent)
        {
            string str = GatherInformation(agent);

            return new ActivateResult(str);
        }

        public string GatherInformation(IranianAgent agent)
        {

            return AgentInfromation.GetDetailed(agent);
        }
    }
}
