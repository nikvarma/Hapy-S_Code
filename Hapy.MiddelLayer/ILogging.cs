﻿using Hapy.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    public interface ILogging: IDbCommands<DB.Logging>
    {

    }
}