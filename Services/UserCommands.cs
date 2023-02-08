using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Wonga.Models;

namespace Wonga.Commands
{
    public interface IUserCommands
    {
        Task PutUser(int id, User user);
        Task PostUser(User user);
        Task DeleteUser(int id);
    }

    public class UserCommands : IUserCommands
    {
        private readonly UserContext _context;

        public UserCommands(UserContext context)
        {
            _context = context;
        }

        public async Task PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                throw new Exception("Invalid user id");
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
