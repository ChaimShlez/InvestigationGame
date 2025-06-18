using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Dal;

namespace InvestigationGame.Entity.IranianEntity
{
    internal static class RemoveSensor
    {
        private static Random rand = new Random();
        public static void Remove(IranianAgent agent)
        {
            int indexRemove = rand.Next(agent.sensors.Count);
            int id = agent.sensors[indexRemove].id;
            DalSensor.DeleteSensor(id);
            agent.sensors.Remove(agent.sensors[indexRemove]);
            
        }
    }
}
