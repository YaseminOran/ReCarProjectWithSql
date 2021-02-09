
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
       

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("silindi.");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(c => c.Id == id);
        }

        public void Update(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Update(brand);
                Console.WriteLine("Güncellendi.");
            }
            else
            {
                Console.WriteLine($"marka isminin uzunluğunu 1 karakterden fazla giriniz.  marka ismi : {brand.BrandName}");
            }
        }
    }
}
