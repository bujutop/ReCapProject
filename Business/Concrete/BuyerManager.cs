using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BuyerManager : IBuyerService
    {
        IBuyerDal _buyerDal;

        public BuyerManager(IBuyerDal buyerDal)
        {
            _buyerDal = buyerDal;
        }

        [ValidationAspect(typeof(BuyerValidator))]
        public IResult Add(Buyer buyer)
        {
            _buyerDal.Add(buyer);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Buyer>> GetAll()
        {
            return new SuccessDataResult<List<Buyer>>(_buyerDal.GetAll(),Messages.GetAll);
        }

    }
}
