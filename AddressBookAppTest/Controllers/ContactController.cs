using AddressBookAppTest.Layers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddressBookAppTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;
    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Contact>>> GetByPhrase(string phrase = "")
    {
        List<Contact> contacts = new();

        contacts = await _contactService.GetAll(phrase);
        return Ok(contacts);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Contact>> GetById(string id)
    {
        Contact contact = new();
        contact = await _contactService.Get(id);
        if (contact == null)
        {
            return NotFound();
        }
        return Ok(contact);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        bool success = false;
        success = await _contactService.Delete(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}
