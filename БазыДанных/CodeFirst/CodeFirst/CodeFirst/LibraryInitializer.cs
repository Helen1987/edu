using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace CodeFirst
{
	public class LibraryInitializer : DropCreateDatabaseAlways<Library>
	{
		protected override void Seed(Library context)
		{
			var authors = new List<Author>
			{
				new Author { AuthorId = 1, BirthDate = DateTime.Now, Email = "kl@tr.t", Name = "Joan"},
				new Author { AuthorId = 2, BirthDate = DateTime.Now, Email = "tr@tr.t", Name = "Helen"}
			};

			authors.ForEach(auth => context.Authors.Add(auth));

			var collections = new List<BooksCollection>
			{
				new BooksCollection {CollectorId = 1, Name = "My first collection"},
				new BooksCollection {CollectorId = 2, Name = "Her first collection"}
			};

			collections.ForEach(coll => context.Collections.Add(coll));

			context.SaveChanges();
			base.Seed(context);
		}
	}
}
