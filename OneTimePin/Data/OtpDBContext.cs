using Microsoft.EntityFrameworkCore;
using OneTimePin.Models;

namespace OneTimePin.Data
{
    public class OtpDBContext : DbContext
    {
        public OtpDBContext(DbContextOptions<OtpDBContext> options)
            : base(options)
        {

        }
        public DbSet<Otp> otps { get; set; }
    }
}
