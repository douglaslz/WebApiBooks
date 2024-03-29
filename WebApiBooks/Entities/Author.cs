﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBooks.Entities
{
    public class Author
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
