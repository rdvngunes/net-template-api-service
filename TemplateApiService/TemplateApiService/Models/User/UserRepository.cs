
using Microsoft.Extensions.Logging;
using TemplateApiService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateApiService.Models.Users
{
    public class UserRepository : IDbRepository<User>
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="loggerFactory"></param>
        public UserRepository(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("userRepository");
        }

        /// <summary>
        /// Save user details
        /// </summary>
        /// <param name="item"></param>
        public void Add(User item)
        {
            _context.User.Add(item);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get user details
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public User Find(Guid key)
        {
            return _context.User
                .FirstOrDefault(x => x.UserId.Equals(key));
        }

        public User Find(string key)
        {
            return _context.User
                .FirstOrDefault(x => x.UserId.ToString().Equals(key));
        }

        /// <summary>
        /// Get user's list
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IQueryable<User> GetAll(string Id = "")
        {
            return _context.User;
        }

        /// <summary>
        /// Remove a user
        /// </summary>
        /// <param name="key"></param>
        public void Remove(Guid key)
        {
            var entity = Find(key);
            _context.User.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update user details
        /// </summary>
        /// <param name="item"></param>
        public void Update(User item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
