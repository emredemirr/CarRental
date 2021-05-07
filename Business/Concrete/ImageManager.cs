using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImagesService
    {
        IImagesDal _imagesDal;

        public ImageManager(IImagesDal imagesDal)
        {
            _imagesDal = imagesDal;
        }
        [ValidationAspect(typeof(ImagesValidator))]
        public IResult Add(IFormFile file, Images carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return new ErrorDataResult<List<Images>>(result.Message);
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _imagesDal.Add(carImage);
            return new SuccessResult("Resimler Eklendi.");
        }

        public IResult Delete(Images carImage)
        {
            var image = _imagesDal.Get(c=>c.Id==carImage.Id);
            if (image==null)
            {
                return new ErrorResult("Resim Bulunamadı");
            }
            FileHelper.Delete(image.ImagePath);
            _imagesDal.Delete(carImage);
            return new SuccessResult("Seçili Resimler Silindi");
        }

        public IDataResult<Images> Get(int id)
        {
            return new SuccessDataResult<Images>(_imagesDal.Get(c=>c.Id==id));
        }

        public IDataResult<List<Images>> GetAll()
        {
            return new SuccessDataResult<List<Images>>(_imagesDal.GetAll());
        }

        public IDataResult<List<Images>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));
            if (result!=null)
            {
                return new ErrorDataResult<List<Images>>(result.Message);
            }
            return new SuccessDataResult<List<Images>>(CheckIfCarImageNull(id).Data);
        }

        public IResult Update(IFormFile file, Images carImage)
        {
            var isImage = _imagesDal.Get(c=>c.Id==carImage.Id);
            if (isImage==null)
            {
                return new ErrorResult("Resim Bulunamadı");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _imagesDal.Update(carImage);
            return new SuccessResult("Güncelleme başarılı.");
        }

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _imagesDal.GetAll(c=>c.CarId==carId).Count;
            if (carImageCount>=5)
            {
                return new ErrorResult("Resim sayısı 5'ten fazla olamaz.");
            }
            return new SuccessResult();
        }

        private IDataResult<List<Images>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _imagesDal.GetAll(c=>c.CarId==id).Any();
                if (!result)
                {
                    List<Images> carImage = new List<Images>();
                    carImage.Add(new Images { CarId=id,ImagePath=path,Date=DateTime.Now});
                    return new SuccessDataResult<List<Images>>(carImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Images>>(exception.Message);
            }
            return new SuccessDataResult<List<Images>>(_imagesDal.GetAll(c => c.CarId==id).ToList());
        }

        private IResult CarImageDelete(Images images)
        {
            try
            {
                FileHelper.Delete(images.ImagePath);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }
    }
}
