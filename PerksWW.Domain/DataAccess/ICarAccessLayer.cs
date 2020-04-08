using PerksWW.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerksWW.Domain.DataAccess
{
    public interface ICarAccessLayer
    {
        Task<IEnumerable<Car>> GetAllCars();

        Task AddCar(Car car);

        Task UpdateCar(Car car);

        Task<Car> GetCar(int? carId);

        Task DeleteCar(int? carId);
    }
}
