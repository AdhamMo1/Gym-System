using GymCore.Entities;
using GymCore.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymInfrastructure.Data.Repo
{
    public class SubCategoryRepo : GenericRepo<SubscriptionCategory>, ISubCategoryRepo
    {
        public SubCategoryRepo(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
        
    }
}
