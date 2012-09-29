using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst
{
	public class Book
	{
		public int BookId { get; set; }
		//[MaxLength(255)]
		//[Required]
		public string Name { get; set; }

		public int AuthorId { get; set; }
		[ForeignKey("AuthorId")]
		public Author Author { get; set; }

		public int BookCollectionId { get; set; }
		//[ForeignKey("BookCollectionId")]
		public BooksCollection BooksCollection { get; set; }
	}
}
