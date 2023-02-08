using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Wonga.Models;

namespace Wonga.Queries
{
    public interface IUserQueries
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }

    public class UserQueries : IUserQueries
    {
        private readonly UserContext _context;

        public UserQueries(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
