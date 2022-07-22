using Airlineservices.Models;
using Airlineservices.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airlineservices.Controllers
{
    [Route("api/1.0/flight/airline/Inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        FlightDBContext dbScheduled;
        public InventoryController(FlightDBContext _dbScheduled)
        {
            dbScheduled = _dbScheduled;
        }
        [HttpGet]
        public IEnumerable<ScheduledTb> getData()
        {
            return dbScheduled.ScheduledTbs.ToList();
        }
        [Route("register")]
        [HttpPost]
        public IActionResult Register(FlightViewmodel flightviewmodel)
        {
            ScheduledTb scheduled = new ScheduledTb();
            scheduled.FlightIdnum = flightviewmodel.FlightIdnum;
            scheduled.Airlinename = flightviewmodel.Airlinename;
            scheduled.Fromplace = flightviewmodel.Fromplace;
            scheduled.Toplace = flightviewmodel.Toplace;
            scheduled.Startdatetime = flightviewmodel.Startdatetime;
            scheduled.Enddatetime = flightviewmodel.Enddatetime;
            scheduled.Scheduledays = flightviewmodel.Scheduledays;
            scheduled.BusinessClsseats = flightviewmodel.BusinessClsseats;
            scheduled.Nonbusinessclsseats = flightviewmodel.Nonbusinessclsseats;
            scheduled.Ticketprice = flightviewmodel.Ticketprice;
            scheduled.Noofrows = flightviewmodel.Noofrows;
            scheduled.Meal = flightviewmodel.Meal;

            dbScheduled.ScheduledTbs.Add(scheduled);
            dbScheduled.SaveChanges();

            return Ok("Record Added Successfully");
        }

        [HttpPut]

        public IActionResult putData(FlightViewmodel flightviewmodel)
        {
            if (dbScheduled.ScheduledTbs.Any(x => x.AirlineId == flightviewmodel.AirlineId))
            {
                var data = dbScheduled.AirlineTbs.Where(x => x.AirlineId == flightviewmodel.AirlineId).FirstOrDefault();
                ScheduledTb scheduled = new ScheduledTb();
                scheduled.FlightIdnum = flightviewmodel.FlightIdnum;
                scheduled.Airlinename = flightviewmodel.Airlinename;
                scheduled.Fromplace = flightviewmodel.Fromplace;
                scheduled.Toplace = flightviewmodel.Toplace;
                scheduled.Startdatetime = flightviewmodel.Startdatetime;
                scheduled.Enddatetime = flightviewmodel.Enddatetime;
                scheduled.Scheduledays = flightviewmodel.Scheduledays;
                scheduled.BusinessClsseats = flightviewmodel.BusinessClsseats;
                scheduled.Nonbusinessclsseats = flightviewmodel.Nonbusinessclsseats;
                scheduled.Ticketprice = flightviewmodel.Ticketprice;
                scheduled.Noofrows = flightviewmodel.Noofrows;
                scheduled.Meal = flightviewmodel.Meal;

                dbScheduled.ScheduledTbs.Add(scheduled);
                dbScheduled.SaveChanges();

                return Ok("Record Added Successfully");
            }

            return BadRequest("Record not found.");
        }

        [HttpDelete]

        public IActionResult deleteData(int Id)
        {
            if (dbScheduled.ScheduledTbs.Any(x => x.FlightIdnum == Id))
            {
                var data = dbScheduled.ScheduledTbs.Where(x => x.FlightIdnum == Id).FirstOrDefault();
                dbScheduled.ScheduledTbs.Remove(data);
                dbScheduled.SaveChanges();
                return Ok("Record have been successfully deleted.");
            }

            return BadRequest("Record not found.");
        }
    }
}
