using IdentityCleanArch.Core.Domain.Security.DbEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace IdentityCleanArch.EntityFrameWork.DbContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

}
