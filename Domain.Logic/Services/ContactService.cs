using Domain.Entities.Model;
using Domain.Logic.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Logic.Services
{
    public class ContactService : IContactService
    {
        #region Properties

        protected readonly ModelDbContext dbContext;
     

        protected ILogger logger;

        #endregion

        #region Constructor

        public ContactService(ModelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        public IQueryable<Contact> GetAll() => this.dbContext.Set<Contact>();

        public Contact GetById(Guid id)
        {
            try
            {
                Contact result =  this.dbContext.Set<Contact>().Find(id);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                Contact contact = this.GetById(id);
                this.dbContext.Remove(contact);
                this.dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Create(Contact contact)
        {
            try
            {
                this.dbContext.Set<Contact>().Add(contact);
                this.dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public bool Update(Contact contact)
        {
            try
            {
                this.dbContext.Update(contact);
                this.dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
