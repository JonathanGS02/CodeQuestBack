using CodeQuest.Repository.Data;
using CodeQuest.Repository.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodeQuest.Repository.Services.Repository
{
    public class UserRepository : GeralPersistRepository, IUser
    {
        private readonly Context _context;

        public UserRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<Domain.Identity.User> GetUserByIdAsync(int id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Domain.Identity.User> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Domain.Identity.User>> GetUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
