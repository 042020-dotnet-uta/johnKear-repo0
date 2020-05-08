using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;

namespace MvcMovie
{
	public class Program
	{
		public static void Main(string[] args)
		{

			//CreateHostBuilder(args).Build().Run();

			//creates generic host and builds the app
			var host = CreateHostBuilder(args).Build();

			//create a scope to 
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider; //create a scop for the service provider
				try
				{
					SeedData.Initialize(services);//seed the DB with the STATIC method
				}catch(Exception e)
				{
					//log if an exception occurs
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(e, "An exception occured while seeding the DB.");
				}
			}

			host.Run();

		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
