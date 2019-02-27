using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandCloud_Proj.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HandCloud_Proj.Data.Interfaces;
using HandCloud_Proj.Data.Models;
using Microsoft.AspNetCore.Cors;

namespace HandCloud_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository repository;

        public CarController(ICarRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet("ListCar")]
        public IList<Car> GetList()
        {
            return repository.Get();
        }

        // GET api/values
        [HttpGet("GetCar")]
        public Car GetCar(int id)
        {
            return repository.Get(id);
        }

        // GET api/values
        [HttpPost("CreateCar")]
        public void CreateCar([FromBody] Car c)
        {
            repository.Create(c);
            repository.Save();
        }

        // GET api/values
        [HttpGet("DeleteCar")]
        public void DeleteCar(int id)
        {
            repository.Delete(id);
            repository.Save();
        }

        // GET api/values
        [HttpPost("UpdateCar")]
        public void UpdateCar([FromBody] Car c)
        {
            repository.Update(c);
            repository.Save();
        }
        

    }
}