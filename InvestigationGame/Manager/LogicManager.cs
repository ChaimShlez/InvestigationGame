using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Dal;
using InvestigationGame.Enum;

namespace InvestigationGame.Manager
{
    internal class LogicManager
    {

      
        internal int CheckingMatches( long IDAgent)
        {

            var dictFromWeaknesses= DalSensor.dictFromWeaknesses(IDAgent);

          
            var dictFromSensors = DalSensor.dictFromSensors(IDAgent);
            int match = 0;

            foreach (var item in dictFromSensors)
            {
                string key = item.Key;
                int amountTypeInSensors = item.Value;

                if (dictFromWeaknesses.ContainsKey(key))
                {
                    int amountInWeaknesses = dictFromWeaknesses[key];
                    match += Math.Min(amountTypeInSensors, amountInWeaknesses);
                }
            }
            return match;
        }
       
        
    }
}
