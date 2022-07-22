﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Ticketservices.Models
{
    public partial class ScheduledTb
    {
        public int FlightIdnum { get; set; }
        public int? AirlineId { get; set; }
        public string Airlinename { get; set; }
        public string Fromplace { get; set; }
        public string Toplace { get; set; }
        public DateTime? Startdatetime { get; set; }
        public DateTime? Enddatetime { get; set; }
        public string Scheduledays { get; set; }
        public int? BusinessClsseats { get; set; }
        public int? Nonbusinessclsseats { get; set; }
        public string Ticketprice { get; set; }
        public int? Noofrows { get; set; }
        public string Meal { get; set; }

        public virtual AirlineTb Airline { get; set; }
    }
}
