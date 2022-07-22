using Bookingservices.Models;
using Bookingservices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookingservices.Controllers
{
    [Route("api/1.0/flight/booking")]
    [ApiController]
    public class bookingController : ControllerBase
    {
        
        FlightDBContext dbAirline;
        public bookingController(FlightDBContext _dbAirline)
        {
            dbAirline = _dbAirline;
        }
        [HttpGet]
        [Route("getBookingData")]
        //[Authorize]
        public List<BookingTb>getBookingData()
        {
            return dbAirline.BookingTbs.ToList();
        }
        [HttpPost("BookingTicket")]
        public IActionResult BookingTicket([FromBody] BookingViewModel bookingviewmodel)
        {
            Random random = new Random();
            int pnr = random.Next();
            BookingTb bookingTb = new BookingTb();
            bookingTb.BookingId = bookingviewmodel.BookingId;
            bookingTb.AirlineId = bookingviewmodel.AirlineId;
            bookingTb.Airlinename = bookingviewmodel.Airlinename;
            bookingTb.Username = bookingviewmodel.Username;
            bookingTb.Gender = bookingviewmodel.Gender;
            bookingTb.Seatnum = bookingviewmodel.Seatnum;
            bookingTb.Address = bookingviewmodel.Address;
            bookingTb.Contact = bookingviewmodel.Contact;
            bookingTb.Email = bookingviewmodel.Email;
            bookingTb.Pnr = pnr.ToString();
            dbAirline.BookingTbs.Add(bookingTb);
            dbAirline.SaveChanges();
            return Ok("booking successfully");
        }
        [HttpGet]

        public IActionResult history(string emailId)
        {
            try
            {
                var data = dbAirline.BookingTbs;
                List<BookingTb> list = new List<BookingTb>();
                foreach(var db in data)
                {
                    if (db.Email == emailId)
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
        
        [Route("Cancel")]
        [HttpDelete]
        public IActionResult Cancel(int Id)
        {
            if (dbAirline.BookingTbs.Any(x => x.BookingId == Id))
            {
                var data = dbAirline.BookingTbs.Where(x => x.BookingId == Id).FirstOrDefault();
                dbAirline.BookingTbs.Remove(data);
                dbAirline.SaveChanges();
                return Ok("Record have been successfully Canceled.");
            }

            return BadRequest("Record not found.");
        }
    }
}
