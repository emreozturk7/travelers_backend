using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDateResult<T> : DataResult<T>
    {
        public ErrorDateResult(T data) : base(data, false)
        {
        }

        public ErrorDateResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDateResult(string message) : base(default, succes: true, message)
        {
        }

        public ErrorDateResult() : base(default, succes: true)
        {
        }


    }
}
