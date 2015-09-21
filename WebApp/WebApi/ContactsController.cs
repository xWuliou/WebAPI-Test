using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Web.Http;
using Common;

namespace WebApi
{
    public class ContactsController:ApiController
    {
      private static List<Contact> contacts;
      private static int counter = 2;

      static ContactsController()
      {
        contacts = new List<Contact>();

          contacts.Add(new Contact{Id = "001",Name = "zhangsan",PhoneNo = "1231231",EmailAddress = "zhangsan@gmail.com",Address = "江苏苏州"});
          contacts.Add(new Contact(){Id = "002",Name = "lisi",PhoneNo = "14322222222",EmailAddress = "lisi@gmail.com",Address = "jiangsu xuzhou"});

      }


      public IEnumerable<Contact> Get(string id = null)
      {
        return from contact in contacts
          where contact.Id == id || string.IsNullOrEmpty(id)
          select contact;
      }

      public void Post(Contact contact)
      {
        Interlocked.Increment(ref counter);
        contact.Id = counter.ToString("D3");
          contacts.Add(contact);
      }

      public void Put(Contact contact)
      {
        contacts.Remove(contacts.First(c => c.Id == contact.Id));
        contacts.Add(contact);
      }

      public void Delete(string id)
      {
        contacts.Remove(contacts.First(c => c.Id == id));
      }

    }
}
