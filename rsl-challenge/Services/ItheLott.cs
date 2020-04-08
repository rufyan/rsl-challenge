﻿using rsl_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rsl_challenge.Services
{
    public interface ItheLott
    {
        DrawsList GetOpenDrawList();
        LotteryResultsList GetLotteryResultsList();

    }

}
