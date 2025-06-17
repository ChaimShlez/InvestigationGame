using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;

namespace InvestigationGame.Entity.SensorEntity
{
    internal static class AgentInfromation
    {

        private static Random rand = new Random();

        internal static string GetRank(IranianAgent agent)
        {
            return agent.typeRank.ToString();
        }

        internal static string GetDetailed(IranianAgent agent)
        {
            return $"{agent.typeRank}, {agent.amountWeaknessesSensors}";
        }

        internal static string GetRandomSensorType(IranianAgent agent)
        {
            var values = agent.enumTypeSensors;
            var selectedSensor = values[rand.Next(values.Length)];
            return selectedSensor.ToString();
        }
    }
}
