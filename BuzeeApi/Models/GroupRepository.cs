using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzeeApi.Models
{
    public class GroupRepository : IGroupRepository
    {
        private List<Group> groups = new List<Group>();
        private int _nextId = 1;

        public GroupRepository() { }

        public IEnumerable<Group> GetAll()
        {
            return groups;
        }

        public Group Get(int id)
        {
            return groups.Find(p => p.Id == id);
        }

        public Group Add(Group item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            groups.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            groups.RemoveAll(p => p.Id == id);
        }

        public bool Update(Group item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = groups.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            groups.RemoveAt(index);
            groups.Add(item);
            return true;
        }
    }
}
