﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuzeeApi.Models;

namespace BuzeeApi.Controllers
{
    public class UsersController : ApiController
    {

        
        static readonly IUserRepository repository = new UserRepository();

        public IEnumerable<User> GetAllUsers()
        {
            return repository.GetAll();
        }

        public User GetUser(int id)
        {
            using (var ctx = new DBBase()) { }
            User item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<User> GetUsersByStatus(string status)
        {
            using (var ctx = new DBBase()) { }
            return repository.GetAll().Where(
                p => string.Equals(p.Status, status, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostUser(User item)
        {
            using (var ctx = new DBBase()) { }
            item = repository.Add(item);
            var response = Request.CreateResponse<User>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutUser(int id, User user)
        {
            using (var ctx = new DBBase()) { }
            user.Id = id;
            if (!repository.Update(user))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteUser(int id)
        {
            using (var ctx = new DBBase()) { }
            User item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }
    }



}
