using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;
using InvestigationGame.Factory;

namespace InvestigationGame.Manager
{
    internal class ManagerAgent
    {
        private void AttachAgent(EnumTypeRank rank)
        {
            IranianAgent agent = AgentFactory.CreateAgent(rank);

             
            LogicManager logicManager = new LogicManager();
            HandleVisitor handleVisitor = new HandleVisitor();
            InvestigationManager manager = new InvestigationManager(agent, logicManager , handleVisitor);
        }

        public void createAgent()
        {

            Console.Write("Please enter your agent: ");
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

