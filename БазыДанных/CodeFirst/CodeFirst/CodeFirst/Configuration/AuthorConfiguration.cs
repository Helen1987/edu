using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.Configuration
{
	public class AuthorConfiguration : EntityTypeConfiguration<Author>
	{
		public AuthorConfiguration()
		{
			Property(author => author.BirthDate).HasColumnName("Birth");
		}
	}
}
