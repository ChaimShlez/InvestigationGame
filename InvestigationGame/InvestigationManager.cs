using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame
{
    internal class InvestigationManager
    {

        private IranianAgent Agent;

        public InvestigationManager(IranianAgent agent)
        {
            Agent = agent;
        }

        public void AttachSensor(EnumTypeSensor sensorType)
        {
            Sensor sensor = SensorFactory.CreateSensor(sensorType);
            Agent.AttachSensor(sensor);

        }


        public void Game()
        {

            int maxChoice = 10;

            while(maxChoice > 0)
            {
                $"1. choice {EnumTypeSensor.AudioSensor}\n" +
                $"2. choice {EnumTypeSensor.ThermalSensor}\n" +
                $"3. choice {EnumTypeSensor.PulseSensor}");

            }
        }
    }
}
