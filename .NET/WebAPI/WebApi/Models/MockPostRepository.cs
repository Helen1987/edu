using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Posts
{
    public class MockPostRepository : IPostRepository
    {
        public IQueryable<Post> GetAll()
        {
            return new[] {
                new Post { Year = 2010 },
                new Post { Year = 2012 }
            }.AsQueryable<Post>();
        }

        public Post GetById(int id)
        {
            return new Post { Year = 2010 };
        }

        public void Create(Post newPost)
        {
            
        }

        public Post Update(Post post)
        {
            return new Post { Year = post.Year };
        }

        public void Delete(int id)
        {

        }
    }
}