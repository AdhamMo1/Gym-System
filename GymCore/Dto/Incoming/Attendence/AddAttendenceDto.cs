using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymCore.Dto.Incoming.Attendence
{
    public class AddAttendenceDto
    {
        public Guid TraineeId { get; set; }
        
    }
}
