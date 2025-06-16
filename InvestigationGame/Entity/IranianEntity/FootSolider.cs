using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Entity.IranianEntity
{
    internal class FootSolider : IranianAgent
    {
        public FootSolider() : base(EnumTypeRank.FootSolider, 2)
        {
        }
    }
}
