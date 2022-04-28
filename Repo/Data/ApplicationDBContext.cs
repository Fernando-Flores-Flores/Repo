using Microsoft.EntityFrameworkCore;
using Repo.Models;

namespace Repo.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options
            ):base(options)
        {
                
        }
        public DbSet<Persona> Persona { get; set; }
    }
}
