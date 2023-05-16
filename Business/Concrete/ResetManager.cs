using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
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
    }
}
