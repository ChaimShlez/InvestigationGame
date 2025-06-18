using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Compiler;
using InvestigationGame.Base;
using malshinonProject.Dal;

namespace InvestigationGame.Dal
{
    internal class DalAgent
    {

        private static ConnectionWrapper _connectionWrapper;

        public DalAgent(ConnectionWrapper connectionWrapper)
        {
            _connectionWrapper = connectionWrapper;
        }


        public static long CreateAgent(IranianAgent agent)
        {
            long idAgent = SaveAgent(agent);

            List<long> idsFromMixture = GetIdFromMix(agent);

            saveAgentMixtures(idAgent, idsFromMixture);
            return idAgent;
        }

        private static List<long> GetIdFromMix(IranianAgent agent)
        {
            List<long> idsFromMixture = new List<long>();
            foreach (var name in agent.enumTypeSensors)
            {
                string sql = @"SELECT SensorId FROM sensors WHERE TypeSensor = @TypeSensor";


                var parameters = new Dictionary<string, object>
                {
                    {"@TypeSensor",name.ToString() },

                };

                var reader = _connectionWrapper.ExecuteSelect(sql, parameters);
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32("SensorId");


                        idsFromMixture.Add(Id);
                    }
                }
            }

            return idsFromMixture;
        }
        private static void saveAgentMixtures(long AgentId, List<long> idsFromMixture)
        {
            int agentId = Convert.ToInt32(AgentId);
            foreach (long SensorId in idsFromMixture)
            {
                string sql = @"INSERT INTO agent_mixtures (AgentId ,SensorId)
                                      VALUES(@AgentId ,@SensorId)";
                int sensorId= Convert.ToInt32(SensorId);
                var parametersFromPersonReport = new Dictionary<string, object>
            {
                {"@AgentId" ,agentId },
                {"@SensorId" ,sensorId}

            };

                _connectionWrapper.ExecutAlertion(sql, parametersFromPersonReport);
            }
            
        }
        private static long SaveAgent(IranianAgent agent)
        {
            string sql = @"INSERT INTO agents (TypeRank,AmountWeaknessesSensors)

                             VALUES(@TypeRank,@AmountWeaknessesSensors)";

            var parameters = new Dictionary<string, object>
                {
                    {"@TypeRank",agent.typeRank.ToString() },
                    {"@AmountWeaknessesSensors",agent.amountWeaknessesSensors }
                };

            return _connectionWrapper.ExecutAlertion(sql, parameters);

           
        }
    }
}
