using System;
using System.Collections.Generic;

#nullable disable

namespace Bookingservices.Models
{
    public partial class AirlineTb
    {
        public AirlineTb()
        {
            ScheduledTbs = new HashSet<ScheduledTb>();
        }

        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineLogo { get; set; }
        public string Address { get; set; }
        public string ContactNum { get; set; }

        public virtual ICollection<ScheduledTb> ScheduledTbs { get; set; }
    }
}
