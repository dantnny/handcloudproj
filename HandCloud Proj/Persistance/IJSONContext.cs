using HandCloud_Proj.Data.Models;
using System.Collections.Generic;

namespace HandCloud_Proj.Persistance
{
    public interface IJSONContext
    {
        void Create(Car c);
        void Delete(int id);
        IList<Car> Get();
        Car GetById(int id);
        void SaveChanges();
        Car Update(Car new_car);
    }
}