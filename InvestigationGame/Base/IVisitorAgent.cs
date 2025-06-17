using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entity.IranianEntity;

namespace InvestigationGame.Base
{
    internal interface IVisitorAgent
    {

        //void VisitFootSolidr(FootSolider footSolider);
        void VisitAgent(IranianAgent Agent);
        void VisitOrganizationLeader(OrganizationLeader organizationLeader);
        void VisitSeniorCommandor(SeniorCommandor seniorCommandor);

        void VisitSquadLeader(SquadLeader squadLeader);
    }
}

