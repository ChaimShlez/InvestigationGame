using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Entity.IranianEntity
{
    internal class OrganizationLeader : IranianAgent, IRemove
    {
        public int countSensor = 2;
        private int Count;
        public OrganizationLeader() : base(EnumTypeRank.OrganizationLeader, 8)
        {
        }

        public override void Accept(IVisitorAgent visitor)
        {
            visitor.VisitOrganizationLeader(this);
        }


        public int count
        {
            get { return Count; }
            set { Count = value; }
        }

        public void Remove()
        {
            Random rand = new Random();

            int indexRemove = rand.Next(sensors.Count);
            sensors.Remove(sensors[indexRemove]);
        }
    }
}
