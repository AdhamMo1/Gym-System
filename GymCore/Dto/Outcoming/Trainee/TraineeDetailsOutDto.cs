using GymCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCore.Dto.Outcoming.Trainee
{
    public class TraineeDetailsOutDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public DateTime AddedOn { get; set; }
        public Guid SCId { get; set; }
        public string SCName { get; set; }
        public decimal Price { get; set; }
        public int? DaysRemain { get; set; }
        public int? MonthsRemain { get; set; }
        public IEnumerable<Attendence> Attendences { get; set; }
    }
}
