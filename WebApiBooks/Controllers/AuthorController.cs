using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBooks.Contexts;
using WebApiBooks.Entities;

namespace WebApiBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly ApplicationDBContext context;

        public AuthorController(ApplicationDBContext context)
        {
            this.context = context;
        }

        //get api authors
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            return context.Authors.ToList();
        }

        //get api author 5
        [HttpGet("{id}", Name = "Obtainauthor")]
        public ActionResult<Author> Get(int id)
        {
            var author = context.Authors.FirstOrDefault(x => x.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }
        
        //post api authors
        [HttpPost]
        public ActionResult Post([FromBody] Author author)
        {
            context.Add(author);
            context.SaveChanges();
            return new CreatedAtRouteResult ("Obtainauthor",new { id = author.Id},author);
            

        }

        //put api/authors/5
        //modify record
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Author author)
        {
            context.Entry(author).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();


        }

        //delete api/authors/5
        //delete record
        [HttpDelete("{id}")]
        public ActionResult<Author> Delete( int id)
        {
            var author = context.Authors.FirstOrDefault(x => x.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            context.Remove(author);
            context.SaveChanges();
            return Ok(author);


        }
        //get api authors
        //show first
        [HttpGet("first")]
        public ActionResult<Author> GetFirst()
        {
            return context.Authors.FirstOrDefault();
        }

    }
}
