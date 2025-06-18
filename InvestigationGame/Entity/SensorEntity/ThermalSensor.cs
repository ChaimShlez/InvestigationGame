using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Entity.SensorEntity
{
    internal class ThermalSensor : Sensor, IGetInfromation
    {
        

        public ThermalSensor(int id) : base(id,EnumTypeSensor.ThermalSensor)
        {
        }

        public override ActivateResult Activate(IranianAgent agent)
        {
            string str=GatherInformation(agent);

            return new ActivateResult(str);
        }
       

        public string GatherInformation(IranianAgent agent)
        {
            return AgentInfromation.GetRandomSensorType(agent);
        }

    }
}
