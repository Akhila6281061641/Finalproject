using System;
using System.Collections.Generic;

#nullable disable

namespace Bookingservices.Models
{
    public partial class UserTb
    {
        public int UserId { get; set; }
        public string AirlineName { get; set; }
        public int? FlightIdnum { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Emailid { get; set; }
        public int? Noofseats { get; set; }
        public string Seatno { get; set; }
        public string Meal { get; set; }
        public string Pnr { get; set; }
        public string Cancelled { get; set; }
    }
}
