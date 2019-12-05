using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Linq;
using Business.Constants;

namespace Business.Concrete
{
    public class OrganizasyonManager:IOrganizasyonService
    {
        IOrganizasyonDal _organizasyonDal;

        public OrganizasyonManager(IOrganizasyonDal organizasyonDal)
        {
            _organizasyonDal = organizasyonDal;
        }

        public IResult AddOrganizasyon(Organizasyon organizasyon)
        {
            _organizasyonDal.Add(organizasyon);
            return new SuccessResult(Messages.OrganizasyonAdded);
        }

        public IResult UpdateOrganizasyon(Organizasyon organizasyon)
        {
            _organizasyonDal.Update(organizasyon);
            return new SuccessResult(Messages.OrganizasyonUpdated);
        }
        public IResult DeleteOrganizasyon(Organizasyon organizasyon)
        {
            _organizasyonDal.Delete(organizasyon);
            return new SuccessResult(Messages.OrganizasyonDeleted);
        }

        public IDataResult<List<Organizasyon>> GetAllOrganizasyon()
        {
            return new SuccessDataResult<List<Organizasyon>>(_organizasyonDal.GetList().ToList());
        }

        public IDataResult<Organizasyon> GetOrganizasyonById(int Id)
        {
            return new SuccessDataResult<Organizasyon>(_organizasyonDal.Get(p => p.Id == Id));
        }

        
    }
}
