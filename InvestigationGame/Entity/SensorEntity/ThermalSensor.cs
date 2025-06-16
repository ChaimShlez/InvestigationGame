using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;

namespace InvestigationGame.Entity.SensorEntity
{
    internal class ThermalSensor : AudioSensor

    {
        public ThermalSensor(string name) : base(name)
        {
        }

        public override bool Activate(string name)
        {
            return base.Activate(name);
        }
    }
}
