using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Concrete.InMemory
{
    public interface ICarDal
    {

        List<Car> GetById(int carId);

        List<Car> GetAll();

        void Add(Car car);

        void Update(Car car);

        void Delete(Car car);
    }
}