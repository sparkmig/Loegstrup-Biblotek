using Biblotek.Controllers.Api;
using Biblotek.Models;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.DTO.Books;
using Storage.Models.Book;
using Storage.Models.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Biblotek.Controllers
{
    [Admin]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(new BookService().Find(id));
        }
        [HttpPost]
        public IActionResult Edit(BookDTO book)
        {
            var files = Request.Form.Files;

            byte[] file = null;

            if (files.Any())
            {
                var ms = new MemoryStream();
                files[0].CopyTo(ms);
                file = ms.ToArray();
            }

            new BookService().Edit(book, file);

            return Edit(book.Id);
        }

        [HttpGet]
        public List<KeyValuePair<int, string>> Search([FromQuery] string name)
        {
            return new AdminService().Search(name);
        }

        [HttpPost]
        public bool AddRule(RuleModel rule)
        {
            return new AdminService().AddRule(rule);
        }

        [HttpGet]
        public RuleModel[] GetRules(string search)
        {
            return new HomeService().GetRules(search);
        }
        [HttpDelete]
        public bool DeleteRule(int id)
        {
            return new AdminService().DeleteRule(id);
        }
    }
}
