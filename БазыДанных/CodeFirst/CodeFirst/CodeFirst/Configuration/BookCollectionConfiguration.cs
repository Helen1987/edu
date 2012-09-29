using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.Configuration
{
	public class BookCollectionConfiguration : EntityTypeConfiguration<BooksCollection>
	{
		public BookCollectionConfiguration()
		{
			Property(coll => coll.Name).HasMaxLength(255).IsRequired();
			HasRequired<Author>(coll => coll.Collector);
		}
	}
}
