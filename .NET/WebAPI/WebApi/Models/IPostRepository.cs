using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApi.Models.Posts
{
    public interface IPostRepository
    {
        IQueryable<Post> GetAll();
        Post GetById(int id);
        void Create(Post newPost);
        Post Update(Post post);
        void Delete(int id);
        IQueryable<Post> Search(int year, int month, int day);
    }
}
