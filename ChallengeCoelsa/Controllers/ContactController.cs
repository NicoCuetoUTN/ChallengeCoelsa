using Domain.Entities.Model;
using Domain.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[Route("api/[controller]")]
public class ContactController : Controller
{
    private IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }


    // GET api/values
    [HttpGet]
    public JsonResult Get()
    {
        try
        {
            IQueryable<Contact> contacts = this._contactService.GetAll();
            return new JsonResult(contacts);
        }
        catch (Exception ex)
        {
            return new JsonResult(StatusCode(500, $"Something went wrong: {ex.Message}"));
        }
    }

    // GET api/values
    [HttpGet]
    [Route("GetById/{contactId}")]

    public JsonResult GetById(string contactId)
    {
        try
        {
            Contact contact = this._contactService.GetById(Guid.Parse(contactId));
            return new JsonResult(contact);
        }
        catch (Exception ex)
        {
            return new JsonResult(StatusCode(500, $"Something went wrong: {ex.Message}"));
        }
    }

    [HttpPost]
    public JsonResult Post([FromBody] ContactDTO model)
    {
        try
        {
            bool created = this._contactService.Create(model.ToEntity(model));
            return new JsonResult(created);
        }
        catch (Exception ex)
        {
            return new JsonResult(StatusCode(500, $"Something went wrong: {ex.Message}"));
        }
    }

    [HttpDelete]
    [Route("Delete/{contactId}")]
    public JsonResult Delete(Guid contactId)
    {
        try
        {
            bool deleted = this._contactService.Delete(contactId);
            return new JsonResult(deleted);
        }
        catch (Exception ex)
        {
            return new JsonResult(StatusCode(500, $"Something went wrong: {ex.Message}"));
        }
    }
}