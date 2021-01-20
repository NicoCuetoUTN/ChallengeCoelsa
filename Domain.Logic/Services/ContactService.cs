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

        public IQueryable<Contact> GetAll()
        {
            Contact contact1 = new Contact()
            {
                Id = Guid.NewGuid(),
                FirstName = "Nicolas",
                LastName = "Cueto",
                Company = "BINIT",
                Email = "ncueto@gmail.com",
                PhoneNumber = "1139146755"
            };
            Contact contact2 = new Contact()
            {
                Id = Guid.NewGuid(),
                FirstName = "Lucia",
                LastName = "Osimani",
                Company = "BINIT",
                Email = "losimani@gmail.com",
                PhoneNumber = "1139145677"
            };

            List<Contact> list = new List<Contact>();

            list.Add(contact1);
            list.Add(contact2);

            return list.AsQueryable();

            //return = this.dbContext.Set<Contact>();
        }

        public Contact GetById(Guid id)
        {
            return new Contact()
            {
                Id = Guid.NewGuid(),
                FirstName = "Nicolas",
                LastName = "Cueto",
                Company = "BINIT",
                Email = "ncueto@gmail.com",
                PhoneNumber = "1139146755"
            };
            //return this.dbContext.Set<Contact>().Find(id);
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
