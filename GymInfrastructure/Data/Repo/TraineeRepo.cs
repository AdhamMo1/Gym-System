using GymCore.Entities;
using GymCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GymInfrastructure.Data.Repo
{
    public class TraineeRepo : GenericRepo<Trainee>, ITraineeRepo
    {
        public TraineeRepo(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async ValueTask<IEnumerable<Trainee>> ReadAllAsync()
        {
            return await _entity.Include(x=>x.subscriptionCategory).Include(x=>x.Attendences).AsNoTracking().ToListAsync();
        }
        public override async ValueTask<Trainee> ReadAsync(string entityId)
        {
            return _entity.Include(p => p.subscriptionCategory).Include(p=>p.Attendences).FirstOrDefault(p => p.Id.ToString()==entityId);
        }
        public override async ValueTask<Trainee> CreateAsync(Trainee entity)
        {
            var subCategory =await _context.SubscriptionCategory.FindAsync(entity.SCId);
            if (subCategory == null)
            {
                throw new Exception("Check Subscribtion Category Id , not found!");
            }
            entity.AddedOn = DateTime.Now;
            entity.DaysRemain = subCategory.DurationByDay;
            entity.MonthsRemain = subCategory.DurationByMonth;
            await _entity.AddAsync(entity);
            return entity;
        }
        public override void Update(Trainee entity)
        {
            var oldTrainee = _context.Trainees.Include(p =>p.subscriptionCategory).FirstOrDefault(x => x.Id==entity.Id);
            if (oldTrainee == null)
            {
                throw new Exception("Not found : Id Not Valid");
            }
            if (oldTrainee.SCId != entity.SCId)
            {
                var newSC = _context.SubscriptionCategory.FirstOrDefault(x=>x.Id==entity.SCId);
                if (newSC == null)
                {
                    throw new Exception("Not found : SCId Not Valid");
                }
                oldTrainee.DaysRemain = newSC.DurationByDay;
                oldTrainee.MonthsRemain = newSC.DurationByMonth;
            }
            if(oldTrainee.DaysRemain==0&&oldTrainee.MonthsRemain==1)
            {
                oldTrainee.DaysRemain = oldTrainee.subscriptionCategory.DurationByDay;
                oldTrainee.MonthsRemain = oldTrainee.subscriptionCategory.DurationByMonth;
            }
            oldTrainee.Name = entity.Name;
            oldTrainee.AddedOn = oldTrainee.AddedOn;
            oldTrainee.SCId = entity.SCId;
            oldTrainee.Gender = entity.Gender;
            oldTrainee.Phone = entity.Phone;
            //_context.Entry(entity).State = EntityState.Modified;
        }
    }
}
