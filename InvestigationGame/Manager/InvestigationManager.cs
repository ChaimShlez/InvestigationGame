using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Entity;
using InvestigationGame.Enum;
using InvestigationGame.Factory;

namespace InvestigationGame.Manager
{
    internal class InvestigationManager
    {

        private IranianAgent Agent;
        private LogicManager logicManager;

        public InvestigationManager(IranianAgent agent  ,LogicManager _logicManager)
        {
            Agent = agent;
            logicManager = _logicManager;
            Game();
           
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
            int match = logicManager.CheckingMatches(Agent);

            Console.WriteLine($"{match}/ {Agent.enumTypeSensors.Length}");
            if(match == Agent.enumTypeSensors.Length)
            {
                Console.WriteLine("You won, you caught the agent");
                Environment.Exit(0);
            }
        }

        
        

        public void Game()
        {


            int maxChoice = 10;

            while (maxChoice > 0)
            {
                Console.WriteLine("----------------- ");
                Console.WriteLine("Please enter your choice: ");
                Console.WriteLine(
                    $"1. choice {EnumTypeSensor.AudioSensor}\n" +
                    $"2. choice {EnumTypeSensor.ThermalSensor}\n" +
                    $"3. choice {EnumTypeSensor.PulseSensor}");

               
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
                if(maxChoice==7 || maxChoice ==4 || maxChoice == 1)
                {
                    if(Agent.typeRank == EnumTypeRank.SquadLeader || Agent.typeRank == EnumTypeRank.OrganizationLeader)
                    {
                        removeRandomFromSensors();
                    }
                    else if (Agent.typeRank == EnumTypeRank.SeniorCommandor)
                    {
                        for(int i = 0 ;i < 2; i++)
                        {
                            removeRandomFromSensors();
                        }
                    }


                }
                {

                }
                if (maxChoice == 0)
                {
                    Console.WriteLine("Game over");
                    Environment.Exit(0);
                }
            }
            
        }

        private void removeRandomFromSensors()
        {
            Random rand =new Random();
            
            int indexRemove = rand.Next(Agent.sensors.Count);
            Agent.sensors.Remove(Agent.sensors[indexRemove]);
        }
    }
}
