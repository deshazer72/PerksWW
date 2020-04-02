using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerksWW.Domain.DataAccess;
using PerksWW.Domain.Models;

namespace PerksWW.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarAccessLayer _carAccess;

        public CarsController(ICarAccessLayer carAccess)
        {
            _carAccess = carAccess;
        }

        // GET: Cars
        public IActionResult Index()
        {
            return View(_carAccess.GetAllCars());
        }

        // GET: Cars/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carAccess.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CarId,Make,Model,IsDeleted,Type")] Car car)
        {
            if (ModelState.IsValid)
            {
                _carAccess.AddCar(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carAccess.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CarId,Make,Model,IsDeleted,Type")] Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _carAccess.UpdateCar(car);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carAccess.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _carAccess.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            Car car = _carAccess.GetCar(id);
            if (car != null)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        [HttpGet]
        public JsonResult CarDetailsJson()
        {
            var cars = _carAccess.GetAllCars();
            return Json(cars);
        }
    }
}
