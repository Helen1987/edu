using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.Configuration
{
	public class BookConfiguration : EntityTypeConfiguration<Book>
	{
		public BookConfiguration()
		{
			Property(book => book.Name).IsRequired().HasMaxLength(255);
			HasRequired<BooksCollection>(book => book.BooksCollection).WithMany(coll => coll.Books)
				.HasForeignKey(book => book.BookCollectionId).WillCascadeOnDelete(false);
			// HasRequired - not null
			HasRequired<Author>(book => book.Author);

		}
	}
}
