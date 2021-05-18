using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUsersService
    {
        IUsersDal _usersDal;
        public UserManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public IResult Add(Users users)
        {
            _usersDal.Add(users);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(Users users)
        {
            _usersDal.Delete(users);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<Users>> GetAll()
        {
            return new DataResult<List<Users>>(_usersDal.GetAll(), true, "Kullanıcılar listelendi.");
        }

        public Users GetByMail(string email)
        {
            return _usersDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(Users user)
        {
            return _usersDal.GetClaims(user);
        }

        public IResult Update(Users users)
        {
            _usersDal.Update(users);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
