using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Dal;
using InvestigationGame.Enum;
using InvestigationGame.Factory;

namespace InvestigationGame.Manager
{
    internal class ManagerAgent
    {

        private LogicManager logicManager;
        private HandleVisitor handleVisitor;
        private DalAgent dalAgent;
        private DalSensor dalSensor;

        public ManagerAgent(LogicManager logicManager, HandleVisitor handleVisitor, DalAgent dalAgent, DalSensor dalSensor)
        {
            this.logicManager = logicManager;
            this.handleVisitor = handleVisitor;
            this.dalAgent = dalAgent;
            this.dalSensor = dalSensor;
        }

        private void AttachAgent(EnumTypeRank rank)
        {
            IranianAgent agent = AgentFactory.CreateAgent(rank);
           long idAgent = dalAgent.CreateAgent(agent);
             
            
            InvestigationManager manager = new InvestigationManager(agent, logicManager , handleVisitor ,idAgent , dalSensor);
            manager.Game();
        }

        public void createAgent()
        {

            Console.WriteLine("Please enter your agent: ");
            Console.WriteLine("");
            Console.WriteLine(
                $"1. choice {EnumTypeRank.FootSolider}\n" +
                $"2. choice {EnumTypeRank.SquadLeader}\n" +
                $"3. choice {EnumTypeRank.SeniorCommandor}\n" +
                $"4. choice {EnumTypeRank.OrganizationLeader}");

           
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AttachAgent(EnumTypeRank.FootSolider);
                        break;
                    case 2:
                        AttachAgent(EnumTypeRank.SquadLeader);
                        break;
                    case 3:
                        AttachAgent(EnumTypeRank.SeniorCommandor);
                        break;
                    case 4:
                        AttachAgent(EnumTypeRank.OrganizationLeader);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}

