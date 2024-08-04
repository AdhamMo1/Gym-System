using GymCore.Entities;

namespace GymCore.Dto.Outcoming.Trainee
{
    public class TraineeOutDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public DateTime AddedOn { get; set; }
        public Guid SCId { get; set; }
        public string SCName { get; set; }
        public int? DaysRemain { get; set; }
        public int? MonthsRemain { get; set; }
    }
}
