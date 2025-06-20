﻿using System;
using System.Collections.Generic;
using InvestigationGame.Base;
using InvestigationGame.Enum;
using InvestigationGame.Factory;
using malshinonProject.Dal;

namespace InvestigationGame.Dal
{
    internal  class DalSensor
    {
        private static ConnectionWrapper _connectionWrapper;

        public DalSensor(ConnectionWrapper connectionWrapper)
        {
            _connectionWrapper = connectionWrapper;
        }

        public static Sensor  CreateAgentSensor(EnumTypeSensor sensorType, long IDAgent)
        {
            int sensorId = GetIdFromSensor(sensorType);

            long id = saveAgentSensor(IDAgent, sensorId);
            Sensor sensor = CreateObjectSensor(id);
            return sensor;
        }

        private static Sensor CreateObjectSensor(long agentSensorId)
        {
            Sensor sensor = null;

            string sql = @" SELECT   ags.AgentSensorId   AS AgentSensorId,s.TypeSensor  AS TypeSensor
                               FROM agent_sensors AS ags
                                  JOIN sensors AS s 
                                 ON s.SensorId = ags.SensorId
                                 WHERE ags.AgentSensorId = @agentSensorId";

            var parameters = new Dictionary<string, object>
                {
                    { "@agentSensorId", Convert.ToInt32(agentSensorId) }
                };

            var reader = _connectionWrapper.ExecuteSelect(sql, parameters);
            if (reader != null)
            {
                using (reader)
                {
                    if (reader.Read())
                    {
                        int id = reader.GetInt32("AgentSensorId");
                        var type = (EnumTypeSensor)System.Enum.Parse(typeof(EnumTypeSensor), reader.GetString("TypeSensor"));

                        sensor = SensorFactory.CreateSensor(id, type);

                    }
                }
            }

            return sensor;
        }

        private static int GetIdFromSensor(EnumTypeSensor sensorType)
        {
            int sensorId = 0;
            string sql = @"SELECT SensorId FROM sensors WHERE TypeSensor = @TypeSensor";

            var parameters = new Dictionary<string, object>
                {
                    { "@TypeSensor", sensorType.ToString() }
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

        private static long saveAgentSensor(long agentId, int sensorId)
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

        public static Dictionary<string, int> dictFromWeaknesses(long agentID)
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

        public static Dictionary<string, int> dictFromSensors(long agentID)
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


        public static void DeleteSensor(int id)
        {
            string sql = @"DELETE FROM agent_sensors WHERE AgentSensorId=@AgentSensorId";

            var parameters = new Dictionary<string, object>
                {
                    { "AgentSensorId", id },
                };

             _connectionWrapper.ExecutAlertion(sql, parameters);
        }
    }
}
