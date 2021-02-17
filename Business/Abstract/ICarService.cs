using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public interface ICarService
    {
        List<Car> GetAll();
    }
}