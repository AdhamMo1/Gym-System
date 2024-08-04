using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymCore.Dto.Incoming.Trainee
{
    public class TraineeInDto
    {
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public Guid SCId { get; set; }
    }
}
