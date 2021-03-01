using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
           IRentDal _rentalDal;
            public RentalManager(IRentDal rentalDal)
            {
                _rentalDal = rentalDal;
            }
            public IResult Add(RentAl rental)
            {
                if (rental.ReturnDate < DateTime.Today)
                {
                    return new ErrorResult(Messages.RentalInvalid);
                }
                _rentalDal.Add(rental);
                return new SuccessResult();
            }

            public IResult Delete(RentAl rental)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult();
            }

            public IDataResult<List<RentAl>> GetAll()
            {
                return new SuccessDataResult<List<RentAl>>(_rentalDal.GetAll());
            }

            public IDataResult<List<RentAl>> GetById(int id)
            {
                return new SuccessDataResult<List<RentAl>>(_rentalDal.GetAll(r => r.Id == id));
            }

            public IResult Update(RentAl rental)
            {
                _rentalDal.Update(rental);
                return new SuccessResult();
            }
        }
}
