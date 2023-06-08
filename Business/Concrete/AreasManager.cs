using Business.Abstract;
using Business.Constants;
using Business.Contants;
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
    public class AreasManager : IAreasService
    {
        private IAreasDal _areasDal;

        public AreasManager(IAreasDal areasDal)
        {
            _areasDal = areasDal;
        }

        public IResult Add(Areas area)
        {
            _areasDal.Add(area);
            return new SuccessResult(SuccessMessages.AreasAddedSuccess);
        }

        public IResult Delete(Areas area)
        {
            _areasDal.Delete(area);
            return new SuccessResult(SuccessMessages.AreasDeletedSuccess);
        }

        public IDataResult<Areas> GetById(int areaId)
        {
            return new SuccessDataResult<Areas>(_areasDal.Get(filter: p => p.Id == areaId));
        }

        public IDataResult<List<Areas>> GetList()
        {
            return new SuccessDataResult<List<Areas>>(_areasDal.GetList().ToList());
        }

        public IDataResult<List<Areas>> GetListCategory(int categoryId)
        {
            return new SuccessDataResult<List<Areas>>(_areasDal.GetList(filter: p => p.CategoryId == categoryId).ToList());
        }

        public IResult Update(Areas area)
        {
            _areasDal.Update(area);
            return new SuccessResult(SuccessMessages.AreasUpdateSuccess);
        }
    }
}
