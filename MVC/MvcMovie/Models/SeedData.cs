using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
	public class SeedData
	{

		public static void Initialize(IServiceProvider serviceProvider)
		{
			using(var context = new MvcMovieContext
				(serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
			{
				if (context.Movie.Any())
				{
					return;
				}

				context.Movie.AddRange(
					new Movie
					{
						Title = "The son of Frankenstein",
						ReleaseDate = DateTime.Parse("1939-1-1"),
						Genre = "Thriller",
						Rating = "PG",
						Price = 4.99M
					},
					new Movie
					{
						Title = "The Pincess Bride",
						ReleaseDate = DateTime.Parse("1986-1-1"),
						Genre = "Fantasy",
						Rating = "PG",
						Price = 4.99M
					},
					new Movie
					{
						Title = "The Goonies",
						ReleaseDate = DateTime.Parse("1985-1-1"),
						Genre = "Thriller",
						Rating = "PG",
						Price = 4.99M
					},
					new Movie
					{
						Title = "Terminator",
						ReleaseDate = DateTime.Parse("1986-1-1"),
						Genre = "Sci-Fi",
						Rating = "R",
						Price = 4.99M
					},
					new Movie
					{
						Title = "Top gun",
						ReleaseDate = DateTime.Parse("1986-1-1"),
						Genre = "Action",
						Rating = "PG-13",
						Price = 4.99M
					}


					); ; 

				context.SaveChanges();

			}
		}

	}
}
