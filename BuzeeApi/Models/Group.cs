using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuzeeApi.Models
{
    public class Group
    {
        public Group() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}