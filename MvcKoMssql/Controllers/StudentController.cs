using MvcKo.EntityDataModel;
using MvcKo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcKo.Controllers
{
    /// <summary>
    /// Student Api controller
    /// </summary>
    public class StudentController : ApiController
    {

        // GET api/student
        public IEnumerable<Students> Get()
        {
            return StudentRepository.GetStudents();
        }

        // GET api/student/5
        public Students Get(int id)
        {
            return StudentRepository.GetStudents().FirstOrDefault(s => s.Id == id);
        }

        // POST api/student
        public HttpResponseMessage Post(Students student)
        {
            StudentRepository.InsertStudent(student);
            var response = Request.CreateResponse(HttpStatusCode.Created, student);
            string url = Url.Link("DefaultApi", new { student.Id });
            response.Headers.Location = new Uri(url);
            return response;
        }

        // DELETE api/student/5
        public HttpResponseMessage Delete(int id)
        {
            StudentRepository.DeleteStudent(id);
            var response = Request.CreateResponse(HttpStatusCode.OK, id);
            return response;
        }
    }
}