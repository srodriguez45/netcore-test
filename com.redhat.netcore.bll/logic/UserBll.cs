using com.redhat.netcore.bll.interfaces;
using com.redhat.netcore.context;
using com.redhat.netcore.models.entities;
using com.redhat.netcore.repository.interfaces;
using com.redhat.netcore.repository.repositories;
using System;
using System.Collections.Generic;

namespace com.redhat.netcore.bll.logic
{
    public class UserBll : IBussinessLogic<User>
    {

        protected DBApiContext context;
        protected List<User> userList;
        protected IRepository<User> repo;

        public UserBll(DBApiContext context)
        {
            this.context = context;
            this.userList = null;
            this.repo = new AppRepository<User>(context);
        }

        public List<User> GetAll()
        {

            try
            {
                this.userList = repo.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

            return this.userList;
        }

        public User GetById(int id)
        {
            User user = null;

            try
            {
                user = repo.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }
    }
}
