using Storage.Context;
using Storage.Models.Book;
using Storage.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblotek.Controllers
{
    public class AdminService
    {
        public AdminService()
        {
        }

        public bool Login(string email, string password)
        {
            bool isValid; 
            
            isValid = email == "test" && password == "test";

            return isValid;
        }
        public List<KeyValuePair<int, string>> Search(string str)
        {
            using (var ctx = new LibaryContext())
            {
                var books = ctx.Books.Where(book => book.Name.Contains(str)).ToList();
                return books.Select(book => new KeyValuePair<int, string>(book.Id, book.Name)).ToList();
            }
        }

        public bool AddRule(RuleModel rule)
        {
            using (var ctx = new LibaryContext())
            {
                ctx.Rules.Add(rule);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRule(int id)
        {
            using (var ctx = new LibaryContext())
            {
                var rule = ctx.Rules.Find(id);

                ctx.Rules.Remove(rule);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}