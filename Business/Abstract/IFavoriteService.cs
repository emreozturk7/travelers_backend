using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFavoriteService
    {
        IResult Add(Favorite favorite);
        IResult Update(Favorite favorite);
        IDataResult<Favorite> GetById(int userId);
    }
}
