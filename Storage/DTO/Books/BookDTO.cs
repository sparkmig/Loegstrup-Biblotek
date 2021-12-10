using Storage.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.DTO.Books
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public DateTime PublishDate { get; set; }
        public string Summary { get; set; }
        public byte[] Picture { get; set; }
        public Comment[] Comments { get; set; }
        public CategoryName[] Categories { get; set; }
    }
}
