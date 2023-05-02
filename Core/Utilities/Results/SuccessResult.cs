using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(bool succes, string message) : base(succes: true, message)
        {
        }

        public SuccessResult(bool succes) : base(succes: true)
        {
        }

        public SuccessResult(string message) : base(true, message)
        {
        }
    }
}
