using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalsService
    {
        IResult Add(Rentals rentals);

        IResult Update(Rentals rentals);

        IResult Delete(Rentals rentals);

        IDataResult<List<Rentals>> GetAll();
    }
}
