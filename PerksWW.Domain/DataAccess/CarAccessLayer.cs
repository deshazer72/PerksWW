using PerksWW.Domain.EFContext;
using PerksWW.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PerksWW.Domain.DataAccess
{
    public class CarAccessLayer : ICarAccessLayer
    {
        private CarContext _context;

        public CarAccessLayer(CarContext context)
        {
            _context = context;
        }
        public void AddCar(Car car)
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
        }

        public void DeleteCar(int carId)
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
        }

        public IEnumerable<Car> GetAllCars()
        {
            try
            {
                return _context.Cars.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Car GetCar(int? carId)
        {
            try
            {
                Car car = _context.Cars.Find(carId);
                return car;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateCar(Car car)
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
        }
    }
}
