using Airlineservices.Models;
using Airlineservices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airlineservices.Controllers
{
    [Route("api/1.0/flight/airline")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        FlightDBContext dbAirline;
        public RegisterController(FlightDBContext _dbAirline)
            {
                dbAirline = _dbAirline;
            }

        [HttpGet]
        public IEnumerable<AirlineTb> getData()
        {
            return dbAirline.AirlineTbs.ToList();
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(Airlineviewmodel airLineViewModel)
        {
            AirlineTb airline = new AirlineTb();
            airline.AirlineId = airLineViewModel.AirlineId;
            airline.AirlineName = airLineViewModel.AirlineName;
            airline.AirlineLogo = airLineViewModel.AirlineLogo;
            airline.Address = airLineViewModel.Address;
            airline.ContactNum = airLineViewModel.ContactNum;
            dbAirline.AirlineTbs.Add(airline);
            dbAirline.SaveChanges();

            return Ok("Record Added Successfully");
        }

        [HttpPut]
       
        public IActionResult putData(Airlineviewmodel airLineViewModel)
        {
            if (dbAirline.AirlineTbs.Any(x => x.AirlineId == airLineViewModel.AirlineId))
            {
                var data = dbAirline.AirlineTbs.Where(x => x.AirlineId == airLineViewModel.AirlineId).FirstOrDefault();
                data.AirlineName = airLineViewModel.AirlineName;
                data.ContactNum = airLineViewModel.ContactNum;
                data.AirlineLogo = airLineViewModel.AirlineLogo;
                data.Address = airLineViewModel.Address;
                dbAirline.AirlineTbs.Update(data);
                dbAirline.SaveChanges();
                return Ok("Record have been successfully updated.");
            }

            return BadRequest("Record not found.");
        }

        [HttpDelete]
        [Route("deleteData")]
       
        public IActionResult deleteData(int Id)
        {
            if (dbAirline.AirlineTbs.Any(x => x.AirlineId == Id))
            {
                var data = dbAirline.AirlineTbs.Where(x => x.AirlineId == Id).FirstOrDefault();
                dbAirline.AirlineTbs.Remove(data);
                dbAirline.SaveChanges();
                return Ok("Record have been successfully deleted.");
            }

            return BadRequest("Record not found.");
        }
    }
}
