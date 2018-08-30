using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginAPI.Models;

namespace UserLoginAPI.Services
{
    public class UsersControllerService: IUsersControllerService
    {
        private readonly UserLoginAPIContext _context;

        private readonly string Salt = "gj+oAMieIg+2B/eoxA31+w==";
        private readonly byte[] Saltbyte;

        public UsersControllerService(UserLoginAPIContext context)
        {
            _context = context;
            Saltbyte = Encoding.ASCII.GetBytes(Salt);
        }

        public IEnumerable<User> GetUserService()
        {
            return _context.User;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.Email == email);

            return user;
        }

        public async Task<User> PutUser(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> PostUser([FromBody] User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserID == id);
        }

        public bool EmailExists(string email)
        {
            return _context.User.Any(x => x.Email == email);
        }

        public string HashPassword(string Password)
        {
            string hashpassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: Password,
            salt: Saltbyte,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
            return hashpassword;
        }

        public bool EmailChanged(int id, string email)
        {
            var user = _context.User.AsNoTracking().SingleOrDefault(x => x.UserID == id);
            if (user.Email != email)
            {
                return true;
            }
            return false;
        }
    }

    public interface IUsersControllerService
    {
        IEnumerable<User> GetUserService();
        Task<User> GetUser(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> PutUser(int id, User user);
        Task<User> PostUser(User user);
        Task<User> DeleteUser(int id);
        bool UserExists(int id);
        bool EmailExists(string email);
        string HashPassword(string Password);
        bool EmailChanged(int id, string email);
    }
}
