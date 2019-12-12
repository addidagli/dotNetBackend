using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IKullaniciEtkinlikService
    {
        //IResult AddFirmaCalisani(KullaniciEtkinlik kullaniciEtkinlik);

        IDataResult<List<int>> GetUserIdsByEtkinlikId(int etkinlikId);
    }
}
