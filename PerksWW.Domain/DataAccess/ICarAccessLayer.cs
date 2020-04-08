using PerksWW.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerksWW.Domain.DataAccess
{
    public interface ICarAccessLayer
    {
        IEnumerable<Car> GetAllCars();

        Task AddCar(Car car);

        void UpdateCar(Car car);

        Task<Car> GetCar(int? carId);

        void DeleteCar(int? carId);
    }
}
