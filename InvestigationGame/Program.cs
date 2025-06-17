using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Entity.IranianEntity;
using InvestigationGame.Entity.SensorEntity;
using InvestigationGame.Factory;
using InvestigationGame.Manager;

namespace InvestigationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IranianAgent agentFoot = new FootSolider();
            //Sensor sensorAudio = new AudioSensor();
            //Sensor sensorPulse = new PulseSensor();
            //Sensor sensorThermal = new ThermalSensor();
            //InvestigationManager maneger = new InvestigationManager(agentFoot);
            ManagerAgent m = new ManagerAgent();
            m.createAgent();


        }
    }
}
