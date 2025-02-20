﻿using System;

namespace Domain.Entities.Model
{
    public class ContactDTO
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    
        public ContactDTO() { }
        public Contact ToEntity(ContactDTO model)
        {
            return new Contact()
            {
                Id = model.Id ?? Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Company = model.Company,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
        }

        public ContactDTO (Contact contact)
        {
            this.Id = contact.Id;
            this.FirstName = contact.FirstName;
            this.LastName = contact.LastName;
            this.Company = contact.Company;
            this.Email = contact.Email;
            this.PhoneNumber = contact.PhoneNumber;
        }
    }
}
