using Domain.Entities.Model;
using System;
using System.Linq;

namespace Domain.Logic.Interfaces
{
    public interface IContactService
    {
        IQueryable<Contact> GetAll();

        bool Create(Contact contact);

        bool Update(Contact contact);

        bool Delete(Guid contactId);

        Contact GetById(Guid contactId);
    }
}
