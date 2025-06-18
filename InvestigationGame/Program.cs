using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Dal;
using InvestigationGame.Entity.IranianEntity;
using InvestigationGame.Entity.SensorEntity;
using InvestigationGame.Factory;
using InvestigationGame.Manager;
using malshinonProject.Dal;

namespace InvestigationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionWrapper connection = ConnectionWrapper.getInstance();
            DalAgent dalAgent = new DalAgent(connection);
            DalSensor dalSensor = new DalSensor(connection);

            LogicManager logicManager = new LogicManager();
            HandleVisitor handleVisitor = new HandleVisitor();
            ManagerAgent m = new ManagerAgent(logicManager, handleVisitor , dalAgent ,dalSensor);
            m.createAgent();


        }
    }
}
