using Storage.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.DTO.View.Home
{
    public class HomeModel
    {
        public HomeModel(Models.Book.Book[] books, Models.Book.Book[] newestBooks)
        {
            Books = books;
            NewestBooks = newestBooks;
        }

        public Storage.Models.Book.Book[] Books { get; set; }
        public Storage.Models.Book.Book[] NewestBooks { get; set; }
    }
}
