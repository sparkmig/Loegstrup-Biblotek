using Storage.Context;
using Storage.DTO.View.Home;
using Storage.Models.Book;
using Storage.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class HomeService
    {
        public Book[] GetrandomBooks(int amount = 3)
        {
            Book[] result = new Book[3];
            using (var ctx = new LibaryContext())
            {
                int count = ctx.Books.Count();
                var rand = new Random();
                var books = ctx.Books.ToArray();

                for (int i = 0; i < amount; i++)
                {
                    int indx = rand.Next(0, count);
                    var book = books[indx];

                    if (result.Contains(book))
                    {
                        i--;
                        continue;
                    }
                    result[i] = book;
                }
            }
            return result;
        }
        public Book[] GetNewestBooks(int amount = 3)
        {
            using (var ctx = new LibaryContext())
            {
                return ctx.Books.OrderByDescending(o => o.PublishDate)
                    .Take(amount)
                    .ToArray();
            }
        }

        public RuleModel[] GetRules(string search = null)
        {
            using (var ctx = new LibaryContext())
            {
                if (search != null)
                {
                    return ctx.Rules.Where(rule => rule.Title.Contains(search)).ToArray();
                }
                return ctx.Rules.ToArray();
            }
        }

        public HomeModel GetHomeModel()
        {
            return new HomeModel(GetrandomBooks(), GetNewestBooks());
        }

    }
}
