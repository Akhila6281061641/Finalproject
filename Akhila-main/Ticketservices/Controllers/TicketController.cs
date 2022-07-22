using Common;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketservices.Models;
using Ticketservices.Viewmodel;

namespace Ticketservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        //FlightDBContext db;

        //public TicketController(FlightDBContext _db)
        //{
        //    db = _db;
        //}
        //[HttpPost("Schedule")]
        //public IActionResult Schedule([FromBody] Ticketviewmodel ticketviewmodel)
        //{
        //    Random random = new Random();
        //    int pnr = random.Next();
        //    ScheduledTb scheduledTb = new ScheduledTb();
        //    scheduledTb.FlightIdnum = ticketviewmodel.FlightIdnum;
        //    scheduledTb.AirlineId = ticketviewmodel.AirlineId;
        //    scheduledTb.Airlinename = ticketviewmodel.Airlinename;
        //    scheduledTb.Fromplace = ticketviewmodel.Fromplace;
        //    scheduledTb.Toplace = ticketviewmodel.Toplace;
        //    scheduledTb.Startdatetime = ticketviewmodel.Startdatetime;
        //    scheduledTb.Enddatetime = ticketviewmodel.Enddatetime;
        //    scheduledTb.Scheduledays = ticketviewmodel.Scheduledays;
        //    scheduledTb.BusinessClsseats = ticketviewmodel.BusinessClsseats;
        //    scheduledTb.Nonbusinessclsseats = ticketviewmodel.Nonbusinessclsseats;
        //    scheduledTb.Ticketprice = ticketviewmodel.Ticketprice;
        //    scheduledTb.Noofrows = ticketviewmodel.Noofrows;
        //    scheduledTb.Meal = ticketviewmodel.Meal;

        //    db.ScheduledTbs.Add(scheduledTb);
        //    db.SaveChanges();
        //    return Ok("Scheduled successfully");
        //}
        //[HttpGet]
        //[Route("ShowData")]
        //public IEnumerable<ScheduledTb> ShowData()
        //{
        //    return db.ScheduledTbs;
        //}
        //[HttpGet("{Pnr}", Name = "GetDetailsByPnr")]

        //public IActionResult GetByEmail(string Pnr)
        //{
        //    var data = db.BookingTbs.SingleOrDefault(x => x.Pnr == Pnr);
        //    if (data == null)
        //    {
        //        return Ok("record not found");
        //    }
        //    return Ok(data);
        //}



        //[HttpGet]
        //[Route("{airlineId}")]

        //public IEnumerable<ScheduledTb>getDetails([FromRoute] int airlineId )
        //  {
        //      return db.FindAll(airlineId);

        //  }


        private readonly IBus bus;
        public TicketController(IBus _bus)
        {
            bus = _bus;
        }
        [HttpGet]
        public IActionResult getData(int pnr)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                ticket.BookedOn = DateTime.Now;
                Uri uri = new Uri("rabbitmq://localhost/ticketQueue");
                var endpoint = await bus.GetSendEndpoint(uri);
                await endpoint.Send(ticket);
                return Ok();
            }

            return BadRequest();
        }

    }

}


