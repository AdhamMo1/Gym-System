using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymCore.Entities
{
    public class Attendence
    {
        public Guid Id { get; set; }
        public DateTime? AttendedOn { get; set; }
        public Guid? TraineeId { get; set; }
        [JsonIgnore]
        public Trainee? Trainee { get; set; }
        public Attendence()
        {
            Id = Guid.NewGuid();
        }
    }
}
