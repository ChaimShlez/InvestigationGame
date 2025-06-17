using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Entity;
using InvestigationGame.Enum;

namespace InvestigationGame
{
    internal class InvestigationManager
    {

        private IranianAgent Agent;

        public InvestigationManager(IranianAgent agent)
        {
            Agent = agent;
            Game();
           foreach(var item in Agent.enumTypeSensors)
            {
                Console.WriteLine(item);
            }
        }

        public void AttachSensor(EnumTypeSensor sensorType)
        {
            Sensor sensor = SensorFactory.CreateSensor(sensorType);
            Agent.AttachSensor(sensor);
            AllActivates();
            
        }

        private void AllActivates()
        {
           foreach(var sensor in Agent.sensors)
            {
                ActivateResult result = sensor.Activate(Agent);
                if (result.IsBroken == true)
                {
                    Agent.sensors.Remove(sensor);
                }
                if (!string.IsNullOrWhiteSpace(result.Info))
                {
                    Console.WriteLine($"information : {result.Info}");
                }

            }
            int match= CheckingMatches();

            Console.WriteLine($"{match}/ {Agent.enumTypeSensors.Length}");
            if(match == Agent.enumTypeSensors.Length)
            {
                Console.WriteLine("You won, you caught the agent");
                Environment.Exit(0);
            }
        }

        private int CheckingMatches()
        {
            
            var dictFromWeaknesses = insertToDict(Agent.enumTypeSensors);
            var dictFromSensors = insertToDict(Agent.sensors);
            int match = 0;

            foreach(var item in dictFromSensors)
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
        private Dictionary<EnumTypeSensor, int> insertToDict(EnumTypeSensor[] sensorTypes)
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
        private Dictionary<EnumTypeSensor, int> insertToDict(List<Sensor> sensors)
        {
            Dictionary<EnumTypeSensor, int> dictAmountTypesFromSensors = new Dictionary<EnumTypeSensor, int>();
            foreach(Sensor sensor in sensors)
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

        public void Game()
        {
            int maxChoice = 10;

            while (maxChoice > 0)
            {
                Console.WriteLine(
                    $"1. choice {EnumTypeSensor.AudioSensor}\n" +
                    $"2. choice {EnumTypeSensor.ThermalSensor}\n" +
                    $"3. choice {EnumTypeSensor.PulseSensor}");

                Console.Write("Please enter your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AttachSensor(EnumTypeSensor.AudioSensor);
                            break;
                        case 2:
                            AttachSensor(EnumTypeSensor.ThermalSensor);
                            break;
                        case 3:
                            AttachSensor(EnumTypeSensor.PulseSensor);
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                maxChoice--;

                if (maxChoice == 0)
                {
                    Console.WriteLine("Game over");
                    Environment.Exit(0);
                }
            }
            
        }

    }
}
