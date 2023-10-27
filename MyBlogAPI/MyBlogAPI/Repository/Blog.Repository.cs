using Dapper;
using Microsoft.Data.SqlClient;
using MyBlogAPI.Models;
using System.Data;

namespace MyBlogAPI.Repository
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlogs();
    }

    public class BlogRepository : IBlogRepository
    {
        private readonly IDbConnection _configuration;

        public BlogRepository(IDbConnection configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            var result = _configuration.Query<Blog>("GetBlogs", commandType: System.Data.CommandType.StoredProcedure);
            return result;
            //using (var connection = new SqlConnection(_configuration.GetConnectionString("YourConnectionString")))
            //{
            //    return connection.Query<Blog>("GetBlogs", commandType: System.Data.CommandType.StoredProcedure);
            //}
        }
    }
}