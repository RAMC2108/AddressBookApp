using System.Text.Json;

namespace AddressBookAppTest.Layers;

public class ContactService : IContactService
{
    private readonly List<Contact> _contact;
    private readonly string _filePath;
    public ContactService(IWebHostEnvironment env)
    {
        _filePath = Path.Combine(env.ContentRootPath, "fakedatabase.json");

        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            _contact = JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }
        else
        {
            _contact = new List<Contact>();
        }
    }
    public async Task<List<Contact>> GetAll(string phrase)
    {
        var contact = _contact.OrderBy(x => x.name).ToList();
        if (!string.IsNullOrEmpty(phrase))
        {
            contact = contact.Where(x => x.name.StartsWith(phrase, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        return contact;
    }
    public async Task<Contact> Get(string id)
    {
        Contact contact = new();
        if (!string.IsNullOrEmpty(id))
        {
            contact = _contact.FirstOrDefault(x => x.id == id);
        }
        return contact;
    }

    public async Task<bool> Delete(string id)
    {
        bool success = false;
        Contact contact = new();
        if (!string.IsNullOrEmpty(id))
        {
            contact = _contact.FirstOrDefault(x => x.id == id);
            if (contact != null)
            {
                _contact.Remove(contact);
                string updatedJson = JsonSerializer.Serialize(_contact, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, updatedJson);
                success = true;
            }
        }
        return success;
    }
}
