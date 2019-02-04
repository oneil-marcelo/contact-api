using System.Collections.Generic;

namespace contact_api.Models
{
    public class ContactType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}