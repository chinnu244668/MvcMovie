using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Singham 1",
                    ReleaseDate = DateTime.Parse("2014-2-12"),
                    Genre = "Family",
                    Rating= "7",
                    Price = 5.99M
                },
                new Movie
                {
                    Title = "Singham 2 ",
                    ReleaseDate = DateTime.Parse("2015-3-13"),
                    Genre = "Family",
                    Rating = "8",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Singham 3",
                    ReleaseDate = DateTime.Parse("2016-2-23"),
                    Genre = "Family",
                    Rating = "9",
                    Price = 10.99M
                },
                new Movie
                {
                    Title = "Jonny Barvo",
                    ReleaseDate = DateTime.Parse("2002-4-15"),
                    Genre = "Western",
                    Rating = "6",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}