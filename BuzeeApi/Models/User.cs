using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuzeeApi.Models
{
    public class User
    {
        public User() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public Group Group { get; set; }
    }
}