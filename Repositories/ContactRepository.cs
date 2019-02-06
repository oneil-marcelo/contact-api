using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contact_api.Models;
using Contact_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace contact_api.Repositories
{
    public class ContactRepository : IContactRepository
    {

        private readonly AppDataContext _context;

        public ContactRepository(AppDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contact>> GetContacts()
        {
           var contacts = await _context.Contacts.AsNoTracking().ToListAsync();
           return contacts;
        }

        public async Task<Contact> GetContactById(int id)
        {
            var contact = await _context.Contacts.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            return contact;
        }
        public async Task<bool> AddContact(Contact model)
        {
            _context.Contacts.Add(model);
            
            try {
                await _context.SaveChangesAsync();
                return true;
            } catch {
                return false;
            }
            
        }

        public async Task<bool> EditContact(Contact model)
        {
            var contact = await GetContactById(model.Id);

            if(string.IsNullOrEmpty(contact.Name))
                return false;
            
            _context.Entry<Contact>(contact).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
                return true;
            } catch {
                return false;
            }
        }

        public async Task<bool> DeleteContact(Contact model)
        {
            var contact = await GetContactById(model.Id);

            if(string.IsNullOrEmpty(contact.Name))
                return false;
            
            _context.Contacts.Remove(contact);

            try {
                await _context.SaveChangesAsync();
                return true;
            } catch {
                return false;
            }
        }
    }
}