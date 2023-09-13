using CrudApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudApi.Controllers
{
    public class WebApiController : ApiController
    {
        CrudContext db = new CrudContext();

        [HttpGet]
        public IHttpActionResult StudentGet()
        {
            List<Student> obj = db.std.ToList();
            return Ok(obj);
        }

        [HttpGet]
        public IHttpActionResult StudentGet(int id)
        {
            var data = db.std.Where(model => model.Id == id).FirstOrDefault();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult StudentInser(Student s)
        {
            db.std.Add(s);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult StudentUpdate(Student s)
        {

            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            //var data = db.std.Where(model => model.Id==s.Id).FirstOrDefault();

            //if(data != null)
            //{
            //    data.Id = s.Id;
            //    data.FirstName = s.FirstName;
            //    data.LastName = s.LastName;
            //    data.City = s.City;
            //    db.SaveChanges();
            //}
            //else
            //{
            //   return  NotFound();
            //}
            return Ok();
        }

        [HttpDelete]

        public IHttpActionResult StudentDelete(int id)
        {
            var data = db.std.Where(model => model.Id == id).FirstOrDefault();


            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }


    }
}
