using System.Collections.Generic;
using System.Threading.Tasks;
using contact_api.Models;

namespace contact_api.Repositories
{
    public interface IContactTypeRepository
    {
        Task<IEnumerable<ContactType>> GetContactTypes();
        Task<ContactType> GetContactTypeById(int id);
        Task<bool> AddContactType(ContactType model);
        Task<bool> EditContactType(ContactType model);
    }
}