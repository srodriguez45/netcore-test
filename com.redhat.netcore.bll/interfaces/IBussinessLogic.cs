using System;
using System.Collections.Generic;
using System.Text;

namespace com.redhat.netcore.bll.interfaces
{
    public interface IBussinessLogic<T>
    {

        public List<T> GetAll();

        public T GetById(int id);

    }
}
