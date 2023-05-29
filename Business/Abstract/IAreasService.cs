using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAreasService
    {
        IDataResult<Areas> GetById(int areaId);
        IDataResult<List<Areas>> GetList();
        IDataResult<List<Areas>> GetListCategory(int categoryId);
        IResult Add(Areas area);
        IResult Delete(Areas area);
        IResult Update(Areas area);
    }
}
