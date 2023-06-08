using Business.Abstract;
using Business.Constants;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FavoriteManager : IFavoriteService
    {
        private IFavoriteDal _favoriteDal;
        private IUserDal _userDal;
        private IAreasDal _areasDal;

        public FavoriteManager(IFavoriteDal favoriteDal, IUserDal userDal, IAreasDal areasDal)
        {
            _favoriteDal = favoriteDal;
            _userDal = userDal;
            _areasDal = areasDal;
        }

        public IResult Add(Favorite favorite)
        {
            _favoriteDal.Add(favorite);
            return new SuccessResult(SuccessMessages.FavoriteAddedSuccess);
        }

        public IResult Update(Favorite favorite)
        {
            _favoriteDal.Update(favorite);
            return new SuccessResult(SuccessMessages.FavoriteUpdateSuccess);
        }

        public IDataResult<Favorite> GetById(int favoriteId)
        {
            return new SuccessDataResult<Favorite>(_favoriteDal.Get(filter: u => u.Id == favoriteId));
        }
    }
}
