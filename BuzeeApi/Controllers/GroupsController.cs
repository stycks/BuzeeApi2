using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuzeeApi.Models;

namespace BuzeeApi.Controllers
{
    public class GroupsController : ApiController
    {
        static readonly IGroupRepository repository = new GroupRepository();

        public IEnumerable<Group> GetAllGroups()
        {
            return repository.GetAll();
        }

        public Group GetGroup(int id)
        {
            using (var ctx = new DBBase()) { }
            Group item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        //public IEnumerable<User> GetUsersByStatus(string status)
        //{
        //    using (var ctx = new DBBase()) { }
        //    return repository.GetAll().Where(
        //        p => string.Equals(p.Status, status, StringComparison.OrdinalIgnoreCase));
        //}

        public HttpResponseMessage PostGroup(Group item)
        {
            using (var ctx = new DBBase()) { }
            item = repository.Add(item);
            var response = Request.CreateResponse<Group>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutGroup(int id, Group group)
        {
            using (var ctx = new DBBase()) { }
            group.Id = id;
            if (!repository.Update(group))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteGroup(int id)
        {
            using (var ctx = new DBBase()) { }
            Group item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }
    }
}
