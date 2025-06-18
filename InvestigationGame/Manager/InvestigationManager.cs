using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Dal;
using InvestigationGame.Entity;
using InvestigationGame.Entity.IranianEntity;
using InvestigationGame.Entity.SensorEntity;
using InvestigationGame.Enum;
using InvestigationGame.Factory;

namespace InvestigationGame.Manager
{
    internal class InvestigationManager
    {

        private IranianAgent Agent;
        private LogicManager logicManager;
        private HandleVisitor handleVisitor;
        private long IDAgent;
        private DalSensor dalSensor;
        public InvestigationManager(IranianAgent agent, LogicManager _logicManager, HandleVisitor _handleVisitor, long _IDAgent, DalSensor _dalSensor)
        {
            Agent = agent;
            logicManager = _logicManager;
            handleVisitor = _handleVisitor;
            IDAgent = _IDAgent;
            dalSensor = _dalSensor;
        }

        public void AttachSensor(EnumTypeSensor sensorType)
        {
            Sensor sensor = SensorFactory.CreateSensor(sensorType);
            Agent.AttachSensor(sensor);
            dalSensor.CreateAgentSensor(sensor, IDAgent);

            Agent.Accept(handleVisitor);
            AllActivates();
            
        }

        private void AllActivates()
        {
           foreach(var sensor in Agent.sensors.ToList())
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
            
            int match = logicManager.CheckingMatches(dalSensor , IDAgent);

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
                Console.WriteLine("Please enter your type sensor: ");
                Console.WriteLine(
                    $"1. choice {EnumTypeSensor.AudioSensor}\n" +
                    $"2. choice {EnumTypeSensor.ThermalSensor}\n" +
                    $"3. choice {EnumTypeSensor.PulseSensor}\n"+
                    $"4. choice {EnumTypeSensor.MotionSensor}\n" +
                    $"5. choice {EnumTypeSensor.MagneticSensor}\n" +
                    $"6. choice {EnumTypeSensor.SignalSensor}\n" +
                    $"7. choice {EnumTypeSensor.LightSensor}");

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
                        case 4:
                            AttachSensor(EnumTypeSensor.MotionSensor);
                            break;
                        case 5:
                            AttachSensor(EnumTypeSensor.MagneticSensor);
                            break;
                        case 6:
                            AttachSensor(EnumTypeSensor.SignalSensor);
                            break;
                        case 7:
                            AttachSensor(EnumTypeSensor.LightSensor);
                        
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
