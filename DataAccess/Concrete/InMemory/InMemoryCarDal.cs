using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Abstract.EntityFramework;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _iCarDal;
        public InMemoryCarDal()
        {
            _iCarDal = new List<Car>
            {
                new Car{CarId=1,ColorId=2,BrandId=3,DailyPrice=100,ModelYear=2016,Description="Audi A3"},
                new Car{CarId=2,ColorId=3,BrandId=2,DailyPrice=200,ModelYear=2016,Description="BMW i3"},
                new Car{CarId=3,ColorId=3,BrandId=1,DailyPrice=70,ModelYear=2016,Description="Fiat Linea"},
                new Car{CarId=4,ColorId=1,BrandId=4,DailyPrice=350,ModelYear=2016,Description="Wolkswagen Passat"}
            };
        }

        public void Add(Car car)
        {
            _iCarDal.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _iCarDal.SingleOrDefault(c=>c.CarId==car.CarId);
            _iCarDal.Remove(carToDelete);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _iCarDal;
        }

        public List<Car> GetById(int carId)
        {
            return _iCarDal.Where(get=>get.CarId==carId).ToList();
            
        }

        public void Update(Car car)
        {
            Car carToUpdate = _iCarDal.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}