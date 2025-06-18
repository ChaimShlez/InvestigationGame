using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Entity.IranianEntity
{
    internal class SquadLeader : IranianAgent , IRemove
    {
        public int countSensor = 2;
        private int Count;
        public SquadLeader() : base(EnumTypeRank.SquadLeader, 4)
        {
        }


        public override void Accept(IVisitorAgent visitor)
        {
            visitor.VisitSquadLeader(this);
        }
        public int  count
        {
            get { return Count; }
            set{  Count = value; }
        }

        public void Remove()
        {
            RemoveSensor.Remove(this);
        }

    }
}
