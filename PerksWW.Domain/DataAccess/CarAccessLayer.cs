using PerksWW.Domain.EFContext;
using PerksWW.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PerksWW.Domain.DataAccess
{
    public class CarAccessLayer : ICarAccessLayer
    {
        private CarContext _context;

        public CarAccessLayer(CarContext context)
        {
            _context = context;
        }

        Task ICarAccessLayer.DeleteCar(int? carId)
        {
            return Task.Run(() =>
            {
                try
                {
                    Car car = _context.Cars.Find(carId);
                    car.IsDeleted = true;
                    _context.Entry(car).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }


        Task ICarAccessLayer.AddCar(Car car)
        {
            return Task.Run(() =>
            {
                try
                {
                    _context.Cars.Add(car);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        Task<Car> ICarAccessLayer.GetCar(int? carId)
        {
            return Task.Run(() =>
            {
                var car = _context.Cars.Find(carId);
                return car;
            });
        }

        Task<IEnumerable<Car>> ICarAccessLayer.GetAllCars()
        {
            return Task.Run(() =>
            {
                try
                {
                    return _context.Cars.Where(x => x.IsDeleted == false).AsEnumerable();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            });
        }

        Task ICarAccessLayer.UpdateCar(Car car)
        {
            return Task.Run(() =>
            {
                try
                {
                    _context.Entry(car).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }
    }
}
