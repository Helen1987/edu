using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CodeFirst.Configuration;

namespace CodeFirst
{
	public class Library : DbContext
	{
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<BooksCollection> Collections { get; set; }

		// db name
		public Library() : base("Library")
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//To remove generating EdmMetadata
			//modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
			
			modelBuilder.Configurations.Add(new BookConfiguration());
			modelBuilder.Configurations.Add(new BookCollectionConfiguration());
			modelBuilder.Configurations.Add(new AuthorConfiguration());
		}
	}

	/// <summary>
	/// Strategies : CreateDatabaseIfNotExists, DropCreateDatabaseIfModelChanges, DropCreateDatabaseAlways, Custom, null
	/// </summary>
	public class MyInitialzer : DropCreateDatabaseIfModelChanges<Library>
	{ }
}
