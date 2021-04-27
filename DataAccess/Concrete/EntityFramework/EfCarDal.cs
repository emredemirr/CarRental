using Core.DataAccess.EntityFramework.EfEntityRepositoryBase;
using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarRentalContext context= new CarRentalContext())
            {
                var result = from car in context.Car
                             join color in context.Color on car.ColorId equals color.ColorId
                             join brand in context.Brand on car.BrandId equals brand.BrandId
                             select new CarDetailsDto
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 ColorName = color.ColorName,
                                 BrandName = brand.BrandName,
                                 DailyPrice =car.DailyPrice
                             };
                return result.ToList();
                             
            }
        }

        public CarDetailsDto GetCarDetail(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Car
                             join brand in context.Brand
                             on car.BrandId equals brand.BrandId
                             join color in context.Color
                             on car.ColorId equals color.ColorId where car.CarId == id
                             select new CarDetailsDto
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice
                             };

                return result.FirstOrDefault();
            }
        }
    }
}
