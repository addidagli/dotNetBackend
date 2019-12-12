using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class FirmaCalisaniManager : IFirmaCalisaniService
    {
        IFirmaCalisaniDal _firmaCalisaniDal;

        public FirmaCalisaniManager(IFirmaCalisaniDal firmaCalisaniDal)
        {
            _firmaCalisaniDal = firmaCalisaniDal;
        }
        public IResult AddFirmaCalisani(FirmaCalisani firmaCalisani)
        {
            _firmaCalisaniDal.Add(firmaCalisani);
            return new SuccessResult(Messages.UserAdded);
        }


        /*public IDataResult<List<FirmaCalisani>> GetUserByFirmaId(int firmaId)
        {
            return new SuccessDataResult<List<FirmaCalisani>>(_firmaCalisaniDal.GetListFilter(p => p.FirmaId == firmaId).ToList());
        }*/

        public IDataResult<List<int>> GetUserIdsByFirmaId(int firmaId)
        {
            return new SuccessDataResult <List<int>>(_firmaCalisaniDal.GetListFilter(a => a.FirmaId == firmaId).Select(b => b.KullaniciId).ToList());
        }

        /*public List<FirmaCalisani> GetFirmaCalisani(Firma firma)
        {
            
        }*/


        /*public IDataResult<List<FirmaCalisani>> GetFirmaCalisani(int firmaId)
        {
            return new SuccessDataResult<List<FirmaCalisani>> (_firmaCalisaniDal.GetFirmaCalisani().Select(p => p.FirmaId == firmaId).ToList());
            
        }*/
    }
}
