using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst
{
	public class BooksCollection
	{
		public int BooksCollectionId { get; set; }
		//[MaxLength(255)]
		//[Required]
		public string Name { get; set; }

		public int CollectorId { get; set; }
		[ForeignKey("CollectorId")]
		public Author Collector { get; set; }

		public List<Book> Books { get; set; }
	}
}
