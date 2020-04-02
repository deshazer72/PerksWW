using PerksWW.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerksWW.Domain.DataAccess
{
    public interface ICarAccessLayer
    {
        IEnumerable<Car> GetAllCars();

        void AddCar(Car car);

        void UpdateCar(Car car);

        Car GetCar(int? carId);

        void DeleteCar(int carId);
    }
}
