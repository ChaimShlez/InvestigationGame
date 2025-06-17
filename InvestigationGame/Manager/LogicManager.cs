using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Manager
{
    internal class LogicManager
    {

        internal int CheckingMatches(IranianAgent Agent)
        {



            var dictFromWeaknesses = insertToDict(Agent.enumTypeSensors);
            var dictFromSensors = insertToDict(Agent.sensors);
            int match = 0;

            foreach (var item in dictFromSensors)
            {
                EnumTypeSensor typeKey = item.Key;
                int amountTypeInSensors = item.Value;

                if (dictFromWeaknesses.ContainsKey(typeKey))
                {
                    int amountInWeaknesses = dictFromWeaknesses[typeKey];
                    match += Math.Min(amountTypeInSensors, amountInWeaknesses);
                }
            }
            return match;
        }
        internal Dictionary<EnumTypeSensor, int> insertToDict(EnumTypeSensor[] sensorTypes)
        {
            Dictionary<EnumTypeSensor, int> dictAmountTypesFromWeaknesses = new Dictionary<EnumTypeSensor, int>();

            foreach (EnumTypeSensor type in sensorTypes)
            {

                if (dictAmountTypesFromWeaknesses.ContainsKey(type))
                {
                    dictAmountTypesFromWeaknesses[type]++;
                }
                else
                {
                    dictAmountTypesFromWeaknesses[type] = 1;
                }
            }
            return dictAmountTypesFromWeaknesses;
        }
        internal Dictionary<EnumTypeSensor, int> insertToDict(List<Sensor> sensors)
        {
            Dictionary<EnumTypeSensor, int> dictAmountTypesFromSensors = new Dictionary<EnumTypeSensor, int>();
            foreach (Sensor sensor in sensors)
            {
                EnumTypeSensor type = sensor.tpye;
                if (dictAmountTypesFromSensors.ContainsKey(type))
                {
                    dictAmountTypesFromSensors[type]++;
                }
                else
                {
                    dictAmountTypesFromSensors[type] = 1;
                }
            }
            return dictAmountTypesFromSensors;
        }
    }
}
