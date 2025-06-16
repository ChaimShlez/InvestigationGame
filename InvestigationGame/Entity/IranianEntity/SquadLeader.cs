using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Entity.IranianEntity
{
    internal class SquadLeader : IranianAgent
    {
        public SquadLeader() : base(EnumTypeRank.SquadLeader, 4)
        {
        }
    }
}
