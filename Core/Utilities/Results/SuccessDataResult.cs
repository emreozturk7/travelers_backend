using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, succes: true)
        {
        }
        public SuccessDataResult(T data, string message) : base(data, succes: true, message)
        {
        }

        public SuccessDataResult(string message) : base(default, succes: true, message)
        {
        }

        public SuccessDataResult() : base(default, succes: true)
        {
        }
    }
}
