using Miniprojet.Shared.Entites;

namespace Miniprojet.Server.Repositories
{
    public interface IContact
    {
//        Task<List<Contact>> GetContactsByClientIdAsync(int clientId);
        Task<Contact> GetContactByIdAsync(int contactId);
        Task<List<Contact>> GetContactsAsync();
        Task<int> AddContactAsync(Contact contact);
        Task DeleteContactAsync(int contactId);
        Task UpdateContactAsync(int contactId, Contact contact);
    }
}
