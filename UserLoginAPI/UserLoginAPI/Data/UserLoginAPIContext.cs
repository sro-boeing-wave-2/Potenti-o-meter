using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserLoginAPI.Models
{
    public class UserLoginAPIContext : DbContext
    {
        public UserLoginAPIContext (DbContextOptions<UserLoginAPIContext> options)
            : base(options)
        {
        }

        public DbSet<UserLoginAPI.Models.User> User { get; set; }
    }
}
