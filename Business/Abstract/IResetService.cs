using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IResetService
    {
        void Add(ResetPassword user);
        void Update(ResetPassword user);
        ResetPassword GetById(int userId);
        IDataResult<User> SendCode(string email);
        IDataResult<User> CheckCode(string email, string code);
    }
}
