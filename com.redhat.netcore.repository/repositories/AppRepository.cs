using com.redhat.netcore.context;
using com.redhat.netcore.repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace com.redhat.netcore.repository.repositories
{
    public class AppRepository<T> : IRepository<T> where T : class
    {
        protected readonly DBApiContext context;
        protected readonly DbSet<T> table;

        public AppRepository(DBApiContext context)
        {
            this.context = context;
            table = this.context.Set<T>();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }
    }


}
