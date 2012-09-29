using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace CodeFirst
{
	class Program
	{
		static void Main(string[] args)
		{
			Database.SetInitializer(new LibraryInitializer());
			//var person = new Author
			//{
			//    AuthorId = 2,
			//    Email = "kleit@tut.by",
			//    Name = "Helen",
			//    BirthDate = DateTime.Now,
			//};
			//var collection = new BooksCollection
			//{
			//    Name = "New collection",
			//    BooksCollectionId = 1,
			//    CollectorId = 2
			//};
			//var book = new Book
			//{
			//    BookId = 1,
			//    Name = "First book",
			//    AuthorId = 2,
			//    BookCollectionId = 1,
			//};
			using (var db = new Library())
			{
			//    db.Collections.Add(collection);
			//    db.Authors.Add(person);
			//    db.Books.Add(book);
			    db.SaveChanges();
			//    //var author = db.Books.First().Author; author is NULL!!!!
			//    //Console.Write(string.Format("Firat book author name is {0}, email is {1}", author.Name, author.Email));
			}
			Console.Write("Author saved !");
			Console.ReadLine();
		}
	}
}
