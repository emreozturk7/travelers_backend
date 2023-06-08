using Business.Abstract;
using Business.Constants;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(Images image)
        {
            byte[] imageData = null;

            using (var memoryStream = new MemoryStream())
            {
                image.Url.CopyTo(memoryStream);
                imageData = memoryStream.ToArray();
            }

            var newImage = new ImageEntity
            {
                AreasId = image.AreasId,
                Url = imageData
            };

            _imageDal.Add(newImage);

            return new SuccessResult(SuccessMessages.ImageAddedSuccess);
        }
    }
}
