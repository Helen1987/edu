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

        public PostsController(IPostRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Post> Get()
        {
            return _repository.GetAll();
        }

        public Post Get(int year) 
        {
            return _repository.GetById(year);
        }

        public HttpResponseMessage Post(Post post)
        {
            _repository.Create(post);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            //response.StatusCode = HttpStatusCode.Created;
            string uri = Url.Link("DefaultApi", new { Year = post.Year });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage Put(int year, Post post)
        { 
            //post.Id = id;
            _repository.Update(post);
            var response = Request.CreateResponse(HttpStatusCode.OK, post);
            string uri = Url.Link("DefaultApi", new { year = post.Year });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            _repository.Delete(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent); 
            return response;
        }

        [HttpGet]
        public string Category(int id)
        {
            return "test" + id.ToString();
        }
    }
}