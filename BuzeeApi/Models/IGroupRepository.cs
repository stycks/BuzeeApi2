using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzeeApi.Models
{
    interface IGroupRepository
    {
        IEnumerable<Group> GetAll();
        Group Get(int id);
        Group Add(Group item);
        void Remove(int id);
        bool Update(Group item);

    }
}
