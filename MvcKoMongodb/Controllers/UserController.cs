using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MvcKoMongodb.Models;
using MvcKoMongodb.MongoModels;

namespace MvcKoMongodb.Controllers
{
    public class UserController : ApiController
    {

        // GET api/user
        public async Task<IEnumerable<User>> Get()
        {
            return await UserRepository.GetUser();
        }

        // GET api/user/5
        public User Get(string id)
        {
            return UserRepository.GetUser(id);
        }

        // POST api/user
        public HttpResponseMessage Post(User user)
        {
            UserRepository.InsertUser(user);
            var response = Request.CreateResponse(HttpStatusCode.Created, user);
            string url = Url.Link("DefaultApi", new { user.Id });
            response.Headers.Location = new Uri(url);
            return response;
        }

        // DELETE api/user/5
        public async Task<HttpResponseMessage> Delete(string id)
        {
            await UserRepository.DeleteUser(id);
            var response = Request.CreateResponse(HttpStatusCode.OK, id);
            return response;
        }
    }
}
