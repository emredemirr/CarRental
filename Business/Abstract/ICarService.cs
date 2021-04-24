using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public interface ICarService
    {

        IResult Add(Car car);

        IResult Delete(Car car);

        IResult Update(Car car);

        IDataResult<List<Car>> GetAll();

        IDataResult<List<CarDetailsDto>> GetCarDetails();

        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        
        IDataResult<List<Car>> GetCarsByColorId(int colorId);

    }
}
