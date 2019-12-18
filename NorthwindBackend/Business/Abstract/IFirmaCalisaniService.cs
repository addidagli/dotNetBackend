using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFirmaCalisaniService
    {
        
        IResult AddFirmaCalisani(FirmaCalisani firmaCalisani);

        IDataResult<List<int>> GetUserIdsByFirmaId(int firmaId);
        //IDataResult<List<int>> GetFirmaIdsByUserId(int userId);

    }
}
