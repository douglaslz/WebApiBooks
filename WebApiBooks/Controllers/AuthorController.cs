using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
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
            return new CreatedAtRouteResult ("Obtain author", author);
            

        }

    }
}
