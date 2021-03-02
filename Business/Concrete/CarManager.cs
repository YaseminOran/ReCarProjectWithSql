using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result= BusinessRules.Run(CheckIfCarNameExist(car.CarName), 
                CheckIfCarCountOfCategoryCorrect(car.Id));
            if (result!=null)
            {
                return result;
            }
            //ValidationTool.Validate(new CarValidator(), car);
             _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDelete);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == id), Messages.CarGetById);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }
        [ValidationAspect (typeof(CarValidator))]
        public IResult Update(Car car)
        {
            
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }
        private IResult CheckIfCarCountOfCategoryCorrect(int Id)
        {
            var result = _carDal.GetAll(p => p.Id == Id).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfCategoryError);
            }

            return new SuccessResult();
        }
        private IResult CheckIfCarNameExist(string carName)
        {
            var result = _carDal.GetAll(p =>p.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }

  


}
