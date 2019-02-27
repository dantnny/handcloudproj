
using HandCloud_Proj.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandCloud_Proj.Data.Interfaces
{
    public interface ICarRepository
    {

        IList<Car> Get();
        Car Get(int carId);
        void Create(Car car);
        void Delete(int id);
        void Update(Car car);
        void Save();
    }
}
