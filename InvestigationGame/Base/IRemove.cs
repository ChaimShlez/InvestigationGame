﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Base
{
    internal interface IRemove
    {
        int count { get; }
        void Remove();
    }
}
