using System.Collections.Generic;
using System.Threading.Tasks;
using contact_api.Models;

namespace contact_api.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContactById(int id);
        Task<bool> AddContact(Contact model);
        Task<bool> EditContact(Contact model);
        Task<bool> DeleteContact(Contact model);
    }
}