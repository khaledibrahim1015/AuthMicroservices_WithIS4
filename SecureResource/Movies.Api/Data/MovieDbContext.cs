using Microsoft.EntityFrameworkCore;
using Movies.Api.Models;

namespace Movies.Api.Data;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    {

    }

    public DbSet<Movie> Movies { get; set; }

}
