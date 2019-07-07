using HandsOnExercise.BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace HandsOnExercise.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<DTOEmployee> Users { get; set; }
    }
}
