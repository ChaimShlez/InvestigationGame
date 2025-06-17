using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Entity
{
    internal class ActivateResult
    {
        public string Info { get; }
        public bool? IsBroken { get; }

        public ActivateResult(string info, bool? isBroken = null)
        {
            Info = info;
            IsBroken = isBroken;
        }
    }
}
