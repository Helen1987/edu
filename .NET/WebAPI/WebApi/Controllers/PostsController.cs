using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models.Posts;

namespace WebApi.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IPostRepository _repository;

        public PostsController(IPostRepository repository) {
            _repository = repository;
        }

        public IQueryable<Post> Get() {
            return _repository.GetAll();
        }

        public IQueryable<Post> Get(int year, int month = 0, int day = 0) 
        {
            return (new [] { new Post() { Year = year}}).AsQueryable<Post>();
        }

        [HttpGet]
        public string Category(int id)
        {
            return "test" + id.ToString();
        }
    }
}