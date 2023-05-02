﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool succes) : base(succes: false)
        {
        }

        public ErrorResult(string message) : base(succes: false, message)
        {
        }
    }
}
