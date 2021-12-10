using Storage;
using Storage.Context;
using Storage.DTO.Books;
using Storage.DTO.View.Book;
using Storage.DTO.View.Home;
using Storage.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BookService
    {

        public BookDTO Find(int id)
        {
            using (var ctx = new LibaryContext())
            {
                var book = ctx.Books.Find(id);
                var dto = book.Map<BookDTO>();

                var comments = ctx.Comments.Where(o => o.BookId == dto.Id);
                dto.Comments = comments.ToArray();
                GetBookCategories(dto);
                return dto;
            }
        }

        public bool AddComment(Comment comment)
        {
            using (var ctx = new LibaryContext())
            {
                comment.Approoved = false;
                ctx.Comments.Add(comment);
                return ctx.SaveChanges() == 1;
            }
        }

        public void Edit(BookDTO bookDTO, byte[] file)
        {
            Book book = null;

            using (var ctx = new LibaryContext())
            {
                book = ctx.Books.Find(bookDTO.Id);

                if (book == null)
                    throw new Exception("du gay");

                book.Author = bookDTO.Author;
                book.ISBN = bookDTO.ISBN;
                book.Name = bookDTO.Name;
                book.Pages = bookDTO.Pages;
                book.PublishDate = bookDTO.PublishDate;
                book.Summary = bookDTO.Summary;

                if (file != null)
                {
                    book.Picture = file;
                }

                ctx.SaveChanges();
            }

        }

        public void GetBookCategories(BookDTO book)
        {
            using (var ctx = new LibaryContext())
            {
                var categorieIds = ctx.Categories.Where(o => o.BookId == book.Id).Select(o => o.CategoryId).ToArray();
                var categories = ctx.CategoryNames.ToList().Where(o => categorieIds.Contains(o.Id)).ToArray();
                book.Categories = categories;
            }
        }
        public BookModel GetBookModel(int categoryId)
        {
            BookModel bookModel = new BookModel();
            using (var ctx = new LibaryContext())
            {
                var categories = ctx.CategoryNames.ToList();
                bookModel.Categories = categories;
                List<int> bookIds;

                if (categoryId == 0)
                {
                    bookModel.Books = ctx.Books.ToList();
                }
                else
                {
                    bookIds = ctx.Categories.Where(o => o.CategoryId == categoryId)
                        .Select(o => o.BookId)
                        .ToList();

                    var books = ctx.Books
                        .ToList()
                        .Where(o => bookIds.Contains(o.Id));

                    bookModel.Books = books.ToList();
                }

            }
            return bookModel;
        }

        public bool AddBook(Book book)
        {
            using (var ctx = new LibaryContext())
            {
                ctx.Books.Add(book);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool RemoveBook(int id)
        {
            using (var ctx = new LibaryContext())
            {
                var book = ctx.Books.Find(id);
                ctx.Books.Remove(book);

                return ctx.SaveChanges() == 1;
            }
        }
        public string UploadImage(int bookId, byte[] picture)
        {
            using (var ctx = new LibaryContext())
            {
                var book = ctx.Books.Find(bookId);
                book.Picture = picture;
                ctx.SaveChanges();
            }
            return "Success";
        }
    }
}
