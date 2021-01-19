using Domain.Entities.Model;
using Domain.Logic.Interfaces;
using Microsoft.Extensions.Logging;
using System;
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

        public IQueryable<Contact> GetAll()
        {
            var pepe = this.dbContext.Set<Contact>();
            return pepe;
        }

        public Contact GetById(Guid id)
        {
            return this.dbContext.Set<Contact>().Find(id);
        }

        public bool Delete(Guid id)
        {
            Contact contact = this.GetById(id);
            var result =  this.dbContext.Set<Contact>().Remove(contact);
            return result != null;
        }

        public bool Create(Contact contact)
        {
            var result =  this.dbContext.Set<Contact>().Add(contact);
            return result != null;
        }

    }
}
