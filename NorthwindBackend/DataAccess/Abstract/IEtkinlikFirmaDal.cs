﻿using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEtkinlikFirmaDal : IEntityRepository<EtkinlikFirma>
    {
        List<EtkinlikFirma> GetEtkinlikFirma(Firma firma);
    }
}
