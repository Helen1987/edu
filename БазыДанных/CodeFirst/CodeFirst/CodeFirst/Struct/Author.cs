using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst
{
	public class Author
	{
		public int AuthorId { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		//[Column("Birth")]
		public DateTime BirthDate { get; set; }
	}
}
