using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Enum;

namespace InvestigationGame.Entity.IranianEntity
{
    internal class SeniorCommandor : IranianAgent , IRemove
    {
        public int countSensor = 2;
        private int Count;
        public SeniorCommandor() : base(EnumTypeRank.SeniorCommandor, 6)
        {
        }

        public override void Accept(IVisitorAgent visitor)
        {
            visitor.VisitSeniorCommandor(this);
        }

        public int count
        {
            get { return Count; }
            set { Count = value; }
        }

        public void Remove()
        {
            RemoveSensor.Remove(this);
        }
    }
}
