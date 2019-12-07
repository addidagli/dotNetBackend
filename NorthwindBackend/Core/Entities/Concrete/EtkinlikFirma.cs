using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class EtkinlikFirma:IEntity
    {
        public int Id { get; set; }
        public int EtkinlikId { get; set; }
        public int FirmaId { get; set; }
    }
}
