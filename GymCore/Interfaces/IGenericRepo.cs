using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCore.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        ValueTask<T> CreateAsync(T entity);
        ValueTask<T> ReadAsync(string entityId);
        ValueTask<IEnumerable<T>> ReadAllAsync();
        void Update(T entity);
        ValueTask DeleteAsync(string entityId);
    }
}
