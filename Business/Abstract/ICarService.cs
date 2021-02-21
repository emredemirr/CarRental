using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public interface ICarService
    {

        List<Car> GetAll();
        
        List<Car> GetCarsByBrandId(int brandId);
        
        List<Car> GetCarsByColorId(int colorId);

        void Add(Car car);
    }
}