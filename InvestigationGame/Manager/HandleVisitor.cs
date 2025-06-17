using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Entity.IranianEntity;
using InvestigationGame.Enum;

namespace InvestigationGame.Manager
{
    internal class HandleVisitor : IVisitorAgent
    {
        public void VisitAgent(IranianAgent Agent) { }
        

        //public void VisitFootSolidr(FootSolider footSolider)
        //{
        //    throw new NotImplementedException();
        //}

        public void VisitOrganizationLeader(OrganizationLeader organizationLeader)
        {
            organizationLeader.count++;

            if (organizationLeader.count % 3 == 0)
            {
                if (organizationLeader.sensors[organizationLeader.sensors.Count - 1].tpye == EnumTypeSensor.MagneticSensor && organizationLeader.countSensor > 0)
                {
                    organizationLeader.countSensor--;
                }
                else
                {
                    organizationLeader.Remove();
                }
            }

        }

        public void VisitSeniorCommandor(SeniorCommandor seniorCommandor)
        {
            seniorCommandor.count++;

            if (seniorCommandor.count % 3 == 0)
            {
                if (seniorCommandor.sensors[seniorCommandor.sensors.Count-1].tpye == EnumTypeSensor.MagneticSensor && seniorCommandor.countSensor > 0)
                {
                    seniorCommandor.countSensor--;
                }
                else
                {
                    for(int i = 0; i < 2; i++)
                    {
                        seniorCommandor.Remove();
                    }
                    
                }
            }
        }


        public void VisitSquadLeader(SquadLeader squadLeader)
        {
            squadLeader.count++;

            if (squadLeader.count % 3 == 0)
            {
                if (squadLeader.sensors[squadLeader.sensors.Count - 1].tpye == EnumTypeSensor.MagneticSensor && squadLeader.countSensor > 0)
                {
                    squadLeader.countSensor--;
                }
                else
                {
                    squadLeader.Remove();
                }
            }
        }
    }
}
