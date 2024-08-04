using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCore.Entities
{
    public class SubscriptionCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? DurationByMonth { get; set; }
        public int? DurationByDay { get; set;}
        public int? DurationByYear { get; set;}
    }
}
