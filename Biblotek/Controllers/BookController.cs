using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblotek.Controllers
{
    public class BookController : Controller
    {
        [Route("Book/{id}")]
        public IActionResult Index(int id)
        {
            var book = new BookService().Find(id);
            return View(book);
        }
        [Route("Books")]
        public IActionResult Books(int category = 0)
        {
            var model = new BookService().GetBookModel(category);
            return View(model);
        }
    }
}
