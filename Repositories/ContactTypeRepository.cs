using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contact_api.Models;
using Contact_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace contact_api.Repositories
{
    public class ContactTypeRepository : IContactTypeRepository
    {
        private readonly AppDataContext _context;

        public ContactTypeRepository(AppDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ContactType>> GetContactTypes()
        {
           var contactTypes = await _context.ContactTypes.AsNoTracking().ToListAsync();
           return contactTypes;
        }

        public async Task<ContactType> GetContactTypeById(int id)
        {
            var contactType = await _context.ContactTypes.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return contactType;
        }

        public async Task<bool> AddContactType(ContactType model)
        {
            _context.ContactTypes.Add(model);
            
            try
            {
                await _context.SaveChangesAsync();
                return true;
                
            } catch {

                return false;
            }
            
        }

        public async Task<bool> EditContactType(ContactType model)
        {
            var contactType = await GetContactTypeById(model.Id);

            if(string.IsNullOrEmpty(contactType.Name))
                return false;

            _context.Entry<ContactType>(model).State = EntityState.Modified;

            try {

                await _context.SaveChangesAsync();
                return true;

            } catch {
                return false;
            }
        }

    }
}