using Microsoft.EntityFrameworkCore;
using Miniprojet.Server.AppDbcontext;
using Miniprojet.Shared.Entites;

namespace Miniprojet.Server.Repositories
{
    public class ContactRespository : IContact
    {
        private readonly AppDbContext _context;
        public ContactRespository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact.Id;
        }

        public async Task DeleteContactAsync(int contactId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Contact> GetContactByIdAsync(int contactId)
        {
            return await _context.Contacts.FindAsync(contactId);

        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        //public async Task<List<Contact>> GetContactsByClientIdAsync(int clientId)
        //{
        //    return await _context.Contacts.Where(c => c.ClientId == clientId).ToListAsync();
        //}

        public async Task UpdateContactAsync(int contactId, Contact contact)
        {
            var find = await _context.Contacts.FindAsync(contactId);
            find.Email = contact.Email;
            find.ClientId=contact.ClientId;
            find.Prenom=contact.Prenom;
            find.Nom=contact.Nom;
            find.Telephone = contact.Telephone;
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
