using System;
using System.Collections.Generic;
using InvestigationGame.Base;
using InvestigationGame.Enum;
using malshinonProject.Dal;

namespace InvestigationGame.Dal
{
    internal class DalSensor
    {
        private ConnectionWrapper _connectionWrapper;

        public DalSensor(ConnectionWrapper connectionWrapper)
        {
            _connectionWrapper = connectionWrapper;
        }

        public void CreateAgentSensor(Sensor sensor, long IDAgent)
        {
            int sensorId = GetIdFromSensor(sensor);

            long id = saveAgentSensor(IDAgent, sensorId);
            // Sensor sensor = CreateObjectSensor(id);
        }

        //private Sensor CreateObjectSensor(long agentSensorId)
        //{
        //    Sensor sensor = null;

        //    string sql = @" SELECT   ags.AgentSensorId   AS AgentSensorId,s.TypeSensor  AS TypeSensor
        //                       FROM agent_sensors AS ags
        //                          JOIN sensors AS s 
        //                         ON s.SensorId = ags.SensorId
        //                         WHERE ags.AgentSensorId = @agentSensorId";

        //    var parameters = new Dictionary<string, object>
        //        {
        //            { "@agentSensorId", Convert.ToInt32(agentSensorId) }
        //        };

        //    var reader = _connectionWrapper.ExecuteSelect(sql, parameters);
        //    if (reader != null)
        //    {
        //        using (reader)
        //        {
        //            if (reader.Read())
        //            {
        //                int id = reader.GetInt32("AgentSensorId");
        //                // Fix: Use System.Enum.Parse instead of InvestigationGame.Enum.Parse
        //                var type = (EnumTypeSensor)Enum.Parse(
        //                    typeof(EnumTypeSensor),
        //                    reader.GetString("TypeSensor")
        //                );
        //                sensor = new Sensor(id, type);
        //            }
        //        }
        //    }

        //    return sensor;
        //}

        private int GetIdFromSensor(Sensor sensor)
        {
            int sensorId = 0;
            string sql = @"SELECT SensorId FROM sensors WHERE TypeSensor = @TypeSensor";

            var parameters = new Dictionary<string, object>
                {
                    { "@TypeSensor", sensor.tpye.ToString() }
                };

            var reader = _connectionWrapper.ExecuteSelect(sql, parameters);
            if (reader != null)
            {
                using (reader)
                {
                    if (reader.Read())
                    {
                        sensorId = reader.GetInt32("SensorId");
                    }
                }
            }

            return sensorId;
        }

        private long saveAgentSensor(long agentId, int sensorId)
        {
            string sql = @"INSERT INTO agent_sensors (AgentId, SensorId)
                               VALUES(@AgentId, @SensorId)";

            var parameters = new Dictionary<string, object>
                {
                    { "@AgentId", Convert.ToInt32(agentId) },
                    { "@SensorId", sensorId }
                };

            return _connectionWrapper.ExecutAlertion(sql, parameters);
        }

        public Dictionary<string, int> dictFromWeaknesses(long agentID)
        {
            Dictionary<string, int> mixtureCounts = new Dictionary<string, int>();
            string sql = @"
                            SELECT sensors.TypeSensor, COUNT(*) AS Count
                            FROM sensors
                            JOIN agent_mixtures ON agent_mixtures.SensorId = sensors.SensorId
                            JOIN agents ON agents.AgentId = agent_mixtures.AgentId
                            WHERE agents.AgentId = @AgentId
                            GROUP BY sensors.TypeSensor";

            var parameters = new Dictionary<string, object>
                {
                    { "@AgentId", Convert.ToInt32(agentID) },
                };

            var reader = _connectionWrapper.ExecuteSelect(sql, parameters);

            if (reader != null)
            {
                while (reader.Read())
                {
                    string name = reader.GetString("TypeSensor");
                    int count = reader.GetInt32("Count");

                    mixtureCounts[name] = count;
                }
            }
            return mixtureCounts;
        }

        public Dictionary<string, int> dictFromSensors(long agentID)
        {
            Dictionary<string, int> dictFromSensors = new Dictionary<string, int>();
            string sql = @"
                           SELECT sensors.TypeSensor, COUNT(*) AS Count
                           FROM sensors
                           JOIN agent_sensors ON agent_sensors.SensorId = sensors.SensorId
                           JOIN agents ON agents.AgentId = agent_sensors.AgentId
                            WHERE agents.AgentId = @AgentId
                            GROUP BY sensors.TypeSensor";

            var parameters = new Dictionary<string, object>
                {
                    { "@AgentId", Convert.ToInt32(agentID) },
                };

            var reader = _connectionWrapper.ExecuteSelect(sql, parameters);

            if (reader != null)
            {
                while (reader.Read())
                {
                    string name = reader.GetString("TypeSensor");
                    int count = reader.GetInt32("Count");

                    dictFromSensors[name] = count;
                }
            }
            return dictFromSensors;
        }
    }
}
