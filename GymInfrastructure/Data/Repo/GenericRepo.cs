using GymCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymInfrastructure.Data.Repo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected ApplicationDbContext _context { get; set; }
        protected DbSet<T> _entity { get; set; }
        protected ILogger _logger { get; set; }
        public GenericRepo(ApplicationDbContext context,ILogger logger)
        {
            _context = context;
            _entity = _context.Set<T>();
            _logger = logger;
        }

        public virtual async ValueTask<T> CreateAsync(T entity)
        {
            await _entity.AddAsync(entity);
            return entity;
        }

        public virtual async ValueTask<IEnumerable<T>> ReadAllAsync()
        {
            return await _entity.ToListAsync();
        }
        public virtual async ValueTask<T> ReadAsync(string entityId)
        {
            return await _entity.FindAsync(Guid.Parse(entityId));
        }
        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual async ValueTask DeleteAsync(string entityId)
        {
            _entity.Remove(await _entity.FindAsync(Guid.Parse(entityId)));
        }
    }
}
