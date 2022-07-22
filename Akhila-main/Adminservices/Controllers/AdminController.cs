using Adminservices.Models;
using Adminservices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        FlightDBContext dbAirline;

        public AdminController(FlightDBContext _dbAirline)
        {
            dbAirline = _dbAirline;
        }
        [HttpGet]
         public string GetTest()
        {
            return "Hi from Adminservices";
        }

        [Route("getData")]
        [HttpGet]
       //[Authorize]
        public IEnumerable<AdminTb> getData()
        {
            return dbAirline.AdminTbs.ToList() ;
        }




        //[HttpPost("postData")]
        //[Authorize]
       
        //public IActionResult postData([FromBody]AirLineViewModel airLineViewModel)
        //{
        //    AirlineTb airline = new AirlineTb();
        //    //airline.AirlineId = airLineViewModel.AirlineId;
        //    airline.AirlineName = airLineViewModel.AirlineName;
        //    airline.AirlineLogo = airLineViewModel.AirlineLogo;
        //    airline.Address = airLineViewModel.Address;
        //    airline.ContactNum = airLineViewModel.ContactNum;
        //    dbAirline.AirlineTbs.Add(airline);
        //    dbAirline.SaveChanges();

        //    return Ok("Record Added Successfully");
        //}

        //[HttpPut]
        
        //public IActionResult putData(AirLineViewModel airLineViewModel)
        //{
        //    if (dbAirline.AirlineTbs.Any(x => x.AirlineId == airLineViewModel.AirlineId))
        //    {
        //        var data = dbAirline.AirlineTbs.Where(x => x.AirlineId == airLineViewModel.AirlineId).FirstOrDefault();
        //        data.AirlineName = airLineViewModel.AirlineName;
        //        data.ContactNum = airLineViewModel.ContactNum;
        //        data.AirlineLogo = airLineViewModel.AirlineLogo;
        //        data.Address = airLineViewModel.Address;
        //        dbAirline.AirlineTbs.Update(data);
        //        dbAirline.SaveChanges();
        //        return Ok("Record have been successfully updated.");
        //    }

        //    return BadRequest("Record not found.");
        //}

        //[HttpDelete]
       
        //public IActionResult deleteData(int Id)
        //{
        //    if (dbAirline.AirlineTbs.Any(x => x.AirlineId == Id))
        //    {
        //        var data = dbAirline.AirlineTbs.Where(x => x.AirlineId == Id).FirstOrDefault();
        //        dbAirline.AirlineTbs.Remove(data);
        //        dbAirline.SaveChanges();
        //        return Ok("Record have been successfully deleted.");
        //    }

        //    return BadRequest("Record not found.");
        //}
    }
}
