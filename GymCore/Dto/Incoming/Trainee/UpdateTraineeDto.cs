using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCore.Dto.Incoming.Trainee
{
    public class UpdateTraineeDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public Guid? SCId { get; set; }
    }
}
