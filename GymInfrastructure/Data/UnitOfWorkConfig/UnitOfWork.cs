using GymCore.Interfaces;
using GymCore.Interfaces.IUnitOfWorkConfig;
using GymInfrastructure.Data.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymInfrastructure.Data.UnitOfWorkConfig
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Db_Logs");
            Trainees = new TraineeRepo(context, _logger);
            Attendences = new AttendenceRepo(context, _logger);
            SubCategories = new SubCategoryRepo(context, _logger);
        }

        public ITraineeRepo Trainees { get; private set; }

        public IAttendenceRepo Attendences { get; private set; }

        public ISubCategoryRepo SubCategories { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async ValueTask Save()
        {
            await _context.SaveChangesAsync();   
        }
    }
}
