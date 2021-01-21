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

    [HttpGet]
    public JsonResult Get()
    {
        try
        {
            IQueryable<ContactDTO> contactDtos = this._contactService.GetAll().Select(c => new ContactDTO(c));
            return new JsonResult(contactDtos);
        }
        catch (Exception ex)
        {
            return new JsonResult(StatusCode(500, $"Something went wrong: {ex.Message}"));
        }
    }

    [HttpGet]
    [Route("GetById/{contactId}")]

    public JsonResult GetById(string contactId)
    {
        try
        {
            ContactDTO contact = new ContactDTO(this._contactService.GetById(Guid.Parse(contactId)));
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
        bool succeed;
        try
        {
            if (model.Id.HasValue)
                succeed = this._contactService.Update(model.ToEntity(model));
            else
                succeed = this._contactService.Create(model.ToEntity(model));
            return new JsonResult(succeed);
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