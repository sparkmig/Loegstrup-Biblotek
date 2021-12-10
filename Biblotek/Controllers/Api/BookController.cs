using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage.Models.Book;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Biblotek.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpPost]
        public bool AddComment(Comment comment)
        {
            return new BookService().AddComment(comment);
        }
        [HttpPost]
        public string UploadImage(int bookId)
        {
            if (!Request.Form.Files.Any())
                throw new Exception("Wrong type");

            var file = Request.Form.Files[0];

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return new BookService().UploadImage(bookId, ms.ToArray());
            }
        }
        [HttpPost, Admin]
        public bool Add([FromForm] Book book)
        {
            return new BookService().AddBook(book);
        }
        [HttpDelete, Admin]
        public bool Remove([FromForm]int id)
        {
            return new BookService().RemoveBook(id);
        }
    }
}
