using Microsoft.EntityFrameworkCore;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.EF
{
    public partial class SolutionDbContext : DbContext
    {
        public SolutionDbContext()
        {
        }

        public SolutionDbContext(DbContextOptions<SolutionDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Actors> Actors { get; set; }

        public virtual DbSet<Directors> Directors { get; set; }

        public virtual DbSet<Genres> Genres { get; set; }

        public virtual DbSet<Movies> Movies { get; set; }

        public virtual DbSet<MovieActors> MovieActors { get; set; }

        public virtual DbSet<MovieGenres> MovieGenres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors>(entity =>
            {
                entity.HasKey(e => e.ActorId).HasName("PK__Actors__8B2447B421909E17");

                entity.Property(e => e.ActorId)
                    .ValueGeneratedNever()
                    .HasColumnName("actor_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Directors>(entity =>
            {
                entity.HasKey(e => e.DirectorId).HasName("PK__Director__F5205E49CBC36653");

                entity.Property(e => e.DirectorId)
                    .ValueGeneratedNever()
                    .HasColumnName("director_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.GenreId).HasName("PK__Genres__18428D4246269777");

                entity.Property(e => e.GenreId)
                    .ValueGeneratedNever()
                    .HasColumnName("genre_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId).HasName("PK__Movies__83CDF749D7B6D8A0");

                entity.Property(e => e.MovieId)
                    .ValueGeneratedNever()
                    .HasColumnName("movie_id");
                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");
                entity.Property(e => e.DirectorId).HasColumnName("director_id");
                entity.Property(e => e.Duration).HasColumnName("duration");
                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Director).WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK__Movies__director__75A278F5");
            });

            modelBuilder.Entity<MovieActors>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ActorId).HasColumnName("actor_id");
                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Actor).WithMany()
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK__MovieActo__actor__7B5B524B");

                entity.HasOne(d => d.Movie).WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__MovieActo__movie__7A672E12");
            });

            modelBuilder.Entity<MovieGenres>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.GenreId).HasColumnName("genre_id");
                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Genre).WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__MovieGenr__genre__787EE5A0");

                entity.HasOne(d => d.Movie).WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__MovieGenr__movie__778AC167");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
