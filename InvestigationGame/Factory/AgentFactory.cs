using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Entity.IranianEntity;
using InvestigationGame.Entity.SensorEntity;
using InvestigationGame.Enum;

namespace InvestigationGame.Factory
{
    internal class AgentFactory
    {

        public static IranianAgent CreateAgent(EnumTypeRank rank)
        {
            switch (rank)
            {
                case EnumTypeRank.FootSolider:
                    return new FootSolider();
                case EnumTypeRank.SquadLeader:
                    return new SquadLeader();
                case EnumTypeRank.SeniorCommandor:
                    return new SeniorCommandor();
                case EnumTypeRank.OrganizationLeader:
                    return new OrganizationLeader();

                default:
                    throw new ArgumentException("Unknown sensor type");
            }
        }
    }
}
