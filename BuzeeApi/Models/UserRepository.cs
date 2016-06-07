using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuzeeApi.Models
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        private int _nextId = 1;

        public UserRepository()
        {
            Add(new User { Name = "Mati Kaal", Status = "Busy" });
            Add(new User { Name = "Siiri Uus", Status = "Not busy" });
            Add(new User { Name = "Peeter Rebane", Status = "A Bit busy" });
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User Get(int id)
        {
            return users.Find(p => p.Id == id);
        }

        public User Add(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            users.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            users.RemoveAll(p => p.Id == id);
        }

        public bool Update(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = users.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            users.RemoveAt(index);
            users.Add(item);
            return true;
        }
    }
}