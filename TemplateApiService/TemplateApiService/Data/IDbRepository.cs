using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateApiService.Data
{
    public interface IDbRepository<T> where T : class
    {
        IQueryable<T> GetAll(string Id = "");

        T Find(Guid key);

        T Find(string key);

        void Remove(Guid key);

        void Add(T item);

        void Update(T item);
    }
}
