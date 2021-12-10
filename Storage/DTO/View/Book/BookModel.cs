using Storage.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.DTO.View.Book
{
    public class BookModel
    {
        public List<CategoryName> Categories { get; set; }
        public List<Models.Book.Book> Books { get; set; }
    }
}
