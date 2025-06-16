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
        

        public ThermalSensor() : base("ThermalSensor")
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

        public string GatherInformation(IranianAgent agent)
        {
            Random rand = new Random();
            var values = System.Enum.GetValues(typeof(EnumTypeSensor));
            var selectedSensor = (EnumTypeSensor)values.GetValue(rand.Next(values.Length));
            return selectedSensor.ToString(); 
        }
    }
}
