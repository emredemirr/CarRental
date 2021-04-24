using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalsService
    {
        IRentalsDal _rentalsDal;
        public RentalManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        public IResult Add(Rentals rentals)
        {
            if (rentals.ReturnDate<=rentals.RentDate && rentals.ReturnDate == null)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else
            {
                _rentalsDal.Add(rentals);
                return new SuccessResult(Messages.CustomerAdded);
            }
        }

        public IResult Delete(Rentals rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new DataResult<List<Rentals>>(_rentalsDal.GetAll(), true, "Kiralananlar listelendi.");
        }

        public IResult Update(Rentals rentals)
        {
            _rentalsDal.Update(rentals);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
