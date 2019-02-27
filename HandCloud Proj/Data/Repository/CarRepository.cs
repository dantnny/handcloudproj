using HandCloud_Proj.Data.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HandCloud_Proj.Persistance;
using HandCloud_Proj.Data.Models;

namespace HandCloud_Proj.Data.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly string _path;
        private readonly List<Car> _data;
        private readonly IJSONContext _context;

        public CarRepository(IJSONContext context)
        {
            this._context = context;
        }

        public IList<Car> Get()
        {
            return _context.Get();
        }

        public Car Get(int carId)
        {
            return _context.GetById(carId);
        }

        public void Create(Car car)
        {
            _context.Create(car);
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public void Update(Car car)
        {
            _context.Update(car);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
