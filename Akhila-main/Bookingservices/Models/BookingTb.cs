using System;
using System.Collections.Generic;

#nullable disable

namespace Bookingservices.Models
{
    public partial class BookingTb
    {
        public int BookingId { get; set; }
        public int? AirlineId { get; set; }
        public string Airlinename { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public string Seatnum { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Pnr { get; set; }
    }
}
