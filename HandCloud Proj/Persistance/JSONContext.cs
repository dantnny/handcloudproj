using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HandCloud_Proj.Data.Models;

namespace HandCloud_Proj.Persistance
{
    public class JSONContext : IJSONContext
    {
        private string _path;
        private IList<Car> _data;

        public JSONContext(IConfiguration config)
        {

            _path = config["JSONPATH"];

            if (File.Exists(_path))
            {
                using (StreamReader stream = new StreamReader(_path))
                {
                    _data = JsonConvert.DeserializeObject<IList<Car>>(stream.ReadToEnd());
                }
            }
            else
            {
                FileStream fs = File.Create(_path);
                fs.Dispose();

                List<Car> lstCar = new List<Car>();
                lstCar.Add(new Car
                {
                    Id = 1,
                    Model = "Toyota",
                    Description = "Compact vehicle",
                    Year = 2016,
                    Brand = "Yaris",
                    Kilometers = 21000,
                    Price = 230000m
                });

                lstCar.Add(new Car
                {
                    Id = 2,
                    Model = "Mitsubishi",
                    Description = "Compact vehicle + Hatchback",
                    Year = 2011,
                    Brand = "Mirage",
                    Kilometers = 15000,
                    Price = 210000m
                });

                lstCar.Add(new Car
                {
                    Id = 3,
                    Model = "Nissan",
                    Description = "Compact vehicle + Hatchback",
                    Year = 2019,
                    Brand = "March",
                    Kilometers = 12000,
                    Price = 250000m
                });

                string seed = JsonConvert.SerializeObject(lstCar);

                _data = JsonConvert.DeserializeObject<IList<Car>>(seed);
                SaveChanges();
            }


            
        }

        public void Create(Car c)
        {
            c.Id = _data.Max(car => car.Id) + 1;
            _data.Add(c);
        }

        public void Delete(int id)
        {
            Car car = _data.Where(c => c.Id == id).FirstOrDefault();
            if(car != null)
                _data.Remove(car);
        }

        public IList<Car> Get()
        {
            return _data.OrderBy(d => d.Id).ToList();
        }

        public Car GetById(int id)
        {
            return _data.Where(c => c.Id == id).FirstOrDefault();
        }

        public Car Update(Car new_car)
        {
            Car old_car = _data.Where(c => c.Id == new_car.Id).FirstOrDefault();
            
            if(old_car != null)
            {
                new_car.Id = old_car.Id;
                _data.Remove(old_car);
                _data.Add(new_car);

            }

            return null;
        }

        public void SaveChanges()
        {
            using (StreamWriter sw = new StreamWriter(_path, false))
            {
                sw.Write(JsonConvert.SerializeObject(_data));
            }
        
        }

    }
}
