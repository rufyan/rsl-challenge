﻿using rsl_challenge.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rsl_challenge.Models
{
    public class Dividend
    {
        //Dividend
        public int Division { get; set; }
        public int BlocNumberOfWinners { get; set; }
        public decimal BlocDividend { get; set; }
        public string CompanyId { get; set; }
        public int CompanyNumberOfWinners { get; set; }
        public decimal CompanyDividend { get; set; }
        public int PoolTransferredTo { get; set; }
        //TODO: include PoolTransferType in class
        //public PoolTransferType
    }
}