using System;
using System.Collections.Generic;
using System.Text;

namespace com.redhat.netcore.repository.interfaces
{
    public interface IRepository<T> where T : class
    {

        public List<T> GetAll();

        public T GetById(int id);

    }
}
