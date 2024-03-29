﻿using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IFirmaDal : IEntityRepository<Firma>
    {
        List<Etkinlik> GetEtkinlik(Firma firma);
    }
}
