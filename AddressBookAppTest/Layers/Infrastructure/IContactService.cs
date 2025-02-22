namespace AddressBookAppTest.Layers;

public interface IContactService
{
    Task<List<Contact>> GetAll(string? phrase);
    Task<Contact> Get(string id);
    Task<bool> Delete(string id);
}
