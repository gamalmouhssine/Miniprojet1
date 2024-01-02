using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Miniprojet.Server.AppDbcontext;
using Miniprojet.Shared.Entites;

namespace Miniprojet.Server.Repositories
{
    public class ClientRepository : IClient
    {
        private readonly AppDbContext _context;
        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<int> AddClientAsync(Clients client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync(); 
            return client.Id;

        }

        public async Task<List<Clients>> GetClientinContactdAsync(int clientId)
        {
            var query = from client in _context.Clients
                        where client.Id == clientId
                        select new Clients
                        {
                            Id = client.Id,
                            RaisonSociale = client.RaisonSociale,
                            Adresse1 = client.Adresse1,
                            Adresse2 = client.Adresse2,
                            CodePostal  = client.CodePostal,
                            Description = client.Description,
                            TelephoneSecreteriat = client.TelephoneSecreteriat,
                            Pays= client.Pays,
                            Ville= client.Ville,
                            ImageUrl=client.ImageUrl,


                            Contacts = client.Contacts.Select(contact => new Contact
                            {
                                Id = contact.Id,
                                Nom = contact.Nom,
                                Prenom = contact.Prenom,
                                Email=contact.Email
                            }).ToList()
                        };

            var result = await query.ToListAsync();
            return result;
        }

        public async Task DeleteClientAsync(int clientId)
        {
            var client = await _context.Clients.FindAsync(clientId);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Clients> GetClientByIdAsync(int clientId)
        {
            return await _context.Clients.FindAsync(clientId);
        }

       

        public async Task<List<Clients>> GetClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task UpdateClientAsync(int clientId, Clients client)
        {
            var find= await _context.Clients.FindAsync(clientId);
            find.Description= client.Description;
            find.TelephoneSecreteriat= client.TelephoneSecreteriat;
            find.Adresse1 = client.Adresse1;
            find.Adresse2 = client.Adresse2;
            find.CodePostal = client.CodePostal;
            find.Description = client.Description;
            find.Pays= client.Pays;
            find.RaisonSociale= client.RaisonSociale;
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

     
    }
}
