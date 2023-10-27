using MyBlogAPI.Models;
using MyBlogAPI.Repository;

namespace MyBlogAPI.Provider
{
    public interface IBlogProvider
    {
        IEnumerable<Blog> GetBlogs();
    }
    public class BlogProvider : IBlogProvider
    {
        private readonly IBlogRepository _repository;

        public BlogProvider(IBlogRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return _repository.GetBlogs();
        }
    }
}