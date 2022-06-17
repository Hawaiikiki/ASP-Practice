using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopMVC.Data
{
    public class MovieShopDbContext: DbContext //creating custom DbContext class that inherits from base base DbContext class
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
        {

        }

        // we need multiple DbSets (representing tables)
        // DbSets are simply properties of DbContext

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Purchase> Purchases { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder) // virtual method
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<Role>(ConfigureRole);
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Purchase>(ConfigurePurhcase);
        }
        private void ConfigurePurhcase(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purhcase");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TotalPrice).HasColumnType("decimal(18, 2)");
            builder.Property(x => x.PurchaseDateTime).HasDefaultValueSql("getdate()");

        }
        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(x => new {x.MovieId,x.UserId});
            builder.Property(x => x.Rating).HasColumnType("decimal(3, 2)");

        }
        private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey(x => x.Id);
        }
        private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(x => new
            {
                x.UserId,x.RoleId
            });
        }
        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(128);
            builder.Property(x => x.LastName).HasMaxLength(128);
            builder.Property(x => x.Email).HasMaxLength(256);
            builder.Property(x => x.HashedPassword).HasMaxLength(1024);
            builder.Property(x => x.Salt).HasMaxLength(1024);
            builder.Property(x => x.PhoneNumber).HasMaxLength(16);
        }
        private void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(20);
            
        }
        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(x => new
            {
                x.MovieId,
                x.CrewId,
                x.Department,
                x.Job
            }) ;
            builder.Property(x => x.Department).HasMaxLength(128);
            builder.Property(x => x.Job).HasMaxLength(128);
        }
        private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crew");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProfilePath).HasMaxLength(2084);
        }
        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(x => new
            {
                x.MovieId,
                x.CastId,
                x.Character
            });
            builder.Property(x => x.Character).HasMaxLength(450);
        }
        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenre");
            builder.HasKey(x => new
            {
                x.MovieId, x.GenreId
            });
        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            // we can specify the Fluent API Rules
            // Another way apart from data annotations for our schema
            // fluent API will override annotations
            builder.ToTable("Movie");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);

            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);

            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
