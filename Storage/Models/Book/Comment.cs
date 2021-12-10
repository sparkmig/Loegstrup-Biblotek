using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models.Book
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public bool Approoved { get; set; }
    }
}
