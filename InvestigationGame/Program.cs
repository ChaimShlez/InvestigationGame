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
            
            ManagerAgent m = new ManagerAgent();
            m.createAgent();


        }
    }
}
