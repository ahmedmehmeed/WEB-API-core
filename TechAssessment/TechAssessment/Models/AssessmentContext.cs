using Microsoft.EntityFrameworkCore;

namespace TechAssessment.Models
{
    public class AssessmentContext:DbContext
    {
        public AssessmentContext()
        {

        }

        public AssessmentContext(DbContextOptions options):base(options) 
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-DQIJPSD\\SQLEXPRESS;Initial Catalog=Task;Integrated Security=True");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorBook>().HasKey(ES => new {
                ES.Author_id,
                ES.Book_id
            });

        }






    }
}
