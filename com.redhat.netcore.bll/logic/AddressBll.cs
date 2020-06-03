using com.redhat.netcore.bll.interfaces;
using com.redhat.netcore.context;
using com.redhat.netcore.models.entities;
using com.redhat.netcore.repository.interfaces;
using com.redhat.netcore.repository.repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.redhat.netcore.bll.logic
{
    public class AddressBll : IBussinessLogic<Address>
    {

        protected DBApiContext context;
        protected List<Address> AddressList;
        protected IRepository<Address> repo;

        public AddressBll(DBApiContext context)
        {
            this.context = context;
            this.AddressList = null;
            this.repo = new AppRepository<Address>(context);
        }

        public List<Address> GetAll()
        {

            try
            {
                this.AddressList = repo.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

            return this.AddressList;
        }

        public Address GetById(int id)
        {
            Address Address = null;

            try
            {
                Address = repo.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }

            return Address;
        }
    }
}
