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
    public class BookController : ControllerBase
    {


        private readonly ApplicationDBContext context;

        public BookController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return context.Books.Include(x => x.Author).ToList();
            //return context.Books.ToList();
        }


        [HttpGet("{id}", Name = "ObtainBook")]
        public ActionResult<Book> Get(int id)
        {
            var book = context.Books.Include(x => x.Author).FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }



        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            context.Add(book);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtainBook", new { id = book.Id }, book);


        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();


        }


        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            context.Remove(book);
            context.SaveChanges();
            return Ok(book);


        }
        [HttpGet("first")]
        public ActionResult<Book> GetFirst()
        {
            return context.Books.FirstOrDefault();
        }














    }
}
