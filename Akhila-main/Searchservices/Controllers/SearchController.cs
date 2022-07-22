using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Searchservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchservices.Controllers
{
    [Route("api/1.0/flight/Search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        FlightDBContext dbAirline;
       
        public SearchController(FlightDBContext  _dbAirline)
        {
            dbAirline = _dbAirline;
        }

        // [HttpGet]
        // public IEnumerable<ScheduledTb> search(string fromplace,string toplace)
        //{
        //    var data = dbAirline.ScheduledTbs;
        //    List<ScheduledTb> list = new List<ScheduledTb>();
        //    foreach(var db in data)
        //    {
        //        if(db.Fromplace== fromplace&&db.Toplace==toplace)
        //        {
        //            list.Add(db);
        //        }
        //    }
        //    return list;
        //}
        [HttpGet]
        [Route("GetData")]
        public IEnumerable<ScheduledTb> Search(string fromplace)
        {
            var data = dbAirline.ScheduledTbs;
            List<ScheduledTb> list = new List<ScheduledTb>();
            foreach (var dr in data)
            {
                if (dr.Fromplace == fromplace)
                {
                    list.Add(dr);
                }
            }
            return list;
        }
        [HttpGet]
        public IActionResult search(string pnr)
        {
            try
            {
                var data = dbAirline.BookingTbs;
                List<BookingTb> list = new List<BookingTb>();
                foreach (var db in data)
                {
                    if (db.Pnr == pnr)
                    {
                        list.Add(db);
                    }
                }
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
