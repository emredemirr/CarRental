using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUsersService
    {
        IResult Add(Users users);

        IResult Update(Users users);

        IResult Delete(Users users);

        IDataResult<List<Users>> GetAll();
        
        List<OperationClaim> GetClaims(Users user);
        
        Users GetByMail(string email);
    }
}
