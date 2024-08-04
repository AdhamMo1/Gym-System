using GymCore.Entities;
using GymCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace GymInfrastructure.Data.Repo
{
    public class AttendenceRepo : GenericRepo<Attendence>,IAttendenceRepo
    {
        public AttendenceRepo(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async ValueTask<Attendence> CreateAsync(Attendence entity)
        {
            
            var trainee = await _context.Trainees.Include(p=>p.subscriptionCategory).FirstOrDefaultAsync(x=> x.Id == entity.TraineeId);
            if (trainee == null)
            {
                throw new Exception("Trainee Not found! ,try again");
            }
            if (trainee.DaysRemain > 0)
            {
                trainee.DaysRemain -= 1;
            }
            else if (trainee.DaysRemain == 0)
            {
                trainee.MonthsRemain -= 1;
                if (trainee.MonthsRemain > 0)
                {
                    trainee.DaysRemain = trainee.subscriptionCategory.DurationByDay;
                    trainee.DaysRemain -= 1;
                }
                else
                {
                    throw new Exception("Subscribtion Ended..,try to subscrib again");
                }
            }
            entity.AttendedOn = DateTime.Now;
            await _entity.AddAsync(entity);
            return entity;
        }
    }
}
