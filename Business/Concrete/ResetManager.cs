using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ResetManager :IResetService
    {
        IResetDal _resetDal;

        public ResetManager(IResetDal resetDal)
        {
            _resetDal = resetDal;
        }

        public void Add(ResetPassword reset)
        {
            _resetDal.Add(reset);
        }
        public void Update(ResetPassword reset)
        {
            _resetDal.Update(reset);
        }
        public ResetPassword GetById(int userId)
        {
            return _resetDal.Get(filter: u => u.UserId == userId);
        }
    }
}
